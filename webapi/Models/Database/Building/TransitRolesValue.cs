namespace webapi.Models.Database.Building
{
    public class TransitRolesValue
    {
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
        public ulong Mask { get; set; } = ulong.MinValue;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }
}
