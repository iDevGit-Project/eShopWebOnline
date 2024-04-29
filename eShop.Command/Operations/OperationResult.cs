using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Common.Operations
{
	public class OperationResult
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
		public int Code { get; set; }
	}

	public class OperationResult<T>
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
		public int Code { get; set; }
		public T Data { get; set; }
	}
}
