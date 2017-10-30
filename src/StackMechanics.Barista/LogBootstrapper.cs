using ConfigInjector.QuickAndDirty;
using Serilog;
using Serilog.Core;
using StackMechanics.Barista.Configuration;

namespace StackMechanics.Barista
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
                .CreateLogger();
        }
    }
}