using PermitApplications.Core.BaseModel.Base;
using System;

namespace PermitApplications.Persistence.Entities
{
    public class Permit : Base
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public PermitType PermitType { get; set; }
        public DateTimeOffset PermitDate { get; set; }
    }
}
