namespace Redstone.Core.Types
{
    public class OptValue<T>
    {
        public bool Enabled { get; set; }

        private T? _value;
        public T Value
        {
            get
            {
                if (!Enabled) return default!;
                return _value!;
            }
            set
            {
                _value = value;
            }
        }

        public OptValue(bool enabled = false, T? value = default)
        {
            Enabled = enabled;
            Value = value!;
        }

        public OptValue(T value) : this(true, value) { }
    }
}
