using System;
using System.Collections.Generic;

public class StreamData<T>
{
    public DateTime Timestamp { get; set; }
    public List<bool> Booleans { get; set; } 
    public List<int> Integers { get; set; } 
    public List<uint> UnsignedIntegers { get; set; } 
    public List<float> Floats { get; set; } 

    // Constructor to initialize the lists
    public DataStructure()
    {
        Booleans = new List<bool>(100);
        Integers = new List<int>(100);
        UnsignedIntegers = new List<uint>(100);
        Floats = new List<float>(100);
    }
}