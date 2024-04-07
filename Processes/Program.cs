using System.Diagnostics;
using System.Linq.Expressions;

namespace Processes
{
    class Program
    {
        public Process[] processes = Process.GetProcesses();

        public void PrintMenu()
        {
            Console.WriteLine("1. Start a Process");
            Console.WriteLine("2. List of Processes");
            Console.WriteLine("3. Kill a Process");
            Console.WriteLine("4. Find a Process's Parent");
            Console.WriteLine("0. Exit");
        }

        public void CloseSub()
        {
            Console.WriteLine("Press any Enter to Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public void StartProcess()
        {
            Console.WriteLine("Enter the Process Name or 'b' to Back");
            Console.Write(">> ");
            string choice = Console.ReadLine();
            if (choice == "b")
            {
                return;
            }

            try
            {
                Process.Start(choice);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Process Name! Please Try Again!");
                this.StartProcess();
            }
        }

        public void ProcessList()
        {
            foreach (Process p in this.processes)
            {
                Console.WriteLine("ID: {0}    Name: {1}", p.Id, p.ProcessName);
            }
                Console.WriteLine("--------------------------------------");
        }

        public void KillProcess()
        {
            Console.WriteLine("Enter the Process Name or ID ('b' for Backing)");
            Console.Write(">> ");
            string? choice = Console.ReadLine();
            if (choice == "b")
            {
                return;
            }

            if (choice != null)
            {
                try
                {
                    int processId;
                    if (int.TryParse(choice, out processId))
                    {
                        Process.GetProcessById(processId).Kill();
                    }
                    else
                    {
                        Process[] processes = Process.GetProcessesByName(choice);
                        if (processes.Length == 0)
                            throw new Exception();
                        foreach (Process p in processes)
                            p.Kill();
                    }
                    Console.WriteLine("Done!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Process Not Found! Please Try Again");
                    this.KillProcess();
                }
            }
        }
        
        public void FindParent()
        {
            Console.WriteLine("Comming Soon!");
            this.CloseSub();
        }


        public void Run()
        {
            Console.WriteLine("Welcome! Enter Your Choice (number only)");
            while (true)
            {
                this.processes = Process.GetProcesses();
                Console.Clear();
                this.PrintMenu();
                Console.Write(">> ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        this.StartProcess();
                        break;
                    case "2":
                        this.ProcessList();
                        break;
                    case "3":
                        this.KillProcess();
                        break;
                    case "4":
                        this.FindParent();
                        break;
                    case "0":
                        return;
                    default:
                        break;
                }
                this.CloseSub();
            }
        }

        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}

// Session 2 - To-Do
// input a
// if 1 => start P
// if 2 => list of p
// if 3 => kill p
// if 4 => find parent of p => p.handel