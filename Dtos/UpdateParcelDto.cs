namespace PostParcelsAPI.Dtos
{
    public class UpdateParcelDto
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
        public int? PostId { get; set; }
        public string PostCode { get; set; }

    }
}
