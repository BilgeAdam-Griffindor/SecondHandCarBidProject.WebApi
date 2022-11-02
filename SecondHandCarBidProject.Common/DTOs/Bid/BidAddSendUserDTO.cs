namespace SecondHandCarBidProject.Common.DTOs.Bid
{
    public class BidAddSendUserDTO
    {
        public string BidName { get; set; }
        public int? CorporationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guid> CarIds { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
