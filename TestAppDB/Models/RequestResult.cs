using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppDB.Models
{
    public class RequestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Url")]
        public string Url { get; set; }
        [Column("Timing")]
        public double Timing { get; set; }
        public bool IsSitemap { get; set; }
        public bool IsCrawl { get; set; }
        public int RequestInfoId { get; set; }
    }
}
