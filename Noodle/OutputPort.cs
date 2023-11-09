namespace Noodle
{
    public class OutputPort
    {
        public string Name { get; }

        /// <summary>
        /// The type that represents this pin.
        /// </summary>
        public Type PinType { get; }

        public OutputPort(string name, Type pinType)
        {
            Name = name;
            PinType = pinType;
        }
    }
}