using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleThreadLock
{


	//class Program
	//{
	//	static readonly object _lock = new object();

	//	static void Main()
	//	{
	//		var thread = new Thread(DoWork);
	//		thread.Start();

	//		lock (_lock)
	//		{
	//			Console.WriteLine("Main thread acquired the lock.");
	//			Thread.Sleep(1000);
	//			Console.WriteLine("Main thread released the lock.");
	//		}

	//		thread.Join();
	//		Console.ReadLine();
	//	}

	//	static void DoWork()
	//	{
	//		lock (_lock)
	//		{
	//			Console.WriteLine("Worker thread acquired the lock.");
	//			Thread.Sleep(1000);
	//			Console.WriteLine("Worker thread released the lock.");
	//		}
	//	}
	//}


	class Program
	{
		static SemaphoreSlim _semaphore = new SemaphoreSlim(2);

		static void Main()
		{
			long dateTime1 = new DateTime().Millisecond;
			for (int i = 0; i < 5; i++)
			{
				var thread = new Thread(DoWork);
				thread.Start();
			}
			Console.WriteLine("main thread fini");
			long dateTime2 = new DateTime().Millisecond;
			long time = dateTime2 - dateTime1;
			Console.WriteLine(time / 1000);
			Console.ReadLine();
		}

		static void DoWork()
		{
			Console.WriteLine("Worker thread trying to acquire semaphore.");
			_semaphore.Wait();

			Console.WriteLine("Worker thread acquired semaphore.");
			Thread.Sleep(1000);

			Console.WriteLine("Worker thread releasing semaphore.");
			_semaphore.Release();
		}
	}


}
