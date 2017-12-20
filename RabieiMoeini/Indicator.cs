using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabieiMoeini
{
    [Table("Indicator", Schema = "People")]
    public  class Indicator:Person
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
    }
}
