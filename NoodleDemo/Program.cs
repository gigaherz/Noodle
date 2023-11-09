using Noodle;

Console.WriteLine("Hello, World!");

NodeType multiply = NodeType.Reflect(typeof(MultiplyNode));

PrintNode(multiply);

static void PrintNode(NodeType node)
{
    Console.WriteLine("Node: " + node.Name);
    Console.WriteLine("Node Type: " + node.Type.Name);
    Console.WriteLine("Inputs:");
    foreach (var input in node.Inputs)
    {
        Console.WriteLine("   Name: " + input.Name);
        Console.WriteLine("      Type: " + input.OuterType.Name);
        if (input.MultiPin)
        {
            Console.WriteLine("      Multi-Pin:" + input.PinType.Name);
        }
    }
    Console.WriteLine("Outputs:");
    foreach (var output in node.Outputs)
    {
        Console.WriteLine("   Name: " + output.Name);
        Console.WriteLine("      Type: " + output.PinType.Name);
    }
}