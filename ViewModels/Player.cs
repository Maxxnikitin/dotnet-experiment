namespace TicTacToe.ViewModels
{
  public class Player
  {
    public string Name { get; private set; } // Имя игрока
    public char Symbol { get; private set; } // Символ игрока (X или O)

    // Конструктор класса Player
    public Player(string name, char symbol)
    {
      Name = name;
      Symbol = symbol;
    }
  }
}
