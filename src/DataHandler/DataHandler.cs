using System;
using System.Text.Json;
using Backend.Models;
using Backend.Utilities;

public class DataHandler<T>
{
    private CsvFileWriter _csvWriter;
    private string _filePath;

    public DataHandler(CsvFileWriter csvWriter, string filePath)
    {
        _csvWriter = csvWriter;
        _filePath = filePath;
    }

    public void HandleMessage(byte[] message)
    {

    }
}