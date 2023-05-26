using System;

namespace DataBaseRepository.Exceptions
{
	public class NotFoundSceneException : Exception
	{
		public NotFoundSceneException(string message) : base(message) { }
	}
}
