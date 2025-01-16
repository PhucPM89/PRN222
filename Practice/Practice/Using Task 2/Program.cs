namespace Using_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[5];
            String taskData = "Hello";
            for(int i = 0; i < 5;i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine($"Task={Task.CurrentId}, obj={taskData}, " + $"ThreadId={Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                });
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("One or more exception occurred: ");
                foreach (var ex in ae.Flatten().InnerExceptions)
                    Console.WriteLine("   {0}", ex.Message);
            }
            Console.WriteLine("Status of completed tasks:");
            foreach(var t in tasks)
            {
                Console.WriteLine("   Task #{0}: {1}",t.Id, t.Status);    
            }
        }
    }
}
