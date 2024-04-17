﻿using System.ComponentModel.DataAnnotations;

namespace MVC_assessment.Models
{
    public class profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
