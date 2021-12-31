using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Core.Tasks
{
    public static class TaskExtension
    {
        [Obsolete]
        public static void ExecuteTask(this ITaskSchduler task)
        {
            RecurringJob.AddOrUpdate(() => task.Run(), task.Cron);
        }

    }
}
