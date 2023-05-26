using System;

namespace DataBaseRepository.Exceptions
{
	public class NotFoundModelException : Exception
	{
		public NotFoundModelException(string message) : base(message) { }
	}
}
