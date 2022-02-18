using PermitApplications.Core.BaseModel.BaseDto;
using PermitApplications.Persistence.Entities;
using System;

namespace PermitApplications.BusinessLayer.Entities
{
    public class PermitDto : BaseDto
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public PermitType PermitType { get; set; }
        public DateTimeOffset PermitDate { get; set; }
    }
}
