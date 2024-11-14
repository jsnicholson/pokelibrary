using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Series")]
    public class Series
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateOnly releaseDate { get; set; }
        public string backgroundPath { get; set; }
        public string logoPath { get; set; }
    }
}
