namespace lab02.Models
{
    public class Supply
    {
        public int SupplyId { get; set; }

        public int FlowerId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public float PricePerUnit { get; set; }

        public int Units { get; set; }

        public int SupplierId { get; set; }

        public Flower? Flower { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
