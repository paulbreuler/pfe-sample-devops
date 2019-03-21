namespace PFE.Sample.Workflows
{
    using Microsoft.Xrm.Sdk.Workflow;
    using System.Activities;

    public class SampleActivity : CodeActivity
    {
        [Input("Name")]
        [RequiredArgument]
        public InArgument<string> Name { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var name = this.Name.Get<string>(context);
        }
    }
}