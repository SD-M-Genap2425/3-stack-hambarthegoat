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
        if (IsEmpty()) return null;

        var poppedNode = top;
        top = top.Next;
        return poppedNode.Data;
    }

    public Halaman Peek()
    {
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

public class BrowserHistory
{
    private ManualStack history;

    public BrowserHistory()
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
        if (history.IsEmpty() || history.Peek() == null) return "Tidak ada halaman sebelumnya.";
        history.Pop();
        return history.Peek()?.URL ?? "Tidak ada halaman sebelumnya.";
    }

    public string LihatHalamanSaatIni()
    {
        return history.Peek()?.URL ?? "Tidak ada halaman saat ini.";
    }

    public void TampilkanHistory()
    {
        Console.WriteLine("Menampilkan history:");
        history.Display();
    }
}