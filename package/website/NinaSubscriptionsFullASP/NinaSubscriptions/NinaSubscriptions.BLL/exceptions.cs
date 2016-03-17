using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BLL {

	[Serializable]
	public class requestedDataNotFoundException:Exception {
		public requestedDataNotFoundException() { }
		public requestedDataNotFoundException(string message) : base(message) { }
		public requestedDataNotFoundException(string message,Exception inner) : base(message,inner) { }
		protected requestedDataNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info,context) { }
	}

}
