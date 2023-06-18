namespace webapi.Models.Building
{
    public class TransAddress
    {
        public string doorNumber { get; set; }
        public String streetName { get; set; }
        public String streetName2 { get; set; }
        public String appartment { get; set; }
        public String zipcode { get; set; }
        public Int64? city { get; set; }

        public TransAddress(String door, String street, String street2, String appNumber, String zip, Int64? ville)
        {
            doorNumber = door;
            streetName = street;
            streetName2 = street2;
            appartment = appNumber;
            zipcode = zip;
            city = ville;
        }
    }
}
