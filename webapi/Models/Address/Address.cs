namespace webapi.Models.Address
{
    public class Address
    {
        public long Id { get; set; }
        public string? DoorNumber { get; set; }
        public string? StreetName { get; set; }
        public string? StreetName2 { get; set; }
        public string? AppNumber { get; set; }
        public Int64 CityId { get; set; }
    }
}
