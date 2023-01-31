using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_app_DB.Models
{
    public class RequestInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Request time")]
        public DateTime RequestTime { get; set; }

        [Column("Website Name")]
        public string WebsiteName { get; set; }
        
        public ICollection<RequestResult> Results { get; set; }
    }
}
