using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ClipModel : BaseModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
