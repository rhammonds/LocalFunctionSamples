
using System;
using System.IO;
using System.Threading.Tasks;


class Program
{
    public static async Task<int> Main(string[] args)
    {
        Task<string> task;
        string result = null;

        Console.WriteLine("Calling task CombineText()");
        task = CombineText(null, null);
        Console.WriteLine("Awaiting Task");
        try
        {
            result = await task; //## Errors on task
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured in *** faulted task ***: {ex.Message}");
        }

        Console.WriteLine();

        //Using local function
        try
        {
            Console.WriteLine("Calling task CombineTextLocalFunction()");
            task = CombineTextLocalFunction(null, null); //## Errors on call to method
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured *** calling method ***: {ex.Message}");
        }

        //Verify task was not awaited.
        if (task.Exception is null)
        {
            Console.WriteLine("Awaiting Task");
            result = await task;
        }
        else
        {
            Console.WriteLine("Did not Await Task");
        }

        return 0;

    }
    
    public static async Task<string> CombineText(string a, string b)
    {
        if (string.IsNullOrEmpty(a)) throw new ArgumentNullException(nameof(a));
        if (string.IsNullOrEmpty(b)) throw new ArgumentNullException(nameof(b));

        string result = null;

        await Task.Run(() => {
            result = $"{a} {b}";
        });

        return result;
    }
    
    public static Task<string> CombineTextLocalFunction(string a, string b)
    {
        if (string.IsNullOrEmpty(a)) throw new ArgumentNullException(nameof(a));
        if (string.IsNullOrEmpty(b)) throw new ArgumentNullException(nameof(b));

        return GetAllTextAsync();

        async Task<string> GetAllTextAsync()  //local function with asyn
        {
            string result = null;
            await Task.Run(() => result = $"{a} {b}");

            return result;
        }
    }
}
