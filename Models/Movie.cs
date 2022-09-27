using System.ComponentModel.DataAnnotations;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movie Title")]
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public string? Overview { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }

        public ICollection<Cast> Casts { get; set; }


    }
}
