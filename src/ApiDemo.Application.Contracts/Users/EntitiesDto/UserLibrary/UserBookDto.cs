using ApiDemo.Books;

namespace ApiDemo.Users
{
    public class UserBookDto : BookDto
    {
        /// <summary>
        /// User Library
        /// </summary>
        /// <example></example>
        public UserLibraryDto UserLibrary { get; set; }
    }
}
