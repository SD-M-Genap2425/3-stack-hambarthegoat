using System;
using System.Linq;
namespace Solution.Palindrome;

public static class PalindromeChecker
{
    public static bool CekPalindrom(string input)
    {
        var normalized = new string(input.ToLower().Where(char.IsLetter).ToArray());
        var stack = new System.Collections.Generic.Stack<char>(normalized);

        foreach (var ch in normalized)
        {
            if (stack.Pop() != ch) return false;
        }

        return true;
    }
}