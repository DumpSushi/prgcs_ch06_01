using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ch06_01
{
	class TurtleException : Exception
	{
		public TurtleException()
		{}

		public TurtleException(string message)
			: base(message)
		{ }

		public TurtleException(string message, Exception innerException)
			: base(message, innerException)
		{ }

		// シリアル化をサポートするためのコンストラクタ。
		protected TurtleException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{ }
	}
}
