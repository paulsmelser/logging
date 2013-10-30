using System;

namespace Whatsnexx.Logging.Entities
{
    public class EventSource
    {
	    protected bool Equals(EventSource other)
	    {
		    return Guid.Equals(other.Guid) && string.Equals(Name, other.Name);
	    }

	    public override int GetHashCode()
	    {
		    unchecked
		    {
			    return (Guid.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
		    }
	    }

	    protected EventSource(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
        }

        public EventSource()
        {
        }

        public static EventSource CreateClean(Guid guid, string name)
        {
            return new EventSource(guid, name);
        }

	    public override bool Equals(object obj)
	    {
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;	
		    return Equals((EventSource) obj);
	    }

	    public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}
