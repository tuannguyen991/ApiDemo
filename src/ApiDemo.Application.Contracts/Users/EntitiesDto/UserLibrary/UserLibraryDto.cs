using System;
using System.Collections.Generic;
using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserLibraryDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff61</example>
        public string BookId { get; set; }
        /// <summary>
        /// Number of Read Pages.
        /// </summary>
        /// <example>0</example>
        public int NumberOfReadPages { get; set; }
        /// <summary>
        /// Last Read.
        /// </summary>
        /// <example></example>
        public DateTime? LastRead { get; set; }
        /// <summary>
        /// Last Read.
        /// </summary>
        /// <example></example>
        public string LastLocator { get; set; }
        /// <summary>
        /// Href.
        /// </summary>
        /// <example></example>
        public string Href { get; set; }
        /// <summary>
        /// User Rating.
        /// </summary>
        /// <example>0</example>
        public double Rating { get; set; }
        /// <summary>
        /// Book Title.
        /// </summary>
        /// <example>Harry Potter and the Half-blood Prince</example>
        public string Title { get; set; }
        /// <summary>
        /// Book Subtitle.
        /// </summary>
        /// <example></example>
        public string Subtitle { get; set; }
        /// <summary>
        /// Number of Pages.
        /// </summary>
        /// <example>1008</example>
        public int NumberOfPages { get; set; }
        /// <summary>
        /// Epub Link.
        /// </summary>
        /// <example></example>
        public string EpubLink { get; set; }
        /// <summary>
        /// Image Link of Book.
        /// </summary>
        /// <example>https://www.dropbox.com/s/37skw74bz3gys9a/prince.jpg?raw=1</example>
        public string ImageLink { get; set; }
        /// <summary>
        /// Average Rating of Book.
        /// </summary>
        /// <example>4.1</example>
        public double AverageRating { get; set; }
        /// <summary>
        /// Description of Book.
        /// </summary>
        /// <example>In a brief statement on Friday night, Minister for Magic Cornelius Fudge confirmed that He Who Must Not Be Named has returned to this country and is once more active. \"It is with great regret that I must confirm that the wizard styling himself Lord - well, you know who I mean - is alive and among us again,\" said Fudge.' These dramatic words appeared in the final pages ofHarry Potter and the Order of the Phoenix. In the midst of this battle of good and evil,Harry Potter and the Half-Blood Prince takes up the story of Harry Potter's sixth year at Hogwarts School of Witchcraft and Wizardry, with Voldemort's power and followers increasing day by day ...</example>
        public string Description { get; set; }
        /// <summary>
        /// Author List.
        /// </summary>
        /// <example></example>
        public List<AuthorDto> Authors { get; set; }
        /// <summary>
        /// Category List.
        /// </summary>
        /// <example></example>
        public List<CategoryDto> Categories { get; set; }
    }
}
