using KomodoCafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTest
{
    [TestClass]
    public class CafePattern_Test
    {
        
        public class MenuTest
        {
            [TestMethod]
            public void SetTitle_ShouldSetCorrectString()
            {
                
                //Arrange
                Menu item = new Menu();
                item.MealName = "MeatLoaf";

                //Act
                string expected = "MeatLoaf";
                string actual = item.MealName;


                //Assert
                Assert.AreEqual(expected, actual);



            }
        }

    }
}
