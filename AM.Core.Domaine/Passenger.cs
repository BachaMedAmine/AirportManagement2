using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domaine
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }


        [Key] // Clé primaire
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Passport number must be exactly 7 characters.")]
        public string PassportNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string EmailAddress { get; set; }


        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 25 characters.")]
        public string LastName { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string TelNumber { get; set; }
        public int Age
        {
            get
            {
                int calculatedAge = (DateTime.Now.Month * 100 + DateTime.Now.Day >= BirthDate.Month * 100 + BirthDate.Day) ?
                DateTime.Now.Year - BirthDate.Year :
                 DateTime.Now.Year - BirthDate.Year - 1;
                return calculatedAge;
            }
        }
        public IList<Flight> Flights { get; set; }


        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}, " +
                   $"Email: {EmailAddress}, Phone: {TelNumber}, BirthDate: {BirthDate}, " +
                   $"Flights Count: {Flights?.Count ?? 0}";
        }




        public bool CheckProfile(String firstName, String lastName)
        {

            return FirstName == firstName && LastName == lastName;
        }
        /*public bool CheckProfile(String firstName, String lastName, String email)
        {
            return firstName == FirstName && lastName == LastName && email == EmailAddress;
        }*/

        public bool CheckProfile(String firstName, String lastName, String email=null)
        {
            if (email == null) 
            return FirstName == firstName && LastName == lastName ;
            else return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

        public virtual string GetPassengerType()
        {
            return "I am a passenger";
        }


        public void GetAge(DateTime birthDate, int calculatedAge)
        {

            calculatedAge = (DateTime.Now.Month * 100 + DateTime.Now.Day >= birthDate.Month * 100 + birthDate.Day) ?
                DateTime.Now.Year - birthDate.Year :
                 DateTime.Now.Year - birthDate.Year - 1;
            Console.WriteLine(calculatedAge);
            //Age = calculatedAge;
        }


        public void GetAge(Passenger aPassenger)
        {
            int calculatedAge = 0;
            GetAge(aPassenger.BirthDate, calculatedAge);
            //aPassenger.Age = calculatedAge;



        }
    }
}
