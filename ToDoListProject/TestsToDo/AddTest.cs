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
    ViewModel viewModel;

    [TestInitialize]
    public void Setup()
    {
      viewModel = new ViewModel();
    }

        [TestMethod]
    public void Test_Complete_SelectedItemKeptTrue_WhenItIsTrue()
        {
            //Arrange
      viewModel.toDoItemList.Add(new ToDoItem("", true));
      viewModel.selectedItemToDo = new ToDoItem("", true);

      //Act
      viewModel.complete.Execute(null);

      //Assert
      Assert.IsTrue(viewModel.selectedItemToDo.changed);
    }
    [TestMethod]
    public void Test_Complete_ChangesSelectedItemChangedToTrue_WhenItIsFalse()
    {
      //Arrange
      viewModel.toDoItemList.Add(new ToDoItem("", true));
      viewModel.selectedItemToDo = new ToDoItem("", false);

            //Act
      viewModel.complete.Execute(null);

      //Assert
      Assert.IsTrue(viewModel.selectedItemToDo.changed);
    }
    [TestMethod]
    public void Test_Complete_DoesntChangeIfNothingSelected()
    {
      //Arrange

      //Act
      viewModel.complete.Execute(null);

            //Assert
      Assert.IsNull(viewModel.selectedItemToDo);
    }
    [TestMethod]
    public void Test_CanComplete_ReturnsTrue_WhenCalled()
    {
      //Arrange
      //Act
      bool actualValue = viewModel.complete.CanExecute(null);
      //Assert
      Assert.IsTrue(actualValue);
        }
    [TestMethod]
    public void Test_RemoveFromList_ReturnsTrue_WhenItemIsInTheList()
    {
        //Arrange
        ToDoItem todoItem = new ToDoItem("washing", false);
        viewModel.toDoItemList.Add(todoItem);
        //Act
        bool actualValue = viewModel.toDoItemList.Contains(todoItem);
        //Assert
        Assert.IsTrue(actualValue);
    }
    [TestMethod]
    public void Test_RemoveFromList_Returnsfalse_WhenItemIsNotTheList()
    {
        //Arrange
        ToDoItem todoItem = new ToDoItem("Partying", false);
        ToDoItem notDoingItItem = new ToDoItem("Working", false);
        viewModel.toDoItemList.Add(todoItem);
        //Act
        bool actualValue = viewModel.toDoItemList.Contains(notDoingItItem);
        //Assert
        Assert.IsFalse(actualValue);
    }
    [TestMethod]
    public void Test_RemoveFromList_RemovesItemFromList_WhenAnItemExistsInList()
    {
        //Arrange
        ToDoItem todoItem = new ToDoItem("Working", false);
        viewModel.toDoItemList.Add(todoItem);
        //Act
        bool actualValue = viewModel.toDoItemList.Remove(todoItem);
        //Assert
        Assert.IsTrue(actualValue);
    }
    [TestMethod]
    public void Test_RemoveFromList_DoNotRemovesItemFromList_WhenAnItemDoesNotExistsInList()
    {
        //Arrange
        ToDoItem todoItem = new ToDoItem("Working", false);
        ToDoItem notInTheListItem = new ToDoItem("Working", false);
        viewModel.toDoItemList.Add(todoItem);
        //Act
        bool actualValue = viewModel.toDoItemList.Remove(notInTheListItem);
        //Assert
        Assert.IsFalse(actualValue);
    }
    [TestMethod]
    public void Test_CanRemoveFromList_ReturnsTrue()
    {
        //Arrange
        //Act
        bool actualValue = viewModel.removeFromList.CanExecute(null);
        //Assert
        Assert.IsTrue(actualValue);
    }
    }
}
