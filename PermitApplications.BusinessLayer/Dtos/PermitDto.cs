using PermitApplications.Core.BaseModel.BaseDto;
using System;

namespace PermitApplications.BusinessLayer.Entities
{
    public class PermitDto : BaseDto
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public int? PermitTypeId { get; set; }
        public DateTimeOffset PermitDate { get; set; }

        public virtual PermitTypeDto PermitType { get; set; }
    }
}
