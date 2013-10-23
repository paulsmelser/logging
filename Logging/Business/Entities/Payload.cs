using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Logging.Business.Entities
{
    public class Payload
    {
		protected bool Equals(Payload other)
		{
			if (!PayloadElements.Any() && !other.PayloadElements.Any()) return true;
			var mine = PayloadElements.GetEnumerator();
			var theirs = other.PayloadElements.GetEnumerator();
			while (mine.MoveNext())
			{
				theirs.MoveNext();
				if (mine.Current == null && theirs.Current != null || mine.Current != null && theirs.Current == null)
				{
					return false;
				}
				if (mine.Current != null && theirs.Current != null)
				{
					if (!mine.Current.Equals(theirs.Current))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (PayloadElements != null ? PayloadElements.GetHashCode() : 0);
		}
		[JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
	    public List<object> PayloadElements { get; set; }

        public Payload(){}

        public static Payload CreateNew(IEnumerable<object> elements)
        {
            return new Payload(elements);
        }
        public Payload(IEnumerable<object> payloadElements)
        {
            PayloadElements = payloadElements.ToList();
        }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Payload)obj);
		}
    }
}
