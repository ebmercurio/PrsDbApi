using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsDbSpecs.Models {
    [Table("Products")]
    [Index(nameof(PartNbr), IsUnique = true)]
    public class Product {

        public int Id { get; set; }
        [StringLength(30)]
        public string PartNbr { get; set; } = null!;
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }
        [StringLength(30)]
        public string Unit { get; set; } = null!;
        [StringLength(255)]
        public string? PhotoPath { get; set; } = null!;
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; } = null!;

       


    }
}
