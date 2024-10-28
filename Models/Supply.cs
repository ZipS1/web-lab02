namespace lab02.Models
{
    public class Supply
    {
        public int SupplyId { get; set; }

        public required int FlowerId { get; set; }

        public required DateTime DeliveryDate { get; set; }

        public required float PricePerUnit { get; set; }

        public required int Units { get; set; }

        public required int SupplierId { get; set; }

        public Flower? Flower { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
