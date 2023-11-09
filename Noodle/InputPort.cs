namespace Noodle
{
    public class InputPort
    {
        public string Name { get; }

        /// <summary>
        /// The type that represents this port.
        /// For multi-pin ports, this would be a collection like List<> or an array.
        /// For single-pin ports, this is the same as PinType.
        /// </summary>
        public Type OuterType { get; }

        /// <summary>
        /// The type that represents each pin.
        /// </summary>
        public Type PinType { get; }

        /// <summary>
        /// If true, there can be an arbitrary number of pins connected at once to this port.
        /// </summary>
        public bool MultiPin { get; }

        public InputPort(string name, Type outerType, Type pinType, bool multiPin)
        {
            Name = name;
            OuterType = outerType;
            PinType = pinType;
            MultiPin = multiPin;
        }
    }
}