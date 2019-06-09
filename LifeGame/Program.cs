using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            LifeGameManager lifeGameManager = new LifeGameManager(10, 10);

            lifeGameManager.Draw();
            for (int i = 0; i < 5; ++i)
            {
                lifeGameManager.CalculateState();
                lifeGameManager.UpdateState();
                lifeGameManager.Draw();
            }
        }
    }
}
