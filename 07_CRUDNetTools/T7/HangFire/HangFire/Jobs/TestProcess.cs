using Hangfire.Annotations;
using Hangfire.Server;

namespace HangFire.Jobs
{
    public class TestProcess : IBackgroundProcess
    {
        public void Execute([NotNull] BackgroundProcessContext context)
        {
            context.Wait(TimeSpan.FromSeconds(10));
            CleanData();
        }

        private void CleanData()
        {
            //LimpiarData
        }
    }
}
