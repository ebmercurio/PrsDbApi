using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsDbSpecs.Models {
    public class Request {

        public int Id { get; set; }
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
        [StringLength(80)]
        public string Justification { get; set; } = string.Empty;
        [StringLength(80)]
        public string? RejectionReason { get; set; } = string.Empty;
        [StringLength(20)]
        public string DeliveryMode { get; set; } = "Pickup";
        [StringLength(10)]
        public string Status { get; set; } = "New";
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; } = 0;
        public int UserId { get; set; }
        public virtual User? User { get; set; } = null!;

        public virtual List<RequestLine>? RequestLines { get; set; }
        
    }
}
