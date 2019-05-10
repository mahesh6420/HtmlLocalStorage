using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStorage.Models
{
    public class UserPhoneDetailModel
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public int UserMasterModelId { get; set; }

        [ForeignKey("UserMasterModelId")]
        public UserMasterModel UserMasterModel { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; }
    }
}