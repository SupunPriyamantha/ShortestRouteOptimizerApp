using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShortestRouteOptimizerMVCApp.Models
{
    public class ShortestPathData
    {
        [DisplayName("Start Node")]
        [Required]
        [NodeValidator(ErrorMessage = "Entered Node is not a valid node")]
        public string StartNode { get; set; }

        [DisplayName("Finish Node")]
        [Required]
        [NodeValidator(ErrorMessage = "Entered Node is not a valid node")]
        public string FinishNode { get; set; }

        public int ShortestDistance { get; set; }

        public List<string> NodeNames { get; set; }

        public string[] InitialNodeNames { get; set; }
    }
}