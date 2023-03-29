using System.ComponentModel.DataAnnotations;

namespace DOTNET_UI.Models
{
    public class UsersModel
    {
        [Key]
        public int UserID { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Userrole { get; set; }
        public string? Email { get; set; }

    }
  
}
