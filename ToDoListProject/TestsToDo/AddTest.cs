using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoListProject;

namespace TestsToDo
{
    /// <summary>
    /// Summary description for AddTest
    /// </summary>
    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void Test_RemoveFromList_RemovesGivenItemFromTheList_WhenTheListHoldsAtLeastOneItem()
        {
            //Arrange
            ViewModel model = new ViewModel();
            //Act
            
                //Assert
            Assert.AreEqual(0, booksInCatalogue.Count);
        }
    }
}
