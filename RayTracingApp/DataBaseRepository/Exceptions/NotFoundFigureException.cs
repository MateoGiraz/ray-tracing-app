using System;

namespace DataBaseRepository.Exceptions
{
	public class NotFoundFigureException : Exception
	{
		public NotFoundFigureException(string message) : base(message) { }
	}
}
