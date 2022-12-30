using Microsoft.EntityFrameworkCore;
using Sorter.DB;
using Sorter.Misc;
using Sorter.Models;
using Sorter.Sorters;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NumberDB>(opt => opt.UseInMemoryDatabase("NumbersList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
//Get methods
//Get main info
app.MapGet("/", () => "Sorter app. To sort use uri \"/Bubble\" or \"/MinMax\" and Post method with body (JSON format) like: {\"Value\":\"1,9,5,6,4,7,21,18,98,111\"}");

//Get last BubbleSort Results
app.MapGet("/lastBubble", async () =>
{
    Printer printer = new Printer();
    string lastBubble = printer.ReadLastSortedFile("BubbleSortResult.txt");
    if(lastBubble != null && lastBubble != "")
    {
        return Results.Ok(lastBubble);
    }
    return Results.NoContent();
});

//Get last selectionSort results
app.MapGet("/lastSelectionSort", async () =>
{
    Printer printer = new Printer();
    string lastSelectionSort = printer.ReadLastSortedFile("SelectionSortResult.txt");
    if (lastSelectionSort != null && lastSelectionSort != "")
    {
        return Results.Ok(lastSelectionSort);
    }
    return Results.NoContent();
});

//Returns string line containing the time needed to sort data using each algorithm
app.MapPost("/Performance", async (Number value, NumberDB db) =>
{
    if (value != null && value.Value != "")
    {
        var removables = db.Numbers.ToListAsync().Result;
        removables.ForEach(a => db.Numbers.Remove(a));
        await db.SaveChangesAsync();

        string[] separateElements = value.Value.Split(',');
        foreach (string separateElement in separateElements)
        {
            try
            {
                int intVal = int.Parse(separateElement);
                Number number = new Number();
                number.intValue = intVal;
                db.Numbers.Add(number);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Results.BadRequest("Bad data: " + separateElement);
            }
        }
        BubbleSorter bubbleSorter = new BubbleSorter();
        SelectionSort selectionSort = new SelectionSort();
        List<int> numbers = new List<int>();
        numbers = db.Numbers.ToListAsync().Result.
            Where(x => x.intValue != null).
            Select(x => (int)x.intValue).ToList();

        Stopwatch swBubble = new Stopwatch();
        Stopwatch swSelect = new Stopwatch();

        swBubble.Start();
        bubbleSorter.BubbleSort(numbers);
        swBubble.Stop();

        swSelect.Start();
        selectionSort.SelectionSorter(numbers);
        swSelect.Stop();

        return Results.Ok("BubbleSort took: " + swBubble.ElapsedMilliseconds + " ms, while selection sort took: " + swSelect.ElapsedMilliseconds + " ms.");
    }
    return Results.BadRequest("Value possibly contains wrong symbols");
});

//Post methods
app.MapPost("/Bubble", async (Number value, NumberDB db) =>
{
    if(value != null && value.Value != "")
    {
        var removables = db.Numbers.ToListAsync().Result;
        removables.ForEach(a => db.Numbers.Remove(a));
        await db.SaveChangesAsync();

        string[] separateElements = value.Value.Split(',');
        foreach(string separateElement in separateElements)
        {
            try
            {
                int intVal = int.Parse(separateElement);
                Number number = new Number();
                number.intValue = intVal;
                db.Numbers.Add(number);
                await db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return Results.BadRequest("Bad data: " + separateElement);
            }
        }
        BubbleSorter bubbleSorter = new BubbleSorter();
        List<int> numbers = new List<int>();
        numbers = db.Numbers.ToListAsync().Result.
            Where(x => x.intValue != null).
            Select(x => (int)x.intValue).ToList();

        numbers = bubbleSorter.BubbleSort(numbers);
        string resLine = string.Join(", ", numbers);
        Printer printer = new Printer();
        printer.WriteToFile(resLine, "BubbleSortResult.txt");
        return Results.Ok("Array of numbers sorted using bubble algorithm: " + resLine);
    }
    return Results.BadRequest("Value possibly contains wrong symbols");
});

app.MapPost("/SelectionSort", async (Number value, NumberDB db) =>
{
    if (value != null && value.Value != "")
    {
        var removables = db.Numbers.ToListAsync().Result;
        removables.ForEach(a => db.Numbers.Remove(a));
        await db.SaveChangesAsync();

        string[] separateElements = value.Value.Split(',');
        foreach (string separateElement in separateElements)
        {
            try
            {
                int intVal = int.Parse(separateElement);
                Number number = new Number();
                number.intValue = intVal;
                db.Numbers.Add(number);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Results.BadRequest("Bad data: " + separateElement);
            }
        }
        SelectionSort SelectionSorter = new SelectionSort();
        List<int> numbers = new List<int>();
        numbers = db.Numbers.ToListAsync().Result.
            Where(x => x.intValue != null).
            Select(x => (int)x.intValue).ToList();

        numbers = SelectionSorter.SelectionSorter(numbers);
        string resLine = string.Join(", ", numbers);
        Printer printer = new Printer();
        printer.WriteToFile(resLine, "SelectionSortResult.txt");
        return Results.Ok("Array of numbers sorted using selection sort algorithm: " + resLine);
    }
    return Results.BadRequest("Value possibly contains wrong symbols");
});

app.Run();
