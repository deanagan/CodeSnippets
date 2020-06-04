using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CodeSnippets.Models
{
    public class Problem
    {
        [Key]
        public int Id { get;set; }
        [Required]
        [Display(Name="Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.MultilineText), Display(Name="Describe Problem")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Solution {get; set;}

    }
}
