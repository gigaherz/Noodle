using Noodle;

public class MultiplyNode : INode
{
    [InputPin]
    public float a;

    [InputPin]
    public float b;

    [OutputPin]
    public float output;

    public void Process()
    {
        output = a * b;
    }
}