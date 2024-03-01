using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
  public class GameBoardView : Window
  {
    private GameLogic gameLogic;

    public GameBoardView()
    {
      InitializeComponent();
      gameLogic = new GameLogic(3); // Создаем экземпляр класса GameLogic с размером поля 3x3
      UpdateCurrentPlayerText(); // Обновляем текстовое поле для отображения текущего игрока
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    // Обработчик события нажатия кнопки
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Button button = (Button)sender;
      int row = Grid.GetRow(button);
      int column = Grid.GetColumn(button);

      // Проверяем возможность совершения хода
      if (gameLogic.MakeMove(row, column))
      {
        // Обновляем отображение игрового поля
        UpdateBoard();

        // Проверяем наличие победителя или ничьей
        if (gameLogic.CheckForWinner())
        {
          ShowWinnerDialog($"Победил игрок {gameLogic.GetCurrentPlayerSymbol()}!");
          RestartGame(); // Перезапускаем игру после окончания
        }
        else if (gameLogic.CheckForDraw())
        {
          ShowDrawDialog("Ничья!");
          RestartGame(); // Перезапускаем игру после окончания
        }
        else
        {
          UpdateCurrentPlayerText(); // Обновляем отображение текущего игрока
        }
      }
      else
      {
        ShowDrawDialog("Эта клетка уже занята. Выберите другую.");
      }
    }

    private void ShowWinnerDialog(string message)
    {
      var dialog = new ErrorDialog();
      dialog.Content = message;
      dialog.ShowDialog(this);
    }

    private void ShowDrawDialog(string message)
    {
      var dialog = new ErrorDialog();
      dialog.Content = message;
      dialog.ShowDialog(this);
    }

    // Обновление отображения игрового поля
    private void UpdateBoard()
    {
      // Обновляем текст кнопок согласно состоянию игрового поля
      // Например, можно использовать gameLogic.GetCellValue(row, column) для получения символа в клетке (row, column) и обновить соответствующую кнопку
    }

    // Обновление отображения текущего игрока
    private void UpdateCurrentPlayerText()
    {
      // Обновляем текстовое поле для отображения текущего игрока
      // Например, можно использовать gameLogic.GetCurrentPlayerSymbol() для получения символа текущего игрока и обновить соответствующее текстовое поле
    }

    // Обработчик события нажатия кнопки перезапуска игры
    private void btnRestart_Click(object sender, RoutedEventArgs e)
    {
      RestartGame(); // Перезапускаем игру
    }

    // Метод для перезапуска игры
    private void RestartGame()
    {
      gameLogic.Reset(); // Сбрасываем состояние игры
      UpdateBoard(); // Обновляем отображение игрового поля
      UpdateCurrentPlayerText(); // Обновляем отображение текущего игрока
    }
  }
}
