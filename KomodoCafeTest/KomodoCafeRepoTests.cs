using KomodoCafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTest
{

    //Add Method 
    [TestClass]
    public class KomodoCafeRepoTests
    {
        private MenuRepo _repo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _item = new Menu(1, "MeatLoaf", MealDiscription.SuperSaving, " Meatloaf with tomatoes, onions and green peppers", 10.99);

            _repo.AddItemsToMenu(_item);


        }

        [TestMethod]
        public void AddItemToList_ShouldGetNotNull()
        {
            // Arrange
            Menu item = new Menu();
            item.MealName = "MeatLoaf";
            MenuRepo repo = new MenuRepo();

            //Act
            repo.AddItemsToMenu(item);
            Menu itemFromDirectory = repo.GetItemByMealName("MeatLoaf");

            //Assert
            Assert.IsNotNull(itemFromDirectory);


        }

        //Update 
        [TestMethod]
        public void UpdateExisitingItem_ShouldReturnTrue()
        {
            // Arrange
            Menu newItem = new Menu(1, "MeatLoaf", MealDiscription.Mostpopular, " Meatloaf with tomatoes, onions and green peppers", 12.99);


            //Act
            bool updateResult = _repo.UpdateExisitingItem("MeatLoaf", newItem);
                       
            //Assert
            Assert.IsTrue(updateResult);

        }

        
        [TestMethod]
        [DataRow("MeatLoaf")]
        [DataRow("BigMac",false)]

        public void UpdateExisitingItem_ShouldMatchFivenBool(string originalItem, bool ShouldUpdate)
        {
            // Arrange
            Menu newItem = new Menu(1, "MeatLoaf", MealDiscription.Mostpopular, " Meatloaf with tomatoes, onions and green peppers", 12.99);


            //Act
            bool updateResult = _repo.UpdateExisitingItem(originalItem, newItem);

            //Assert
            Assert.AreEqual(ShouldUpdate,updateResult);

        }


        //Delete
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveItemFromList(_item.MealName);

            //Asser
            Assert.IsTrue(deleteResult);

        }

    }
}
