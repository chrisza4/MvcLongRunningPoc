namespace Mvc.Longrunning.Lib
{
    public interface IDisposableTaskPerformer
    {
        void Dispose();
        void PerformSomeTask();
    }

    public class DisposableTaskPerformer : IDisposable, IDisposableTaskPerformer
    {
        bool isDispose = false;

        public void Dispose()
        {
            isDispose = true;
        }

        public void PerformSomeTask()
        {
            if (isDispose)
            {
                System.Console.WriteLine("TaskPerformer Cannot perform task. Object already Dispose!!! Let me die!");
                return;
            }

            System.Console.WriteLine("Task performing with patience.....");
        }
    }
}