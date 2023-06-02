using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiDemo.Users.RecommendationSystem
{
    public class ItemRecommendationSystem
    {
        private List<ItemDto> items;
        private List<RatingDto> ratings;
        private TfidfVectorizer vectorizer;
        private double[,] tfidfMatrix;
        private double[,] similarityMatrix;

        public ItemRecommendationSystem(List<ItemDto> items, List<RatingDto> ratings)
        {
            this.items = items;
            this.ratings = ratings;
            vectorizer = new TfidfVectorizer();
            Initialize();
        }

        private void Initialize()
        {
            var genres = items.Select(item => item.Genres).ToList();
            tfidfMatrix = vectorizer.FitTransform(genres);
            similarityMatrix = CosineSimilarity(tfidfMatrix, tfidfMatrix);
        }

        public List<string> GetUserRecommendations(int topN = 2)
        {
            var userRatings = ratings
                                .ToDictionary(rating => rating.ItemId, rating => Convert.ToDouble(rating.RatingValue));

            var itemIndices = new List<int>();
            foreach (var rating in userRatings)
            {
                string itemId = rating.Key;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ItemId == itemId)
                    {
                        itemIndices.Add(i);
                        break;
                    }
                }
            }

            var weightedRatings = new List<List<double>>();
            for (int i = 0; i < itemIndices.Count; i++)
            {
                int itemIndex = itemIndices[i];
                double rating = userRatings.Values.ElementAt(i);
                var weightedRating = new double[similarityMatrix.GetLength(1)];
                for (int j = 0; j < similarityMatrix.GetLength(1); j++)
                {
                    weightedRating[j] = similarityMatrix[itemIndex, j] * rating;
                }

                weightedRatings.Add(new List<double>(weightedRating));
            }

            int n = weightedRatings[0].Count;
            List<double> aggregatedRatings = new List<double>(n);
            for (int i = 0; i < n; i++)
            {
                double sum = weightedRatings.Sum(list => list[i]);
                aggregatedRatings.Add(sum);
            }

            var sortedItems = Enumerable.Range(0, aggregatedRatings.Count)
                                        .OrderByDescending(i => aggregatedRatings[i])
                                        .ToList();

            var itemsRecommendIds = sortedItems.Where(i => !userRatings.ContainsKey(items[i].ItemId))
                                                 .Select(i => items[i].ItemId)
                                                 .ToList();

            var topItems = itemsRecommendIds.Take(topN).ToList();

            return topItems;
        }

        private double[,] CosineSimilarity(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int rowsB = matrixB.GetLength(0);

            var similarityMatrix = new double[rowsA, rowsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < rowsB; j++)
                {
                    double dotProduct = 0;
                    double normA = 0;
                    double normB = 0;

                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        dotProduct += matrixA[i, k] * matrixB[j, k];
                        normA += Math.Pow(matrixA[i, k], 2);
                        normB += Math.Pow(matrixB[j, k], 2);
                    }

                    similarityMatrix[i, j] = dotProduct / (Math.Sqrt(normA) * Math.Sqrt(normB));
                }
            }

            return similarityMatrix;
        }
    }

}