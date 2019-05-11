using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LocalStorage.Models
{
    public class TestFormModel
    {
        [Key]
        public int Int { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }
        public string BirthPlace { get; set; }
        public string FatherBirthPlace { get; set; }
        public string MotherBirthPlace { get; set; }
        public string FatherPhone { get; set; }
        public string MotherPhone { get; set; }
        public string SpouseFirstName { get; set; }
        public string SposeMiddleName { get; set; }
        public string SpouseLastName { get; set; }
        public string SpusePhone { get; set; }
        public string WorkPlace { get; set; }
        public string WorkPlaceAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FatherBirthDate { get; set; }
        public DateTime MotherBirthDate { get; set; }
        public DateTime SpouseBirthDate { get; set; }
        public string SpouseBirthPlace { get; set; }
        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public IdentityUser User { get; set; }
    }
}