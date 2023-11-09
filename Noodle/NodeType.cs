using System.Reflection;

namespace Noodle
{
    public class NodeType
    {
        public string Name { get; set; }

        private NodeType(string name, Type type, IReadOnlyCollection<InputPort> inputs, IReadOnlyCollection<OutputPort> outputs)
        {
            Name = name;
            Type = type;
            Inputs = inputs;
            Outputs = outputs;
        }

        public Type Type { get; set; }

        public IReadOnlyCollection<InputPort> Inputs { get; }

        public IReadOnlyCollection<OutputPort> Outputs { get; }

        public static NodeType Reflect(Type type)
        {
            List<InputPort> inputs = new();
            List<OutputPort> outputs = new();

            foreach (var field in type.GetFields())
            {
                var inputAttr = field.GetCustomAttribute<InputPinAttribute>();
                if (inputAttr != null)
                {
                    var multi = field.GetCustomAttribute<MultiPinAttribute>();

                    bool isMultiPin = multi != null;

                    var outerType = field.FieldType;
                    var pinType = field.FieldType;

                    if (isMultiPin) 
                    {
                        if (outerType.IsArray)
                        {
                            pinType = outerType.GetElementType();
                        }
                        else if (outerType.IsGenericType && outerType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            pinType = outerType.GetGenericArguments()[0];
                        }
                    }

                    var inputPort = new InputPort(field.Name, outerType, pinType, isMultiPin);

                    inputs.Add(inputPort);
                }

                var outputAttr = field.GetCustomAttribute<OutputPinAttribute>();
                if (outputAttr != null)
                {
                    var outputPort = new OutputPort(field.Name, field.FieldType);

                    outputs.Add(outputPort);
                }
            }

            return new NodeType(type.Name, type, inputs.AsReadOnly(), outputs.AsReadOnly());
        }
    }
}