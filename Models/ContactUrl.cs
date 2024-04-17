using System.ComponentModel.DataAnnotations;

namespace MVC_assessment.Models
{
    public class ContactUrl
    {
        [Key]
        public int Id {  get; set; }
        public string UrlName {  get; set; }
        public string UrlS { get; set; }
    }
}
