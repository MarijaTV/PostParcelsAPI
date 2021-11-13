namespace PostParcelsAPI.Dtos
{
    public class CreateParcelDto
    {
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
        public int? PostId { get; set; }
    }
}
