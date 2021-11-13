using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostParcelsAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public int? Capacity { get; set; }
        [NotMapped]
        public List<Parcel> Parcels { get; set; }
    }
}
