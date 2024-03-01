using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

public class ErrorDialog : Window
{
  public ErrorDialog()
  {
    InitializeComponent();
  }

  private void InitializeComponent()
  {
    AvaloniaXamlLoader.Load(this);
  }

  private void OK_Click(object sender, EventArgs e)
  {
    Close();
  }
}
