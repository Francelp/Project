using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoListProject;
using System.Collections.ObjectModel;

namespace TestsToDo
{
    /// <summary>
    /// Summary description for AddTest
    /// </summary>
    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void Test_AddToList_AddsToListOfItems_WhenGivenObjectToAdd()
        {
            //Arrange
            ViewModel viewModel = new ViewModel();
            ObservableCollection<ToDoItem> list = new ObservableCollection<ToDoItem>();
            //; = new ObservableCollection<ToDoItem>();

            //Act
            viewModel.addToList.Execute(null);

            //Assert
            Assert.IsNotNull(viewModel);
        }
    }
}
