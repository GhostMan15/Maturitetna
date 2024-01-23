using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Maturitetna;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var login = new Login();
        login.Show();
    }

    private void Register_OnClick(object? sender, RoutedEventArgs e)
    {
        var register = new Register();
        register.Show();
    }
}