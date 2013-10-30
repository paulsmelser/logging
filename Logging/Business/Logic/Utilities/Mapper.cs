namespace Whatsnexx.Logging.Utilities
{
    public static class Mapper
    {
        public static T Map<T>(this object from)
        {
            return (T) AutoMapper.Mapper.Map(from, from.GetType(), typeof(T));
        }
    }
}
