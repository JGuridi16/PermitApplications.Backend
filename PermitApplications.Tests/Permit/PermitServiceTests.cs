using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Core.Enums;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Services.Permit;
using PermitApplications.Tests.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PermitApplications.Tests.Permit
{
    public class PermitServiceTests : BaseTests<KhensysDbContext>
    {
        public KhensysDbContext Context { get; }

        #region Constructor

        public PermitServiceTests()
            : base("KhensysDbContextTest-Permit")
        {
            Context = new KhensysDbContext(_contextOptions);

            CreateDBMockData();
        }

        #endregion

        #region Test Methods

        [Fact]
        [Trait("Category", "Persistence")]
        public async Task Exec_GetDefaultPermit_ReadThreeEntitiesFromTable()
        {
            // Arrange
            var systemUnderTest = Context.Permit;

            // Act
            var result = await systemUnderTest.ToListAsync();
            var actual = result.Count;

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        [Trait("Category", "Service Instance")]
        public async Task Exec_GetByIdMethod_ReadFirstPermit()
        {
            // Arrange
            var systemUnderTest = CreatePermitService();

            // Act
            var actual = await systemUnderTest.GetByIdAsync(1);

            // Assert
            Assert.Null(actual);
        }

        #endregion

        #region Private Methods

        private void CreateDBMockData()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            var newPermits = new List<Persistence.Entities.Permit>()
            {
                new Persistence.Entities.Permit() { EmployeeName = "Juan", EmployeeLastname = "Perez", PermitType = new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.ENFERMEDAD } },
                new Persistence.Entities.Permit() { EmployeeName = "Maria", EmployeeLastname = "Martinez", PermitType = new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.DILIGENCIAS } },
                new Persistence.Entities.Permit() { EmployeeName = "Alex", EmployeeLastname = "Carrasco", PermitType = new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.DILIGENCIAS } },
            };

            Context.Permit.AddRange(newPermits);
            Context.SaveChanges();
        }

        private IPermitService CreatePermitService()
        {
            var mapperMock = new Mock<IMapper>();

            return new PermitService(mapperMock.Object, Context);
        }

        #endregion
    }
}
