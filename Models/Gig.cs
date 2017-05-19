using System;
using System.ComponentModel.DataAnnotations;

namespace FullstackPluralsightProjectToLearn.Models
{
    public class Gig
    {
        public int Id { get; set; }

       
        //navigation property so use id of it, and make it required
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

      
        //navigate property - to other class so make foreign key like id 

        public Genre Genre { get; set; }


        public byte GenreId { get; set; }
    }

}