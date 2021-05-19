using MISA.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        [Required("Tên nhóm không được phép để trống!")]
        [MISAMaxLength(MaxLength:5)]
        public string CustomerGroupName { get; set; }
        public Guid ParentId { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
