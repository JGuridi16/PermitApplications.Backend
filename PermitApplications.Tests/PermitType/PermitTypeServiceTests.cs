using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Core.Enums;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Services.PermitType;
using PermitApplications.Tests.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PermitApplications.Tests.PermitType
{
    public class PermitTypeServiceTests : BaseTests<KhensysDbContext>
    {
        public KhensysDbContext Context { get; }

        #region Constructor

        public PermitTypeServiceTests()
            : base("KhensysDbContextTest-PermitType")
        {
            Context = new KhensysDbContext(_contextOptions);

            CreateDBMockData();
        }

        #endregion

        #region Test Methods

        [Fact]
        [Trait("Category", "Persistence")]
        public async Task Exec_GetDefaultPermitTypes_ReadThreeEntitiesFromTable()
        {
            // Arrange
            var systemUnderTest = Context.PermitType;

            // Act
            var result = await systemUnderTest.ToListAsync();
            var actual = result.Count;

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        [Trait("Category", "Service Instance")]
        public async Task Exec_GetByIdMethod_ReadFirstPermitType()
        {
            // Arrange
            var systemUnderTest = CreatePermitTypeService();

            // Act
            var actual = await systemUnderTest.GetByIdAsync(4);

            // Assert
            Assert.Null(actual);
        }

        #endregion

        #region Private Methods

        private void CreateDBMockData()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            var newPermitTypes = new List<Persistence.Entities.PermitType>()
            {
                new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.ENFERMEDAD },
                new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.DILIGENCIAS },
                new Persistence.Entities.PermitType() { Description = PermitTypeStatuses.OTROS },
            };

            Context.PermitType.AddRange(newPermitTypes);
            Context.SaveChanges();
        }

        private IPermitTypeService CreatePermitTypeService()
        {
            var mapperMock = new Mock<IMapper>();

            return new PermitTypeService(mapperMock.Object, Context);
        }

        #endregion
    }
}
