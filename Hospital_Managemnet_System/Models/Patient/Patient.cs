using Hospital_Management_Web_Api.Models.Common;

namespace Hospital_Management_Web_Api.Models.Patient
{
    public class Patient : PersonBase
    {
        public int PatientCode { get; set; }

        public DateTime DOB { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - DOB.Year;

                if (DateTime.Today < DOB.AddYears(age))
                    age--;

                return age;
            }
        }
    }
}