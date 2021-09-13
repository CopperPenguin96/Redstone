using System;

// ReSharper disable VirtualMemberCallInConstructor

namespace Redstone.AppSystem
{
	/// <summary>
	/// Basic class for exceptions created by Redstone.
	/// When thrown, logs the crash.
	/// </summary>
	public class RedstoneException : Exception
	{
		protected virtual string BaseMessage => "There was an issue in Redstone.";

		public RedstoneException(LogType type = LogType.Error)
		{
			Message = "";
			switch (type)
			{
				case LogType.Error:
					Logger.LogError(BaseMessage, this);
					break;
				case LogType.Warning:
					Logger.LogError(BaseMessage, this);
					break;
				case LogType.Crash:
					Logger.LogError(BaseMessage, this);
					break;
				default:
					Logger.Log(BaseMessage, type);
					break;
			}
		}

		public RedstoneException(string message, LogType type = LogType.Error) : base(message)
		{
			Message = message;
			switch (type)
			{
				case LogType.Error:
					Logger.LogError(message, this);
					break;
				case LogType.Warning:
					Logger.LogError(message, this);
					break;
				case LogType.Crash:
					Logger.LogError(message, this);
					break;
				default:
					Logger.Log(message, type);
					break;
			}
		}

		public RedstoneException(string message, Exception inner, LogType type = LogType.Error) : base(message, inner)
		{
			Message = message;
			switch (type)
			{
				case LogType.Error:
					Logger.LogError(message, this);
					break;
				case LogType.Warning:
					Logger.LogError(message, this);
					break;
				case LogType.Crash:
					Logger.LogError(message, this);
					break;
				default:
					Logger.Log(message, type);
					break;
			}
		}

		public new virtual string Message { get; set; }

		public RedstoneException(Exception inner, LogType type = LogType.Error) : base("", inner)
		{
			Message = BaseMessage;
			
			switch (type)
			{
				case LogType.Error:
					Logger.LogError(BaseMessage, this);
					break;
				case LogType.Warning:
					Logger.LogError(BaseMessage, this);
					break;
				case LogType.Crash:
					Logger.LogError(BaseMessage, this);
					break;
				default:
					Logger.Log(BaseMessage, type);
					break;
			}
		}
	}
}
