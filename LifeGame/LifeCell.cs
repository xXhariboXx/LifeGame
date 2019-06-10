using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeGame
{
    enum CellState
    {
        Alive,
        Dead
    }

    public class LifeCell
    {
        public bool IsAlive
        {
            get
            {
                return cellState == CellState.Alive;
            }
            private set
            {
                cellState = value == true ? CellState.Alive : CellState.Dead;
            }
        }

        private CellState cellState;
        private bool shouldBorn;
        private bool shouldDie;
        private int x;
        private int y;
        private List<List<LifeCell>> lifeCells;

        public LifeCell()
        {
            IsAlive = false;
            shouldDie = false;
            shouldBorn = false;
            x = 0;
            y = 0;
            lifeCells = new List<List<LifeCell>>();
        }

        public LifeCell(bool isAlive)
        {
            IsAlive = isAlive;
            shouldDie = false;
            shouldBorn = false;
            x = 0;
            y = 0;
            lifeCells = new List<List<LifeCell>>();
        }

        public LifeCell(bool isAlive, ref List<List<LifeCell>> lifeCells)
        {
            IsAlive = isAlive;
            shouldDie = false;
            shouldBorn = false;
            this.lifeCells = lifeCells;
            x = lifeCells.Count - 1;
            y = lifeCells.ElementAt(x).Count;
        }

        public void CalculateState()
        {
            int neighboursAlive = CalculateNeighbours();

            switch (cellState)
            {
                case CellState.Alive:
                    if (neighboursAlive != 2 && neighboursAlive != 3)
                        shouldDie = true;
                    break;
                case CellState.Dead:
                    if (neighboursAlive == 3)
                        shouldBorn = true;
                    break;
            }
        }

        public void UpdateState()
        {
            switch(cellState)
            {
                case CellState.Alive:
                    if (shouldDie)
                        cellState = CellState.Dead;
                    break;
                case CellState.Dead:
                    if (shouldBorn)
                        cellState = CellState.Alive;
                    break;
            }

            shouldDie = false;
            shouldBorn = false;
        }

        private int CalculateNeighbours()
        {
            int neighboursAlive = 0;

            Console.Write("x:{0};y:{1}. State:{2}", x, y, IsAlive ? "Alive" : "Dead");

            for (int i = x - 1; i < x + 2; ++i)
            {
                if (i >= 0 && i < lifeCells.Count)
                {
                    for (int j = y - 1; j < y + 2; ++j)
                    {
                        if (j >= 0 && j < lifeCells.ElementAt(i).Count && !(x == i && y == j))
                        {
                            if (lifeCells.ElementAt(i).ElementAt(j).IsAlive)
                            {
                                ++neighboursAlive;
                                Console.Write(" Neighbor alive. x:{0}, y{1}", i, j);
                            }
                        }
                    }
                }
            }

            Console.Write(" Total neighbours alive: {0}", neighboursAlive);
            Console.WriteLine();

            return neighboursAlive;
        }
    }
}
