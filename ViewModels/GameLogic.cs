using System;

namespace TicTacToe.ViewModels
{
  public class GameLogic
  {
    private GameBoard gameBoard;
    private char currentPlayerSymbol;

    public GameLogic(int boardSize)
    {
      gameBoard = new GameBoard(boardSize);
      currentPlayerSymbol = 'X'; // Начинаем с крестиков
    }

    // Метод для выполнения хода текущего игрока
    public bool MakeMove(int row, int column)
    {
      bool moveSuccessful = gameBoard.SetSymbol(row, column, currentPlayerSymbol);
      if (moveSuccessful)
      {
        currentPlayerSymbol = (currentPlayerSymbol == 'X') ? 'O' : 'X'; // Смена игрока после хода
      }
      return moveSuccessful;
    }

    // Метод для проверки наличия победителя
    public bool CheckForWinner()
    {
      return gameBoard.CheckWin('X') || gameBoard.CheckWin('O');
    }

    // Метод для проверки наличия ничьей
    public bool CheckForDraw()
    {
      return gameBoard.CheckDraw();
    }

    // Метод для отображения текущего состояния игрового поля
    public void DisplayBoard()
    {
      gameBoard.DisplayBoard();
    }

    // Метод для отображения текущего игрока
    public void DisplayCurrentPlayer()
    {
      Console.WriteLine("Ходит игрок: " + currentPlayerSymbol);
    }

    public char GetCurrentPlayerSymbol()
    {
      return currentPlayerSymbol;
    }

    public void Reset()
    {
      // Сброс текущего игрока
      currentPlayerSymbol = 'X'; // или любой другой символ, с которого начинается игра

      // Обнуление игрового поля в классе GameBoard
      gameBoard.ResetBoard();
    }

  }
}
