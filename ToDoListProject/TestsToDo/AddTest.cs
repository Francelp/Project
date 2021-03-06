﻿using System;
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
    ViewModel viewModel;

    [TestInitialize]
    public void Setup()
    {
      viewModel = new ViewModel();
    }

    [TestMethod]
        public void Test_addToList_DoesAddItem_WhenGivenItemToAdd()
        {
            //Arrange

            //Act
            viewModel.addToList.Execute("item");

            //Assert
            Assert.AreEqual("item",viewModel.toDoItemList[0].name );
        }


        [TestMethod]
        public void Test_addToList_DoesNotAdd_WhenGivenNothingToAdd()
        {
            //Arrange
            

            //Act
            viewModel.addToList.Execute("");

            //Assert
            Assert.AreEqual(0,viewModel.toDoItemList.Count);
        }

        [TestMethod]
        public void Test_AddsToListOfItems_WhenGivenObjectToAdd()
    {
      //Arrange
      viewModel.toDoItemList.Add(new ToDoItem("", true));
      viewModel.selectedItemToDo = new ToDoItem("", true);

      //Act
            viewModel.addToList.Execute(null);

            ObservableCollection<ToDoItem> list = new ObservableCollection<ToDoItem>();

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
    [TestMethod]
    public void Test_Convert_ReturnsCompleted_WhenGivenTrue()
    {
      //Arrange
      CompletedConverter converter = new CompletedConverter();
      object expectedValue = "Completed";
      //Act
      object actualValue = converter.Convert(true, null, null, null);
      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_Convert_ReturnsBlank_WhenGivenFalse()
    {
      //Arrange
      CompletedConverter converter = new CompletedConverter();
      object expectedValue = "";
      //Act
      object actualValue = converter.Convert(false, null, null, null);
      //Assert
      Assert.AreEqual(expectedValue, actualValue);

    }
  }
}
