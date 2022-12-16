namespace Redis.Cache.Model
{
    /// <summary>
    /// The container class for value types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueTypeRedisItem<T> where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueTypeRedisItem{T}"/> class.
        /// </summary>
        /// <param name="value">The Value</param>
        public ValueTypeRedisItem(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Return the specified value
        /// </summary>
        public T Value { get; }
    }
}
