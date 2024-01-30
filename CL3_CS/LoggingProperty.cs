namespace CL3_IF_DllSample
{
    public class LoggingProperty
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public LoggingProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
