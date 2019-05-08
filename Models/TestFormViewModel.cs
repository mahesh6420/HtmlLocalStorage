using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStorage.Models
{
    public class TestFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        public string FatherFirstName { get; set; }

        [Required]
        public string FatherMiddleName { get; set; }

        [Required]
        public string FatherLastName { get; set; }

        [Required]
        public string MotherFirstName { get; set; }

        [Required]
        public string MotherMiddleName { get; set; }

        [Required]
        public string MotherLastName { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        [Required]
        public string FatherBirthPlace { get; set; }

        [Required]
        public string MotherBirthPlace { get; set; }

        [Required]
        public string FatherPhone { get; set; }

        [Required]
        public string MotherPhone { get; set; }

        [Required]
        public string SpouseFirstName { get; set; }

        [Required]
        public string SposeMiddleName { get; set; }

        [Required]
        public string SpouseLastName { get; set; }

        [Required]
        public string SpusePhone { get; set; }

        [Required]
        public string WorkPlace { get; set; }

        [Required]
        public string WorkPlaceAddress { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime FatherBirthDate { get; set; }

        [Required]
        public DateTime MotherBirthDate { get; set; }

        [Required]
        public DateTime SpouseBirthDate { get; set; }

        [Required]
        public string SpouseBirthPlace { get; set; }
    }
}