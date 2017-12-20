using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionModel
{
    [Table("Attachment", Schema = "Meeting")]
    public  class Attachment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public virtual Meeting Meeting { get; set; }
        public byte[] FileData { get; set; }
        public string OriginalFileName { get; set; }
        public string MimeType { get; set; }
        public double FileSize { get; set; }
    }
}
