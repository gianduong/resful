using MISA.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    public class Employee
    {
        public Guid EmployeeId { set; get; }
        [Required("Mã nhân viên không được phép để trống!")]
        [MISAMaxLength(MaxLength: 20)]
        public string EmployeeCode { get; set; }
        
        [MISAMaxLength(MaxLength: 50)]
        public string FullName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public string PositionName { get; set; }
        [MISAMaxLength(MaxLength: 12)]
        public string IdentifyNumber { get; set; }
        
        public DateTime? IdentifyDate { get; set; }
        public string IdentifyRegion { get; set; }
        public string Address { get; set; }
        [MISAMaxLength(MaxLength: 20)]
        public string PhoneNumber { get; set; }
        [MISAMaxLength(MaxLength: 20)]
        public string HomePhone { get; set; }
        [MISAMaxLength(MaxLength: 50)]
        public string Email { get; set; }
        [MISAMaxLength(MaxLength: 20)]
        public string BankAccount { get; set; }
        
        public string BankName { get; set; }
        public string Agency { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


    }
}
