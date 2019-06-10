using System;
using System.Collections.Generic;
using System.Text;

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

        public string Draw()
        {
            Console.Clear();
            StringBuilder drawResult = new StringBuilder(); ;

            foreach (var column in lifeCells)
            {
                foreach (var cell in column)
                    drawResult.Append(cell.IsAlive ? "*|" : " |");

                drawResult.AppendLine();
            }

            Console.Write(drawResult.ToString());
            return drawResult.ToString();
        }
    }
}
