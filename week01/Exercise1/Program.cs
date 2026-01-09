using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}   