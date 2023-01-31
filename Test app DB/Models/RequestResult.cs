using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app_DB.Models
{
    public class RequestResult
    {
        [Column("Url")]
        public string Url { get; set; }
        [Column("Source")]
        public List<string> Source { get; set; }
        [Column("Timing")]
        public double Timing { get; set; }
    }
}
