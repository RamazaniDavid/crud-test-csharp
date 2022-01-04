namespace Mc2.CrudTest.Core.Tasks
{
    public interface ITaskSchduler
    {
        bool IsActiveInStartup { get; set; }
        string Cron { get; set; }
        void Run();
    }

}
