namespace PFE.Sample.Plugins.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;
    using Moq;
    using System;

    [TestClass]
    public class SamplePluginTest
    {
        private IPluginContext context;

        [TestInitialize]
        public void Initialize()
        {
            var outputParameters = new ParameterCollection();
            var executionContext = new Mock<IPluginExecutionContext>();
            executionContext.SetupGet(x => x.UserId).Returns(Guid.Empty);
            executionContext.SetupGet(x => x.OutputParameters).Returns(outputParameters);

            var tracingService = new Mock<ITracingService>();

            var mockContext = new Mock<IPluginContext>();
            mockContext.SetupGet(x => x.ExecutionContext).Returns(executionContext.Object);
            mockContext.SetupGet(x => x.TracingService).Returns(tracingService.Object);

            context = mockContext.Object;
        }

        [TestMethod]
        public void UserIdIsSet()
        {
            var plugin = new SamplePlugin();
            plugin.OnExecute(context);

            var userId = context.ExecutionContext.UserId;

            Assert.AreEqual(context.ExecutionContext.OutputParameters["UserId"], userId.ToString("D"));
        }
    }
}
