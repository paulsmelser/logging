using Microsoft.Practices.Unity;

namespace Logging.Bootstrap
{
	public class UnityConfigs
	{
		public static void RegisterTypes(IUnityContainer container)
		{

			RegisterLoggers(container);
		}

		private static void RegisterLoggers(IUnityContainer container)
		{

		}
	}
}
