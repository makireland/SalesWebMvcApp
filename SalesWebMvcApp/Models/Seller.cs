using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvcApp.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field can't be empty")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} to {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} field can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} field can't be empty")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "{0} field can't be empty")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "€ {0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        [Required(ErrorMessage = "{0} field can't be empty")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime dateBirth, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            DateBirth = dateBirth;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {
            SalesRecords.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            SalesRecords.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(x => x.Date >= initial && x.Date <= final).Sum(x => x.Amount);
        }
    }
}
