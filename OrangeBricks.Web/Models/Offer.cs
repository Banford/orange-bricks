using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
    }
}