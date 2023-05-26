using System;


namespace DataBaseRepository.Exceptions
{
	public class NotFoundClientException : Exception
	{
		public NotFoundClientException(string message) : base(message) { }
	}
}
