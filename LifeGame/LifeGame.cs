namespace LifeGame
{
    class LifeGame
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
