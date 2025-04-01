using System;
using System.Collections;
using System.Runtime.CompilerServices;
namespace Solution.BrowserHistory;

public class Halaman
{
    public string URL { get; }

    public Halaman(string url)
    {
        URL = url;
    }
}

public class Node
{
    public Halaman Data { get; set; }
    public Node Next { get; set; }

    public Node(Halaman data)
    {
        Data = data;
        Next = null;
    }
}

public class ManualStack
{
    private Node top;

    public ManualStack()
    {
        top = null;
    }

    public void Push(Halaman data)
    {
        var newNode = new Node(data);
        newNode.Next = top;
        top = newNode;
    }

    public Halaman Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");


        var poppedNode = top;
        top = top.Next;
        return poppedNode.Data;
    }

    public Halaman Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");

        return top?.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Display()
    {
        var current = top;
        int index = 1;
        while (current != null)
        {
            Console.WriteLine($"{index}. {current.Data.URL}");
            current = current.Next;
            index++;
        }
    }
}

public class HistoryManager
{
    private ManualStack history;

    public HistoryManager()
    {
        history = new ManualStack();
    }

    public void KunjungiHalaman(string url)
    {
        history.Push(new Halaman(url));
        Console.WriteLine($"Mengunjungi halaman: {url}");
    }

    public string Kembali()
    {
        if (history.IsEmpty()) return "Tidak ada halaman sebelumnya.";

        history.Pop();

        return history.IsEmpty() ? "Tidak ada halaman sebelumnya." : history.Peek()?.URL;
    }

    public string LihatHalamanSaatIni()
    {
        return history.Peek()?.URL ?? "Tidak ada halaman saat ini.";
    }

    public void TampilkanHistory()
    {
        var tempStack = new ManualStack();
        while (!history.IsEmpty())
        {
            tempStack.Push(history.Pop());
        }

        while (!tempStack.IsEmpty())
        {
            var halaman = tempStack.Pop();
            Console.WriteLine($"{halaman.URL}");
            history.Push(halaman); 
        }
    }
}