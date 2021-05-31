using System.Collections.Generic;

namespace Models.User
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel()
        {
            ListUsers = new List<UserModel>();
            InfoUser = new UserModel();
        }
        public UserModel InfoUser { get; set; }
        public List<UserModel> ListUsers { get; set; }
    }
}
