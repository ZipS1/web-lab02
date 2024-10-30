using System.ComponentModel.DataAnnotations;

namespace lab02.Models
{
    public class Flower
    {
        [Display(Name = "Имя")]
        public int FlowerId { get; set; }

        public string? Name { get; set; }

        public string? Kind { get; set; }

        public float? AverageHeight { get; set; }

        public string? LeafType { get; set; }

        public bool CanBloom { get; set; } = true;

        public string? Details { get; set; }
    }
}
