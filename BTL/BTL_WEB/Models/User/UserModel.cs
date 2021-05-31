using System;

namespace Models.User
{
    public class UserModel : BaseModel
    {
        public string UserName { get; set; }
        public string SaltKey { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RememberMe { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
