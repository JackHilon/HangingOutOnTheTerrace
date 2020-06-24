using System;
using System.Collections.Generic;

namespace HangingOutOnTheTerrace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hanging Out On The Terrace
            // https://open.kattis.com/problems/hangingout 
            // Just a numerical program....

            var parameters = EnterLimitAndEvents();
            var myLimit = parameters[0];
            var eventsCount = parameters[1];

            var events = EnterAllEvents(eventsCount);

            Console.WriteLine(EventsProcessing(myLimit, events));
        }
        private static int EventsProcessing(int limit, List<int> events)
        {
            var notAllowed = new List<int>();

            int sum = 0;
            int temp;
            for (int i = 0; i < events.Count; i++)
            {
                temp = sum + events[i];
                if (temp > limit)
                    notAllowed.Add(events[i]);
                else
                    sum = temp;
            }
            return notAllowed.Count;
        }

        private static List<int> EnterAllEvents(int eventsNum)
        {
            var events = new List<int>();
            for (int i = 0; i < eventsNum; i++)
            {
                events.Add(EnterEvent());
            }
            return events;
        }

        private static int EnterEvent()
        {
            var arr = new string[2] { "", "" };
            int a = 0;
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                if (arr.Length != 2)
                    throw new FormatException();
                if (arr[0] != "enter" && arr[0] != "leave")
                    throw new ArgumentException();

                a = int.Parse(arr[1]);
                if (a < 1 || a > 200)
                    throw new ArgumentException();
                if (arr[0] == "leave")
                    a = -a;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterEvent();
            }
            return a;
        }
     
        private static int[] EnterLimitAndEvents()
        {
            var arr = new string[2] { "", "" };
            var res = new int[2] { 0, 0 };
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (LimitEventsConditions(res) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterLimitAndEvents();
            }
            return res;
        }
        private static bool LimitEventsConditions(int[] array)
        {
            int l = array[0];
            int x = array[1];
            if (l < 1 || l > 200 || x < 0 || x > 100)
                return false;
            else return true;
        }
    }
}
