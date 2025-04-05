using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class EmployeeT2
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required, StringLength(10)]
        public string MobileNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        // Foreign Key
        public int? DesignationId { get; set; }

        // Navigation Property
        [ForeignKey("DesignationId")]
        public virtual DesignationT2 Designation { get; set; }
    }
}