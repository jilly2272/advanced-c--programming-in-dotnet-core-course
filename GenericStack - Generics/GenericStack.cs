namespace GenericStack___Generics;
//Objective: This project focuses on the design and implementation of a generic stack class in C# that supports pushing, popping, and displaying elements. The generic stack should be versatile, handling various data types seamlessly.

public class GenericStack
{
    public void Push<T>(List<T> stack, T item)
    {
        stack.Add(item);
    }

    public void Pop<T>(List<T> stack)
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop empty stack");
        }
        stack.RemoveAt(stack.Count-1);
    }

    public void Display<T>(List<T> stack)
    {
        if (stack.Count > 0)
        {
            foreach(T item in stack)
                Console.WriteLine($"{item}");
        }
        else
        {
            Console.WriteLine("The stack is empty");
        }
    }
}