using ConfigInjector.QuickAndDirty;
using Serilog;
using Serilog.Core;
using StackMechanics.Common.Configuration.Configuration;
using StackMechanics.Common.Logging.Configuration;
using StackMechanics.Common.Logging.Enrichers;

namespace StackMechanics.Common.Logging
{
    public static class LogBootstrapper
    {
        public static void Bootstrap()
        {
            var logLevelSwitch = new LoggingLevelSwitch();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(logLevelSwitch)
                .WriteTo.Console()
                .WriteTo.Seq(DefaultSettingsReader.Get<SeqServerUrl>().ToString(), controlLevelSwitch: logLevelSwitch)
                .Enrich.WithProcessName()
                .Enrich.WithProcessId()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProperty(nameof(ApplicationName), DefaultSettingsReader.Get<ApplicationName>())
                .Enrich.With<CorrelationIdEnricher>()
                .CreateLogger();
        }
    }
}