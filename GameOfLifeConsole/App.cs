using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class App
    {
        public void Run()
        {
            InputValidator stringInputValidator = new InputValidator();
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("~Conway's Game of Life~");
                Console.WriteLine("|----Menu-----|");
                Console.WriteLine("| Start       |");
                Console.WriteLine("| Close       |");
                Console.WriteLine("|-------------|\r\n");

                string userMenuChoice = Console.ReadLine().ToLower();
                bool isValidUserChoice = stringInputValidator.ValidateString(userMenuChoice, new[] {"start", "close"} );

                bool isRunning = false;

                if (isValidUserChoice)
                {
                    if (userMenuChoice.Equals("start"))
                    {
                        isRunning = true;
                    }
                    else if (userMenuChoice.Equals("close"))
                    {
                        Environment.Exit(0); //NOTES: or set 'inMenu' to 'false'
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Choice: Please select from the menu options.\r\n");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("How fast would you like the simulation to be?");
                Console.WriteLine("Slow");
                Console.WriteLine("Normal");
                Console.WriteLine("Fast");

                int speed = 500;
                string userSpeedChoice = Console.ReadLine().ToLower();
                isValidUserChoice = stringInputValidator.ValidateString(userSpeedChoice, new[] { "slow", "normal", "fast" });

                if (isValidUserChoice)
                {
                    if (userSpeedChoice.Equals("slow"))
                    {
                        speed = 1000;
                    }
                    else if (userSpeedChoice.Equals("fast"))
                    {
                        speed = 100;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Choice: Please select a speed.\r\n");
                    Thread.Sleep(1000);
                }

                Grid grid = new Grid(20);
                //TODO: Users choose dimesions of grid

                while (isRunning)
                {
                    Console.Clear();
                    grid.DrawGrid();
                    grid.UpdateGrid();
                    Thread.Sleep(speed);
                }
            }
        }
    }
}
