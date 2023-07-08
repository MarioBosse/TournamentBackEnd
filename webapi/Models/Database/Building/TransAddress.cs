namespace webapi.Models.Database.Building
{
    public class TransAddress
    {
        public string doorNumber { get; set; }
        public string streetName { get; set; }
        public string streetName2 { get; set; }
        public string appartment { get; set; }
        public string zipcode { get; set; }
        public long city { get; set; }

        public TransAddress(string door, string street, string street2, string appNumber, string zip, long ville)
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
