﻿using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;

namespace Solution;

internal class Program
{
    static void Main(string[] args)
    {
        // Browser history
        var browserHistory = new HistoryManager();
        browserHistory.KunjungiHalaman("google.com");
        browserHistory.KunjungiHalaman("example.com");
        browserHistory.KunjungiHalaman("stackoverflow.com");

        Console.WriteLine($"Halaman saat ini: {browserHistory.LihatHalamanSaatIni()}");
        Console.WriteLine(browserHistory.Kembali());
        Console.WriteLine($"Halaman saat ini: {browserHistory.LihatHalamanSaatIni()}");

        browserHistory.TampilkanHistory();

        // Bracket validator
        var validator = new BracketValidator();
        string ekspresiValid = "[{}](){}";
        string ekspresiInvalid = "(]";

        Console.WriteLine($"Ekspresi '{ekspresiValid}' valid? {validator.ValidasiEkspresi(ekspresiValid)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid}' valid? {validator.ValidasiEkspresi(ekspresiInvalid)}");
        // Palindrome Checker
        string input1 = "Kasur ini rusak";
        string input2 = "Hello World";

        Console.WriteLine($"'{input1}' adalah palindrom? {PalindromeChecker.CekPalindrom(input1)}");
        Console.WriteLine($"'{input2}' adalah palindrom? {PalindromeChecker.CekPalindrom(input2)}");
    }
}