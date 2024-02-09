using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;

namespace Maturitetna;

public partial class Register : Window
{
    private string conn = "Server=localhost;Database=maturitetna;Uid=root;Pwd=root;";
   
    public Register()
    {
        InitializeComponent();
    }

    private void Register_OnClick(object? sender, RoutedEventArgs e)
    {
        string username = Username.Text;
        string password = Password.Text;
        string reenter = Reenter.Text;
        if (string.IsNullOrEmpty(username) ||   string.IsNullOrEmpty(password) || string.IsNullOrEmpty(reenter))
        {
            Username.Text = "";
            Password.Text = "";
            Reenter.Text = ""; 
            error.IsVisible = true;
            return;
        }

        try
        {
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                var sql = "INSERT INTO user(username,password) VALUES (@username, @password)";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    
                    command.ExecuteNonQuery();
                    this.Close();   
                    
                }
               
            }
        }
        catch (Exception exception)
        {
            if (reenter != password)
            {
                Password.Text = "";
                Reenter.Text = "";
            }
            else
            {
                Console.WriteLine(exception);
                throw;   
            }
           
        }
    }
}