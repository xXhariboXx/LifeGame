using LifeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGameUnitTests
{
    [TestClass]
    public class LifeManagerTests
    {
        #region Init_MatrixSize_Tests
        [TestMethod]
        public void Init_XMatrixSize_Test()
        {
            // Arrange
            LifeGameManager lifeGameManager = new LifeGameManager();
            int expectedXSize = 5;
            PrivateObject privateObject = new PrivateObject(lifeGameManager);

            // Act
            privateObject.Invoke("InitializeCells", 5, 0);

            // Assert
            List<List<LifeCell>> lifeCells = (List<List<LifeCell>>)privateObject.GetField("lifeCells");

            if (lifeCells != null)
                Assert.AreEqual(expectedXSize, lifeCells.Count);
            else
                Assert.Fail();
        }

        [TestMethod]
        public void Init_YMatrixSize_Test()
        {
            // Arrange
            LifeGameManager lifeGameManager = new LifeGameManager();
            int expectedYSize = 5;
            PrivateObject privateObject = new PrivateObject(lifeGameManager);

            // Act
            privateObject.Invoke("InitializeCells", 1, 5);

            // Assert
            List<List<LifeCell>> lifeCells = (List<List<LifeCell>>)privateObject.GetField("lifeCells");

            if (lifeCells != null)
            {
                if (lifeCells.Count == 1)
                    Assert.AreEqual(expectedYSize, lifeCells.ElementAt(0).Count);
                else
                    Assert.Fail();
            }
            else
                Assert.Fail();
        }
        #endregion

        #region Init_CellsCoordinates_Tests
        [TestMethod]
        public void Init_CellsCoordinates_Test()
        {
            // Arrange
            LifeGameManager lifeGameManager = new LifeGameManager();
            PrivateObject privateObjectLGM = new PrivateObject(lifeGameManager);

            // Act
            privateObjectLGM.Invoke("InitializeCells", 5, 5);

            // Assert
            List<List<LifeCell>> lifeCells = (List<List<LifeCell>>)privateObjectLGM.GetField("lifeCells");

            for (int i = 0; i < lifeCells.Count; ++i)
            {
                for (int j = 0; j < lifeCells.ElementAt(i).Count; ++j)
                {
                    PrivateObject privateObjectLC = new PrivateObject(lifeCells.ElementAt(i).ElementAt(j));
                    if (Convert.ToInt32(privateObjectLC.GetField("x")) != i || Convert.ToInt32(privateObjectLC.GetField("y")) != j)
                        Assert.Fail();
                }
            }
        }
        #endregion

        #region Draw_Tests
        [TestMethod]
        public void Draw_Test()
        {
            // Arrange
            LifeGameManager lifeGameManager = new LifeGameManager();
            PrivateObject privateObject = new PrivateObject(lifeGameManager);

            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            privateObject.SetField("lifeCells", testLifeCellsMatrix);

            string expectedString = " |*| |\r\n";

            // Act
            string drawResult = Convert.ToString(privateObject.Invoke("Draw"));

            // Assert
            Assert.AreEqual(expectedString, drawResult);
        }
        #endregion
    }
}
