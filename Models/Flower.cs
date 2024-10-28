namespace lab02.Models
{
    public class Flower
    {
        public int FlowerId { get; set; }

        public required string Name { get; set; }

        public string? Kind { get; set; }

        public float? AverageHeight { get; set; }

        public string? LeafType { get; set; }

        public bool CanBloom { get; set; } = true;

        public string? Details { get; set; }
    }
}
