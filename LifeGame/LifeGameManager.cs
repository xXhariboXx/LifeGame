using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class LifeGameManager
    {

        private List<List<LifeCell>> lifeCells;
        private Random randomGenerator;

        public LifeGameManager()
        {
            lifeCells = new List<List<LifeCell>>();
            randomGenerator = new Random();
        }

        public LifeGameManager(int xSize, int ySize)
        {
            randomGenerator = new Random();
            InitializeCells(xSize, ySize);
        }

        public void InitializeCells(int xSize, int ySize)
        {
            lifeCells = new List<List<LifeCell>>();
            for (int i = 0; i < xSize; ++i)
            {
                List<LifeCell> newColumn = new List<LifeCell>();
                lifeCells.Add(newColumn);
                for(int j = 0; j < ySize; ++j)
                {
                    newColumn.Add(new LifeCell(randomGenerator.Next(10) >= 5, ref lifeCells));
                }
            }
        }

        public void CalculateState()
        {
            foreach(var column in lifeCells)
            {
                foreach (var cell in column)
                    cell.CalculateState();
            }
        }

        public void UpdateState()
        {
            foreach (var column in lifeCells)
            {
                foreach (var cell in column)
                    cell.UpdateState();
            }
        }

        public void Draw()
        {
            Console.Clear();

            foreach (var column in lifeCells)
            {
                foreach (var cell in column)
                    Console.Write(cell.IsAlive ? "*|" : " |");

                Console.WriteLine();
            }
        }
    }
}
