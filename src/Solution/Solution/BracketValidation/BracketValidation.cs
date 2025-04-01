using System;
using System.Runtime.CompilerServices;
namespace Solution.BracketValidation;

public class ManualStack
{
    private class Node
    {
        public char Data { get; set; }
        public Node Next { get; set; }

        public Node(char data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node top;

    public ManualStack()
    {
        top = null;
    }

    public void Push(char data)
    {
        var newNode = new Node(data);
        newNode.Next = top;
        top = newNode;
    }

    public char Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
        var poppedNode = top;
        top = top.Next;
        return poppedNode.Data;
    }

    public char Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
        return top.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }
}

public class BracketValidator
{
    public bool ValidasiEkspresi(string ekspresi)
    {
        var stack = new ManualStack();
        foreach (var ch in ekspresi)
        {
            if (ch == '(' || ch == '{' || ch == '[') stack.Push(ch);
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.IsEmpty()) return false;
                var top = stack.Pop();
                if ((ch == ')' && top != '(') ||
                        (ch == '}' && top != '{') ||
                        (ch == ']' && top != '['))
                {
                    return false;
                }
            }
        }
        return stack.IsEmpty();
    }
}