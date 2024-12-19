using System;

interface IScreen
{
    string GetScreenType();
}

interface IProcessor
{
    string GetProcessorType();
}

interface ICamera
{
    string GetCameraType();
}

class SmartphoneScreen : IScreen
{
    public string GetScreenType() => "Smartphone Screen";
}

class LaptopScreen : IScreen
{
    public string GetScreenType() => "Laptop Screen";
}

class TabletScreen : IScreen
{
    public string GetScreenType() => "Tablet Screen";
}

class SmartphoneProcessor : IProcessor
{
    public string GetProcessorType() => "Smartphone Processor";
}

class LaptopProcessor : IProcessor
{
    public string GetProcessorType() => "Laptop Processor";
}

class TabletProcessor : IProcessor
{
    public string GetProcessorType() => "Tablet Processor";
}

class SmartphoneCamera : ICamera
{
    public string GetCameraType() => "Smartphone Camera";
}

class LaptopCamera : ICamera
{
    public string GetCameraType() => "Laptop Camera";
}

class TabletCamera : ICamera
{
    public string GetCameraType() => "Tablet Camera";
}

interface ITechProductFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}

class SmartphoneFactory : ITechProductFactory
{
    public IScreen CreateScreen() => new SmartphoneScreen();
    public IProcessor CreateProcessor() => new SmartphoneProcessor();
    public ICamera CreateCamera() => new SmartphoneCamera();
}

class LaptopFactory : ITechProductFactory
{
    public IScreen CreateScreen() => new LaptopScreen();
    public IProcessor CreateProcessor() => new LaptopProcessor();
    public ICamera CreateCamera() => new LaptopCamera();
}

class TabletFactory : ITechProductFactory
{
    public IScreen CreateScreen() => new TabletScreen();
    public IProcessor CreateProcessor() => new TabletProcessor();
    public ICamera CreateCamera() => new TabletCamera();
}

class TechProductAssembler
{
    private readonly IScreen _screen;
    private readonly IProcessor _processor;
    private readonly ICamera _camera;

    public TechProductAssembler(ITechProductFactory factory)
    {
        _screen = factory.CreateScreen();
        _processor = factory.CreateProcessor();
        _camera = factory.CreateCamera();
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product assembled with:");
        Console.WriteLine($"- Screen: {_screen.GetScreenType()}");
        Console.WriteLine($"- Processor: {_processor.GetProcessorType()}");
        Console.WriteLine($"- Camera: {_camera.GetCameraType()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a product to create:");
        Console.WriteLine("1. Smartphone");
        Console.WriteLine("2. Laptop");
        Console.WriteLine("3. Tablet");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        ITechProductFactory factory;
        switch (choice)
        {
            case "1":
                factory = new SmartphoneFactory();
                break;
            case "2":
                factory = new LaptopFactory();
                break;
            case "3":
                factory = new TabletFactory();
                break;
            default:
                throw new InvalidOperationException("Invalid choice");
        }

        var assembler = new TechProductAssembler(factory);
        assembler.DisplayProductDetails();
    }
}
