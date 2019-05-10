using System.Collections.Generic;

namespace LocalStorage.Models
{
    public class UserMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<UserPhoneDetailModel> UserPhoneDetails { get; set; }
    }
}