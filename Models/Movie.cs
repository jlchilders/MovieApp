namespace MovieApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/10/2015", "7/13/2021",
    ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime ReleaseDate { get; set; }
        [Required, Range(1,5)]
        public int Rating { get; set; }
    }
}
