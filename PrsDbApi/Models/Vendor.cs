using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsDbSpecs.Models {
    [Table("Vendors")]
    [Index(nameof(Code), IsUnique = true)]
    public class Vendor {

        public int Id { get; set; }
        [StringLength(30)]
        public string Code { get; set; } = null!;
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [StringLength(30)]
        public string Address { get; set; } = null!;
        [StringLength(30)]
        public string City { get; set; } = null!;
        [StringLength(2)]
        public string State { get; set; } = null!;
        [StringLength(5)]
        public string Zip { get; set; } = null!;
        [StringLength(12)]
        public string? Phone { get; set; } = null!;
        [StringLength(255)]
        public string? Email { get; set; } = null!;

        
    }
}
