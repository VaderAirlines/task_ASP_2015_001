using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BLL {

	[Serializable]
	public class courseNotFoundException:Exception {
		public courseNotFoundException() { }
		public courseNotFoundException(string message) : base(message) { }
		public courseNotFoundException(string message,Exception inner) : base(message,inner) { }
		protected courseNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info,context) { }
	}

}
