using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeGame;
using System.Linq;

namespace LifeGameTests
{
    [TestClass]
    public class LifeCellTests
    {
        #region IsAlive_Tests
        [TestMethod]
        public void IsAlive_Dead_Test()
        {
            // Arange
            bool expectedIsAlive = false;

            // Acts
            LifeCell testCell = new LifeCell(false);

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }

        [TestMethod]
        public void IsAlive_Alive_Test()
        {
            // Arange
            bool expectedIsAlive = true;

            // Acts
            LifeCell testCell = new LifeCell(true);

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }
        #endregion

        #region CalculateNeighbours_Tests
        [TestMethod]
        public void CalculateNeighbours_CenterCell_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(1).ElementAt(1);
            PrivateObject privateObject = new PrivateObject(testCell);

            int expectedNeighbours = 3;

            // Act
            int testedNeighbours = Convert.ToInt32(privateObject.Invoke("CalculateNeighbours"));

            // Assert
            Assert.AreEqual(expectedNeighbours, testedNeighbours);
        }

        [TestMethod]
        public void CalculateNeighbours_CornerCell_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(0).ElementAt(0);
            PrivateObject privateObject = new PrivateObject(testCell);

            int expectedNeighbours = 2;

            // Act
            int testedNeighbours = Convert.ToInt32(privateObject.Invoke("CalculateNeighbours"));

            // Assert
            Assert.AreEqual(expectedNeighbours, testedNeighbours);
        }
        #endregion

        #region CalculateState_Tests
        [TestMethod]
        public void CalculateState_ShoudBorn_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(1).ElementAt(1);

            bool expectedIsAlive = true;

            // Act
            testCell.CalculateState();
            testCell.UpdateState();

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }

        [TestMethod]
        public void CalculateState_ShoudDie_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(2).ElementAt(2);

            bool expectedIsAlive = false;

            // Act
            testCell.CalculateState();
            testCell.UpdateState();

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }

        [TestMethod]
        public void CalculateState_ShoudStatyAlive_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(1).ElementAt(1);

            bool expectedIsAlive = true;

            // Act
            testCell.CalculateState();
            testCell.UpdateState();

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }

        [TestMethod]
        public void CalculateState_ShoudStatyDead_Test()
        {
            // Arrange
            List<List<LifeCell>> testLifeCellsMatrix = new List<List<LifeCell>>();
            List<LifeCell> column1 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column1); // 1 alive neighour
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(true, ref testLifeCellsMatrix));
            column1.Add(new LifeCell(false, ref testLifeCellsMatrix));

            List<LifeCell> column2 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column2); // 1 alive neighour
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column2.Add(new LifeCell(true, ref testLifeCellsMatrix));

            List<LifeCell> column3 = new List<LifeCell>();
            testLifeCellsMatrix.Add(column3); // 1 alive neighour
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(false, ref testLifeCellsMatrix));
            column3.Add(new LifeCell(true, ref testLifeCellsMatrix));

            LifeCell testCell = testLifeCellsMatrix.ElementAt(0).ElementAt(1);

            bool expectedIsAlive = false;

            // Act
            testCell.CalculateState();
            testCell.UpdateState();

            // Assert
            Assert.AreEqual(expectedIsAlive, testCell.IsAlive);
        }
        #endregion

        #region UpdateCellState_Tests
        [TestMethod]
        public void UpdateCellState_ShouldDie_Test()
        {
            // Arrange
            LifeCell testCell = new LifeCell(true);
            PrivateObject privateObject = new PrivateObject(testCell);
            privateObject.SetField("shouldDie", true);
            bool expectedIsDead = true;

            // Act
            privateObject.Invoke("UpdateState");

            // Assert
            bool isDead = !Convert.ToBoolean(privateObject.GetProperty("IsAlive"));
            Assert.AreEqual(expectedIsDead, isDead);
        }

        [TestMethod]
        public void UpdateCellState_ShouldStayAlive_Test()
        {
            // Arrange
            LifeCell testCell = new LifeCell(true);
            PrivateObject privateObject = new PrivateObject(testCell);
            privateObject.SetField("shouldDie", false);
            bool expectedIsDead = false;

            // Act
            privateObject.Invoke("UpdateState");

            // Assert
            bool isDead = !Convert.ToBoolean(privateObject.GetProperty("IsAlive"));
            Assert.AreEqual(expectedIsDead, isDead);
        }

        [TestMethod]
        public void UpdateCellState_ShouldBorn_Test()
        {
            // Arrange
            LifeCell testCell = new LifeCell(false);
            PrivateObject privateObject = new PrivateObject(testCell);
            privateObject.SetField("shouldBorn", true);
            bool expectedIsBorn = true;

            // Act
            privateObject.Invoke("UpdateState");

            // Assert
            bool isBorn = Convert.ToBoolean(privateObject.GetProperty("IsAlive"));
            Assert.AreEqual(expectedIsBorn, isBorn);
        }

        [TestMethod]
        public void UpdateCellState_ShouldStayDead_Test()
        {
            // Arrange
            LifeCell testCell = new LifeCell(false);
            PrivateObject privateObject = new PrivateObject(testCell);
            privateObject.SetField("shouldBorn", false);
            bool expectedIsBorn = false;

            // Act
            privateObject.Invoke("UpdateState");

            // Assert
            bool isBorn = Convert.ToBoolean(privateObject.GetProperty("IsAlive"));
            Assert.AreEqual(expectedIsBorn, isBorn);
        }
        #endregion
    }
}
