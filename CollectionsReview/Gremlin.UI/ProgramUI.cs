using System.Collections.Generic;
using System.Linq;


public class ProgramUI
{
    private GremlinListRepository _gListRepo = new GremlinListRepository();

    private GremlinDictionaryRepository _gDicRepo = new GremlinDictionaryRepository();

    private GremlinQueueRepository _gQueueRepo = new GremlinQueueRepository();


    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("Welcome\n" +
            "1. Display Dictionary Notes\n" +
            "2. Display Queue Notes\n" +
            "============================\n" +
            "3. Get All Gremlins (List)\n" +
            "4. Get Gremlin By Id (List)\n" +
            "5. Add Gremlin (List)\n" +
            "6. Update Gremlin (List)\n" +
            "7. Delete Gremlin (List)\n" +
            "=============================\n" +
            "8. Get All Gremlins (Dict)\n" +
            "9. Get Gremlin by Key (Dict)\n" +
            "10. Add Gremlin (Dict)\n" +
            "11. Update Gremlin (Dict)\n" +
            "12. Delete Gremlin (Dict)\n" +
            "=============================\n" +
            "13. Get Gremlins (Queue)\n" +
            "14. Get Gremlin By Id (Queue)\n" +
            "15. Add Gremlin (Queue)\n" +
            "16. Update Gremlin (Queue)\n" +
            "17. Delete Gremlin (Queue)\n" +
            "00. Exit");

            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    DicDisplayNotes();
                    break;
                case 2:
                    QueueDisplayNotes();
                    break;
                case 00:
                    isRunning = Quit();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection.");
                    break;
            }

        }
    }

    private void DicDisplayNotes()
    {
        Console.Clear();

        System.Console.WriteLine("WTF IS A DICTIONARY");

        System.Console.WriteLine("Its a Key/Value pair collection Dictionary<Tkey,TValue>");

        System.Console.WriteLine("You always need a Different Key! Values can be the same!");

        System.Console.WriteLine("These Collections are Quick!");

        System.Console.WriteLine("Ex:");

        Dictionary<int, Gremlin> gremlinDic = new Dictionary<int, Gremlin>();

        //We can add to this Dictionary by using the .Add() method!
        //using object initialization
        //* Add to dictionary
        gremlinDic.Add(1, new Gremlin
        {
            ID = 1,
            Name = "Dude",
            GremlinType = GremlinType.Minion
        });

        var stripe = new Gremlin
        {
            ID = 2,
            Name = "Stripe",
            GremlinType = GremlinType.King
        };

        //* Add to dictionary
        gremlinDic.Add(2, stripe);

        //Lets see how many gremlins we have .Count();
        System.Console.WriteLine(gremlinDic.Count());

        //Lets See the data!
        //Key/Value pair constraint
        foreach (KeyValuePair<int, Gremlin> gremlin in gremlinDic)
        {
            System.Console.WriteLine($"{gremlin.Key} - {gremlin.Value.Name}");
        }

        //Lets See the data by constraining the Keys!
        foreach (int gremlinKey in gremlinDic.Keys)
        {
            System.Console.WriteLine($"{gremlinKey}");
        }

        //Lets See the data by constraining the Values!
        foreach (Gremlin gremlinValue in gremlinDic.Values)
        {
            System.Console.WriteLine($"ID: {gremlinValue.ID}\n" +
                                     $"Name: {gremlinValue.Name}");
        }

        Console.ReadKey();
    }

    private void QueueDisplayNotes()
    {
        System.Console.WriteLine("WTF IS A QUEUE -> F.I.F.O => FIRST IN FIRST OUT");

        System.Console.WriteLine("Think of this as being in line at the store");

        System.Console.WriteLine("you can't cut in line, you have to wait your turn");

        Queue<Gremlin> gremlinQueue = new Queue<Gremlin>();

        var stripe = new Gremlin
        {
            ID = 2,
            Name = "Stripe",
            GremlinType = GremlinType.King
        };

        var rndGremlin = new Gremlin
        {
            ID = 3,
            Name = "Random",
            GremlinType = GremlinType.Minion
        };

        System.Console.WriteLine("How do we add? (Enqueue)");

        System.Console.WriteLine($"{stripe.Name} is first in line.");
        gremlinQueue.Enqueue(stripe);

        System.Console.WriteLine("Enqueue another gremlin");
        System.Console.WriteLine($"{rndGremlin.Name} is Second in line.");
        gremlinQueue.Enqueue(rndGremlin);

        System.Console.WriteLine("See the total Collection? .Count()");
        System.Console.WriteLine(gremlinQueue.Count());

        foreach (Gremlin g in gremlinQueue)
        {
            System.Console.WriteLine($"{g.ID} - {g.Name}");
        }


        System.Console.WriteLine("How do we Remove from the Queue? .Dequeue()");
        gremlinQueue.Dequeue(); //removes Gremlin

        foreach (Gremlin g in gremlinQueue)
        {
            System.Console.WriteLine($"{g.ID} - {g.Name}");
        }


        System.Console.WriteLine("We have the ability to see the next member 'in line' .Peek()");
        Gremlin nextInLine = gremlinQueue.Peek();

        System.Console.WriteLine(nextInLine.Name);

        System.Console.WriteLine("YOU CANNOT ACCESS THIS COLLECTION BY INDEX => gremlinInQueue[1]");
        //! var grabbedData = gremlinQueue[1];
    }
    private bool Quit()
    {
        System.Console.WriteLine("Thx, press any key!");
        Console.ReadKey();
        return false;
    }
}