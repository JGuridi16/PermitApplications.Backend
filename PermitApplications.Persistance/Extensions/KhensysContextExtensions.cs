using Microsoft.EntityFrameworkCore;
using PermitApplications.Core.Enums;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Persistence.Entities;
using System;
using System.Linq;

namespace PermitApplications.Persistence.Extensions
{
    public static class KhensysContextExtensions
    {
        public static KhensysDbContext SeedPermitTypes(this KhensysDbContext context)
        {
            var defaultPermitTypes = new PermitType[]
            {
                new PermitType() { Description = PermitTypeStatuses.ENFERMEDAD },
                new PermitType() { Description = PermitTypeStatuses.DILIGENCIAS },
                new PermitType() { Description = PermitTypeStatuses.OTROS }
            };

            var storedPermitTypes = context.PermitType.Select(x => x.Description);

            var seedData = defaultPermitTypes.Where(x => !storedPermitTypes.Contains(x.Description));

            if (seedData.Any())
                context.PermitType.AddRange(seedData);

            return context;
        }
    }
}
