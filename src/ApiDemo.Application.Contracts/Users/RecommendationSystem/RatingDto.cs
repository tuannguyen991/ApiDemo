namespace ApiDemo.Users.RecommendationSystem
{
    public class RatingDto
    {
        /// <summary>
        /// Item Id.
        /// </summary>
        /// <example></example>
        public string ItemId { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example></example>
        public string UserId { get; set; }
        /// <summary>
        /// RatingValue.
        /// </summary>
        /// <example></example>
        public double RatingValue { get; set; }
    }
}