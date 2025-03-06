
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domaine
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }




        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public double Salary { get; set; }

        public override string GetPassengerType()
        {
            return base.GetPassengerType()+" I am a Staff Member";
        }

        public override string ToString()
        {
            return $"Employment Date: {EmployementDate:yyyy-MM-dd}, Function: {Function}, Salary: {Salary:C}";
        }

    }
}

