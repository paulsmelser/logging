namespace Whatsnexx.Logging.Enums
{

	public enum Keywords
	{
		BusinessLogic = 1,
		DataAccess = 2,
		Application = 4
	}

	public enum Tasks
	{
		Start = 1,
		Unknown = 2,
		PublishMessage = 101
	}

	public enum Opcodes
	{
		Success = 20,
		Trace = 21,
		UnknownError = 120,
		TimeOut = 121
	}


	public enum Levels
	{
		Critical = 5,
		Error = 4,
		Warning = 3,
		Informational = 2,
		Verbose = 1,
		LogAlways = 0

	}
}
