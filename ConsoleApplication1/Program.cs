using Whatsnexx.Logging;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.RegisterDatabase("Data Source=(local);Integrated Security=SSPI;Initial Catalog=Logging;");
			Logger.ApplicationStartup();
		}
	}
}
