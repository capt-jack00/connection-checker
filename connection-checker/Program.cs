using System;
using System.Linq.Expressions;
using System.Net.Http;
using HtmlAgilityPack;

namespace connection_checker;

class Program
{
    static async Task Main(string[] args)
    {
        int c = 0;
        
        string[] websites = {
            "https://sample.com",
            "https://sample1.pl"
        };


        foreach (var item in websites)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.Cyan;

                System.Console.WriteLine("Checking website... " + websites[c]);
                using HttpClient client = new HttpClient();
                string url = websites[c];
                string html = await client.GetStringAsync(url);

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(websites[c] + " loaded with no error");

            }
            catch(Exception ex)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Error: " + ex);
                System.Console.WriteLine(websites[c] + " failed to load, check upper messeage for more information");
            }
            Console.ResetColor();

            c++;
        }
                

        

    }
}
