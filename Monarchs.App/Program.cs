using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using Monarchs.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monarchs.App
{
    class Program
    {
        static MonarchRepository _repository;
        static List<Monarch> _monarchs;

        static void Main(string[] args)
        {
            Prompt.Write("Welcome to MonarchApp, please provide a token to access most recent monarch Data");

            string token = Prompt.GetString("Token:");

            //check if user provided a token or not. 
            if (string.IsNullOrEmpty(token))
            {
                Prompt.Write("Token not provided, trying to access locally saved monarchs");
                try
                {
                    _repository = new MonarchRepository(new FileAccess(""));
                }
                catch (Exception)
                {
                    Prompt.ErrorExit("Error occured in reading file access... press any key to exit the program");
                }
            } else
            {
                try
                {
                    _repository = new MonarchRepository(
                        new ApiAccess("", token)
                    );
                    Prompt.Write("API Accessed and data has been read, press any key to see results");
                    Prompt.Wait();
                }
                catch (Exception)
                {
                    Prompt.ErrorExit("Error occured in accessing the API... press any key to exit the program");
                }
            }

            Prompt.Write($"There are {_monarchs.Count} monarchs in the list");

            var longestMonarch = _monarchs.Aggregate((m1, m2) => m1.ReignDuration > m2.ReignDuration ? m1 : m2);
            Prompt.Write($"{longestMonarch.Name} reigned the longest, at a duration of {longestMonarch.ReignDuration} years");

            var mostRulingHouse = _monarchs.GroupBy(x => x.House)
                                    .OrderBy(g => g.Sum(x => x.ReignDuration))
                                    .FirstOrDefault();

            Prompt.Write($"The most rulig house was {mostRulingHouse.Key} with a total of {mostRulingHouse.Sum(x => x.ReignDuration)} years");

            var mostCommonFirstName = _monarchs.GroupBy(x => x.Name.Split(" ")[0])
                                        .OrderBy(g => g.Count())
                                        .FirstOrDefault();
            Prompt.Write($"The most common firstname is: {mostCommonFirstName.Key}");

            Prompt.Write("That should be all, press any key to exit");
            Prompt.Wait();
        }
    }
}
/*
    1. How many monarchs are there in the list
    2. Which monarch ruled the longest (duration too)
    3. Which house ruled the longest (duration)
    4. Most common firstname
*/