namespace Calculator___Events_and_Delegates;

public class MathOperations
{
    public delegate void OperationPerformed(float result);
    
    public OperationPerformed Addition;
    public OperationPerformed Subtraction;
    public OperationPerformed Multiplication;
    public OperationPerformed Division;
    
    public void Add(float x, float y)
    {
        Addition.Invoke(x + y);
    }

    public void Subtract(float x, float y)
    {
        Subtraction.Invoke(x - y);
    }

    public void Multiply(float x, float y)
    {
        Multiplication.Invoke(x * y);
    }

    public void Divide(float x, float y)
    {
        if (y == 0)
        {
            Division.Invoke(Single.NaN);
            return;
        }

        Division.Invoke(x / y);
    }
}