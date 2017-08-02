using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjectorPlayground;


namespace SimpleInjectorPlaygroundTests
{
    [TestFixture]
    public class SimpleInjectorBootstrapperTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = SimpleInjectorBootstrapper.Container;
        }

        [Test]
        public void SimpleInjectorBootstrapper_ShouldCreateAContainer_WithILoggerRegistered()
        {
            // arrange
            _container.Verify(VerificationOption.VerifyOnly);
            string expectedLoggerObjectGraph = "SimpleLogger()";

            // act
            InstanceProducer loggerInstanceProducer = _container.GetRegistration(typeof(ILogger));
            string actualLoggerObjectGraph = loggerInstanceProducer.VisualizeObjectGraph();

            // assert
            DiagnosticResult[] diagnosticResults = Analyzer.Analyze(_container);
            diagnosticResults.Length.Should().Be(0);
            expectedLoggerObjectGraph.Should().Be(actualLoggerObjectGraph);
        }

        [Test]
        public void SimpleInjectorBootstrapper_ShouldCreateAContainer_WithMultipleTypesRegistered()
        {
            // arrange
            _container.Verify(VerificationOption.VerifyOnly);

            // act
            InstanceProducer[] currentRegistrations = _container.GetCurrentRegistrations();
            IEnumerable<InstanceProducer> loggerInstanceProducers = currentRegistrations.Where(producer => producer.ServiceType == typeof(ILogger));
            IEnumerable<InstanceProducer> repositoryInstanceProducers = currentRegistrations.Where(producer => producer.ServiceType == typeof(IRepository));

            // assert
            DiagnosticResult[] diagnosticResults = Analyzer.Analyze(_container);
            diagnosticResults.Length.Should().Be(0);
            currentRegistrations.Should().HaveCount(4, "because there are four types registered in the container");
            loggerInstanceProducers.Should().HaveCount(1, "because only one ILogger type was should be registered in the container");
            repositoryInstanceProducers.Should().HaveCount(1, "because only one IRepository type was should be registered in the container");
        }
    }
}
