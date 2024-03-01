using System;

namespace TicTacToe.ViewModels
{
  public class GameBoard
  {
    private char[,] board; // Массив для хранения состояния игрового поля
    private int size; // Размер игрового поля

    public GameBoard(int size)
    {
      this.size = size;
      board = new char[size, size];
      InitializeBoard();
    }

    // Инициализация игрового поля
    private void InitializeBoard()
    {
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          board[i, j] = ' '; // Заполняем поле пустыми символами
        }
      }
    }

    // Метод для установки символа на игровое поле
    public bool SetSymbol(int row, int column, char symbol)
    {
      if (row < 0 || row >= size || column < 0 || column >= size || board[row, column] != ' ')
      {
        return false; // Проверяем корректность хода
      }

      board[row, column] = symbol; // Устанавливаем символ на заданную позицию
      return true;
    }

    // Метод для проверки победы
    public bool CheckWin(char symbol)
    {
      // Проверка строк и столбцов
      for (int i = 0; i < size; i++)
      {
        bool winInRow = true;
        bool winInColumn = true;
        for (int j = 0; j < size; j++)
        {
          if (board[i, j] != symbol)
          {
            winInRow = false;
          }
          if (board[j, i] != symbol)
          {
            winInColumn = false;
          }
        }
        if (winInRow || winInColumn)
        {
          return true;
        }
      }

      // Проверка диагоналей
      bool winInDiagonal1 = true;
      bool winInDiagonal2 = true;
      for (int i = 0; i < size; i++)
      {
        if (board[i, i] != symbol)
        {
          winInDiagonal1 = false;
        }
        if (board[i, size - i - 1] != symbol)
        {
          winInDiagonal2 = false;
        }
      }
      if (winInDiagonal1 || winInDiagonal2)
      {
        return true;
      }

      return false; // Нет победы
    }

    // Метод для проверки ничьей
    public bool CheckDraw()
    {
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          if (board[i, j] == ' ')
          {
            return false; // На поле есть пустая клетка, игра продолжается
          }
        }
      }
      return true; // На поле нет пустых клеток, игра окончена как ничья
    }

    // Метод для отображения текущего состояния игрового поля
    public void DisplayBoard()
    {
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          Console.Write(board[i, j] + " ");
        }
        Console.WriteLine();
      }
    }

    public void ResetBoard()
    {
      // Очистка игрового поля
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          board[i, j] = '-';
        }
      }
    }
  }
}
