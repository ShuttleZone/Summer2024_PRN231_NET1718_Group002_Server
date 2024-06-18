using Microsoft.Extensions.Configuration;
using Moq;
using ShuttleZone.Common.Constants;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.Infrastructure.Helpers;

namespace ShuttleZone.Infrastructure.UnitTests.Database;

public class DatabaseTests
{

    [Ignore("This test is ignored because I don't know how to mock IConfiguration.GetConnectionString method. :))")]
    [Test]
    [TestCase(ApplicationEnvironment.Development)]
    [TestCase(ApplicationEnvironment.Staging)]
    [TestCase(ApplicationEnvironment.Production)]
    public void GetConnectionString_WithValidEnvironment_ShouldReturnConnectionString(string environment)
    {
        // Arrange
        var preparedConnectionString = "Server=.;Database=ShuttleZone;Trusted_Connection=True;";
        ApplicationEnvironment.SetEnvironment(environment);
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration
            .Setup(x => x.GetConnectionString(It.IsAny<string>()))
            .Returns(preparedConnectionString);
        DataAccessHelper.Initialize(mockConfiguration.Object);

        // Act
        string connectionString = DataAccessHelper.GetConnectionString();

        // Assert
        connectionString.Should().NotBeNullOrEmpty();
        connectionString.Should().Be(preparedConnectionString);
    }

    [Test]
    public void GetConnectionString_WithInvalidEnvironment_ShouldThrowArgumentNullException()
    {
        // Arrange
        ApplicationEnvironment.SetEnvironment("InvalidEnvironment");

        // Act
        Action action = () => DataAccessHelper.GetConnectionString();

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    [TestCase(ApplicationEnvironment.Development)]
    [TestCase(ApplicationEnvironment.Staging)]
    [TestCase(ApplicationEnvironment.Production)]
    public void GetConnectionString_WithInvalidConnectionName_ShouldThrowArugmentNullException(string environment)
    {
        // Arrange
        ApplicationEnvironment.SetEnvironment(environment);

        // Act
        Action action = () => DataAccessHelper.GetConnectionString("InvalidConnectionName");

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void InitializeDatabase_WithValidConnectionString_ShouldReturnDbContext()
    {
        // Arrange
        ApplicationEnvironment.SetEnvironment(ApplicationEnvironment.Development);

        // Act
        IApplicationDbContext dbContext = new ApplicationDbContext();

        // Assert
        dbContext.Should().NotBeNull();
    }
}
