namespace PFE.Sample.Plugins
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Extensions;
    using System;

    public interface IPluginContext
    {
        IPluginExecutionContext ExecutionContext { get; }
        IOrganizationServiceFactory OrganizationServiceFactory { get; }
        IOrganizationService OrganizationService { get; }
        IOrganizationService OrganizationAdminService { get; }
        ITracingService TracingService { get; }
    }

    public class PluginContext : IPluginContext
    {
        private readonly IServiceProvider _serviceProvider;
        public PluginContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private IPluginExecutionContext _executionContext;
        public IPluginExecutionContext ExecutionContext
        {
            get
            {
                if (_executionContext == null)
                {
                    _executionContext = _serviceProvider.Get<IPluginExecutionContext>();
                }
                return _executionContext;
            }
        }

        private IOrganizationServiceFactory _organizationServiceFactory;
        public IOrganizationServiceFactory OrganizationServiceFactory
        {
            get
            {
                if (_organizationServiceFactory == null)
                {
                    _organizationServiceFactory = _serviceProvider.Get<IOrganizationServiceFactory>();
                }
                return _organizationServiceFactory;
            }
        }

        private IOrganizationService _organizationService;
        public IOrganizationService OrganizationService
        {
            get
            {
                if (_organizationService == null)
                {
                    _organizationService = OrganizationServiceFactory.CreateOrganizationService(Guid.Empty);
                }
                return _organizationService;
            }
        }

        private IOrganizationService _organizationAdminService;
        public IOrganizationService OrganizationAdminService
        {
            get
            {
                if (_organizationAdminService == null)
                {
                    _organizationAdminService = OrganizationServiceFactory.CreateOrganizationService(null);
                }
                return _organizationAdminService;
            }
        }

        private ITracingService _tracingService;
        public ITracingService TracingService
        {
            get
            {
                if (_tracingService == null)
                {
                    _tracingService = _serviceProvider.Get<ITracingService>();
                }
                return _tracingService;
            }
        }
    }
}