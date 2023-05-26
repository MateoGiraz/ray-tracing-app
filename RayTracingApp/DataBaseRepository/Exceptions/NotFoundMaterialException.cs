using System;

namespace DataBaseRepository.Exceptions
{
	public class NotFoundMaterialException : Exception
	{
		public NotFoundMaterialException(string message) : base(message) { }
	}
}
