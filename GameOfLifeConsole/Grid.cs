using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class Grid
    {
        private readonly Random random = new Random();
        private int GridSize { get; set; }
        private bool[,] Cells;

        public Grid(int Gridsize)
        {
            this.GridSize = Gridsize;
            this.Cells = new bool[GridSize, GridSize];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int column = 0; column < GridSize; column++)
                {
                    Cells[row, column] = random.Next(2) == 1; // Randomly set cells to be alive or dead
                }
            }
        }

        public void UpdateGrid()
        {
            bool[,] newGrid = new bool[GridSize, GridSize];

            for (int row = 0; row < GridSize; row++)
            {
                for (int column = 0; column < GridSize; column++)
                {
                    int neighbors = CountNeighbors(row, column);
                    if (Cells[row, column])
                    {
                        newGrid[row, column] = neighbors == 2 || neighbors == 3;
                    }
                    else
                    {
                        newGrid[row, column] = neighbors == 3;
                    }
                }
            }

            Cells = newGrid;
        }

        public int CountNeighbors(int x, int y)
        {
            int count = 0;

            for (int row = -1; row <= 1; row++)
            {
                for (int column = -1; column <= 1; column++)
                {
                    int newX = (x + row + GridSize) % GridSize;
                    int newY = (y + column + GridSize) % GridSize;
                    count += Cells[newX, newY] ? 1 : 0;
                }
            }

            count -= Cells[x, y] ? 1 : 0;

            return count;
        }

        public void DrawGrid()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int column = 0; column < GridSize; column++)
                {
                    Console.Write(Cells[row, column] ? "■" : " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
