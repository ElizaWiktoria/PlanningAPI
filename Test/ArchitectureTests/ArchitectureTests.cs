using NetArchTest.Rules;

namespace Test.ArchitectureTests
{
    [TestClass]
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Planning.Domain";
        private const string ApplicationNamespace = "Planning.Application";
        private const string InfrastructureNamespace = "Planning.Infrastructure";
        private const string ApiNamespace = "PlanningApi";

        [TestMethod]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Planning.Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                DomainNamespace,
                ApplicationNamespace,
                InfrastructureNamespace,
                ApiNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Planning.Application.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                ApiNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Planning.Infrastructure.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApiNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Handlers_Should_Have_DependencyOnDomain()
        {
            // Arrange
            var assembly = typeof(Planning.Application.AssemblyReference).Assembly;

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            // Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }


        [TestMethod]
        public void Controllers_Should_HaveDependencyOnMediatr()
        {
            // Arrange
            var assembly = typeof(PlanningApi.AssemblyReference).Assembly;

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            // Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }
    }
}
