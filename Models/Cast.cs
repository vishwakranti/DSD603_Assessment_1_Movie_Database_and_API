using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }

        public int MovieId { get; set; }

        //[ForeignKey("MovieId")]
        //[BindNever]
        public Movie Movie { get; set; }


    }
}
