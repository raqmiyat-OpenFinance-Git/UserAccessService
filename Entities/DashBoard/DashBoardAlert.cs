using System.ComponentModel.DataAnnotations;

namespace NPSS_Connect.Models
{
    public class DashBoardAlert
    {
        [Display(Name = "Alerts")]
        public string Name { get; set; }
        [Display(Name="Name")]
        public string Value { get; set; }
        [Display(Name ="Action")]
        public string Action { get; set; }
        [Display(Name = "Conroller")]
        public string Conroller { get; set; }

    }
}
