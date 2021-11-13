namespace PostParcelsAPI.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
        public int? PostId { get; set; }
    }
}
