namespace PrsDbApi.Models {
    public class PO {

        public Version Vendor { get; set; }
        public IEnumerable<PoLine> PoLines { get; set; }
        public decimal PoTotal { get; set; }

    }
}
