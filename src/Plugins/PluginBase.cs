namespace PFE.Sample.Plugins
{
    using Microsoft.Xrm.Sdk;
    using System;

    public abstract class PluginBase : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var pluginContext = new PluginContext(serviceProvider);

            pluginContext.TracingService.Write("Started.");
            OnExecute(pluginContext);
            pluginContext.TracingService.Write("Stopped.");
        }

        public abstract void OnExecute(IPluginContext pluginContext);
    }
}