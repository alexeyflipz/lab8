using System;
using System.Collections.Generic;

abstract class Graph
{
    public abstract void Draw(Dictionary<string, double> data);
}

class LineGraph : Graph
{
    public override void Draw(Dictionary<string, double> data)
    {
        Console.WriteLine("Drawing Line Graph:");
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key}: {new string('-', (int)item.Value)} ({item.Value})");
        }
    }
}

class BarGraph : Graph
{
    public override void Draw(Dictionary<string, double> data)
    {
        Console.WriteLine("Drawing Bar Graph:");
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key}: {new string('|', (int)item.Value)} ({item.Value})");
        }
    }
}

class PieChart : Graph
{
    public override void Draw(Dictionary<string, double> data)
    {
        Console.WriteLine("Drawing Pie Chart:");
        double total = 0;
        foreach (var value in data.Values)
        {
            total += value;
        }

        foreach (var item in data)
        {
            double percentage = (item.Value / total) * 100;
            Console.WriteLine($"{item.Key}: {percentage:F2}% ({item.Value})");
        }
    }
}

abstract class GraphFactory
{
    public abstract Graph CreateGraph();
}

class LineGraphFactory : GraphFactory
{
    public override Graph CreateGraph() => new LineGraph();
}

class BarGraphFactory : GraphFactory
{
    public override Graph CreateGraph() => new BarGraph();
}

class PieChartFactory : GraphFactory
{
    public override Graph CreateGraph() => new PieChart();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of graph (line, bar, pie):");
        string graphType = Console.ReadLine().ToLower();

        GraphFactory factory;
        switch (graphType)
        {
            case "line":
                factory = new LineGraphFactory();
                break;
            case "bar":
                factory = new BarGraphFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                throw new InvalidOperationException("Unknown graph type");
        }

        Console.WriteLine("Enter data points in the format 'label:value'. Type 'done' to finish:");
        Dictionary<string, double> data = new Dictionary<string, double>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;

            string[] parts = input.Split(':');
            if (parts.Length == 2 && double.TryParse(parts[1], out double value))
            {
                data[parts[0]] = value;
            }
            else
            {
                Console.WriteLine("Invalid input. Please use the format 'label:value'.");
            }
        }

        Graph graph = factory.CreateGraph();
        graph.Draw(data);
    }
}
