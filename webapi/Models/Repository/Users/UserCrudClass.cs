using System.ComponentModel.DataAnnotations;
using webapi.Models.Repository.Roles;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Users
{
    public class GetInfos
    {
        public String Email { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
    }

    public class UserBase
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<RoleBase> Roles = new List<RoleBase>();
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public String ProfilePhoto { get; set; } = String.Empty;
        public bool IsActivated { get; set; } = false;
        public long? IdAddress { get; set; } = 0;
        public UserAddress? userAddress { get; set; } = new UserAddress();

        public TokenConnexion TokenConnexion { get; set; }
    }

    public class UserRead
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public String ProfilePhoto { get; set; } = String.Empty;
        public bool IsActivated { get; set; } = false;
        public long IdAddress { get; set; } = 0;
        public UserAddress userAddress { get; set; } = new UserAddress();
    }
    public class UserAddress
    {
        public long IdAddress { get; set; }
        public string DoorNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetName2 { get; set; } = string.Empty;
        public string AppNumber { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;

        public List<String> lComplement = new List<String>();
        public String[] Complement { get; set; }
        public UserCity City { get; set; } = new UserCity();
        public UserProvince Province { get; set; } = new UserProvince();
        public UserPays Pays { get; set; } = new UserPays();
    }
    public class UserCity
    {
        public long IdCity { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class UserProvince
    {
        public long IdProvince { get; set; }
        public String Name { get; set; } = string.Empty;
    }
    public class UserPays
    {
        public long IdPays { get; set; }
        public String Name { get; set; } = String.Empty;
    }
    public class Add
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class Delete
    {
        public bool Deleted { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class Definition
    {
        public ReadUser Tournament { get; set; } = new ReadUser();
        public TokenCheck Validation { get; set; } = new TokenCheck();
    }
    public class GetAll
    {
        public List<UserRead>? Users { get; set; } = new List<UserRead>();
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class TournamentDelete
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public UserBase user { get; set; } = new UserBase();
    }
    public class ReadUser
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public bool IsActivated { get; set; } = false;
        public long? IdAddress { get; set; } = 0;
    }
    public class UserDelete
    {
    }
    public class UserModify
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public UserBase Origin { get; set; } = new UserBase();
    }
}
