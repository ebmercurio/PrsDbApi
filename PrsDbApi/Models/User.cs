using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsDbSpecs {
    [Table("Users")]
    [Index(nameof(Username), IsUnique = true)]
    public class User {
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; } = null!;
        [StringLength(30)]
        public string Password { get; set; } = null!;
        [StringLength(30)]
        public string FirstName { get; set; } = null!;
        [StringLength(30)]
        public string Lastname { get; set; } = null!;
        [StringLength(12)]
        public string? Phone { get; set; } = null!;
        [StringLength(255)]
        public string? Email { get; set; } = null!;
        public bool IsReviewer { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

       
    }
}
