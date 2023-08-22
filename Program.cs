await ProcessRequest(new Request
{
    Pages = 100
});

async Task Print(int printerNo, int pages)
{
    foreach (var page in Enumerable.Range(1, pages))
    {
        await Task.Delay(250);
        Console.WriteLine($"Printer {printerNo} prints page #{page}");
    }

    Console.WriteLine($"Printer {printerNo} is done");
}

async Task ProcessRequest(Request request)
{
    var printers = new[] { 1, 2, 3, 4 };
    var tasks = printers.Select(printerNo => Print(printerNo, request.Pages / printers.Length));
    await Task.WhenAll(tasks);
}

class Request
{
    public int Pages { get; set; }
}

