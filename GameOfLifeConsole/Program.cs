using GameOfLifeConsole;
using System;
using System.Threading;

class GameOfLife
{

    public static void Main()
    {
        Grid grid = new Grid(20);
        //TODO: Users choose dimesions of grid
        //TODO: Users choose the speed of the simulation

        while (true)
        {
            Console.Clear();
            grid.DrawGrid();
            grid.UpdateGrid();
            Thread.Sleep(100);
        }
    }
}
