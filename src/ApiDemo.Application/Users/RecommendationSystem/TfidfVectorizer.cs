using System;
using System.Collections.Generic;

namespace ApiDemo.Users.RecommendationSystem
{

    public class TfidfVectorizer
    {
        private Dictionary<string, int> vocabulary;
        private Dictionary<string, int> documentFrequencies;
        private int totalDocuments;

        public TfidfVectorizer()
        {
            vocabulary = new Dictionary<string, int>();
            documentFrequencies = new Dictionary<string, int>();
            totalDocuments = 0;
        }

        public double[,] FitTransform(List<string> documents)
        {
            totalDocuments = documents.Count;
            int documentIndex = 0;

            foreach (string document in documents)
            {
                string[] words = document.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (!vocabulary.ContainsKey(word))
                    {
                        int newIndex = vocabulary.Count;
                        vocabulary[word] = newIndex;
                    }

                    if (!documentFrequencies.ContainsKey(word))
                        documentFrequencies[word] = 0;

                    documentFrequencies[word]++;
                }

                documentIndex++;
            }

            double[,] tfidfMatrix = new double[totalDocuments, vocabulary.Count];

            documentIndex = 0;
            foreach (string document in documents)
            {
                string[] words = document.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    int wordIndex = vocabulary[word];
                    int termFrequency = CountTermFrequency(words, word);
                    double inverseDocumentFrequency = CalculateInverseDocumentFrequency(word);
                    double tfidf = termFrequency * inverseDocumentFrequency;

                    tfidfMatrix[documentIndex, wordIndex] = tfidf;
                }

                documentIndex++;
            }

            return tfidfMatrix;
        }

        private int CountTermFrequency(string[] words, string term)
        {
            int count = 0;
            foreach (string word in words)
            {
                if (word == term)
                    count++;
            }
            return count;
        }

        private double CalculateInverseDocumentFrequency(string term)
        {
            int documentFrequency;
            if (documentFrequencies.TryGetValue(term, out documentFrequency))
            {
                return Math.Log((double)totalDocuments / documentFrequency);
            }
            return 0;
        }
    }
}