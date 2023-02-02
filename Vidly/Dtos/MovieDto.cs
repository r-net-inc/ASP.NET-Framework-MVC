using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1920, 2022, ErrorMessage = "The year must be between 1920 and 2022.")]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Range(1, 20)]
        public byte NumberAvailable { get; set; }
    }
}