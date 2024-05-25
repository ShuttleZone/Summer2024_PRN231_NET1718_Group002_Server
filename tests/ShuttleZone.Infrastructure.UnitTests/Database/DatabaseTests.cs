using ShuttleZone.Common.Constants;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Helpers;

namespace ShuttleZone.Infrastructure.UnitTests.Database;

public class DatabaseTests
{

    [Test]
    [TestCase(ApplicationEnvironment.Development)]
    [TestCase(ApplicationEnvironment.Staging)]
    [TestCase(ApplicationEnvironment.Production)]
    public void GetConnectionString_WithValidEnvironment_ShouldReturnConnectionString(string environment)
    {
        // Arrange
        ApplicationEnvironment.SetEnvironment(environment);

        // Act
        string connectionString = DataAccessHelper.GetConnectionString();

        // Assert
        connectionString.Should().NotBeNullOrEmpty();
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
