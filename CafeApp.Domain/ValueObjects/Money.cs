namespace CafeApp.Domain.ValueObjects
{
    public class Money
    {
        private long _value;
        public Money(long value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value.ToString("#,# ريال");
        }
        public long GetValue()=>_value;
    }
}
