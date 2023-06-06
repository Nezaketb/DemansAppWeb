using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DemansAppWeb.Models
{
    public class Pictures
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public byte[] Url { get; set; }

        public int? UserId { get; set; }
    }
}
