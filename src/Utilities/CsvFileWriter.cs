using System;
using System.IO;
using System.Text;
using Backend.Models;

public class CsvFileWriter
{
    public void WriteData<T>(string filePath, StreamData<T> data)
    {
        var csvLine = $"{data.Timestamp},{string.Join(",", data.Values)}";
        File.AppendAllText(filePath, csvLine + Environment.NewLine, Encoding.UTF8);
    }
}