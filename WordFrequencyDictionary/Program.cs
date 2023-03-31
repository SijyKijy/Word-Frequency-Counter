﻿using System.Diagnostics;
using WordFrequencyDictionary.Services;

if (args.Length != 2)
{
    Console.WriteLine("Usage: WordFrequencyDictionary <inputFilePath> <outputFilePath>");
    return;
}

string inputFilePath = args[0];
string outputFilePath = args[1];

if (!File.Exists(inputFilePath))
{
    throw new FileNotFoundException($"File not found: {inputFilePath}");
}

ITextReaderProvider textReaderProvider = new FileTextReaderProvider(inputFilePath);
ITextWriterProvider textWriterProvider = new FileTextWriterProvider(outputFilePath);
IWordCounter parallelWordCounter = new ParallelWordCounter(textReaderProvider);

Process(textWriterProvider, parallelWordCounter);

Console.WriteLine("Done");

static void Process(ITextWriterProvider textWriter, IWordCounter wordCounter)
{
    var words = wordCounter.GetWords();

    if (words.Count == 0)
    {
        Console.WriteLine("Words not found.");
        return;
    }

    Console.WriteLine($"Found {words.Count} words");
    textWriter.Write(words.OrderByDescending(k => k.Value));
}

static void ProcessWithStopWatch(ITextWriterProvider textWriter, IWordCounter wordCounter)
{
    Stopwatch stopwatch = new();

    stopwatch.Start();
    var words = wordCounter.GetWords();
    stopwatch.Stop();

    if (words.Count == 0)
    {
        Console.WriteLine("Words not found.");
        return;
    }

    Console.WriteLine($"Found {words.Count} words | {stopwatch.Elapsed}");
    stopwatch.Reset();

    stopwatch.Start();
    textWriter.Write(words.OrderByDescending(k => k.Value));
    stopwatch.Stop();
    Console.WriteLine($"Write and order | {stopwatch.Elapsed}");
}