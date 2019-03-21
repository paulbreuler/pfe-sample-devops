namespace PFE.Sample.Plugins
{
    using Microsoft.Crm.Sdk.Messages;

    public class SamplePlugin : PluginBase
    {
        public override void OnExecute(IPluginContext pluginContext)
        {
            var userId = pluginContext.ExecutionContext.UserId.ToString("D");
            pluginContext.ExecutionContext.OutputParameters["UserId"] = userId;
        }
    }
}