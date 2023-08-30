using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace ossca;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnScissors_OnClick(object? sender, RoutedEventArgs e)
    {
        PlayGame(Choice.Scissors);
        playerResult.Text = Choice.Scissors.ToString();
    }

    private void BtnRock_OnClick(object? sender, RoutedEventArgs e)
    {
        PlayGame(Choice.Rock);
        playerResult.Text = Choice.Rock.ToString();

    }

    private void BtnPaper_OnClick(object? sender, RoutedEventArgs e)
    {
        PlayGame(Choice.Paper);
        playerResult.Text = Choice.Paper.ToString();

    }

    private void PlayGame(Choice playerChoice)
    {
        Random random = new Random();
        int randomChoice = random.Next(0, 3);
        Choice computerChoice = (Choice)randomChoice;
        computerResult.Text = computerChoice.ToString();

        string result = DetermineWinner(playerChoice, computerChoice);
        gameResult.Content = result;
    }

    private String DetermineWinner(Choice playerChoice, Choice computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return "무승부";
        }else if ((playerChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                  (playerChoice == Choice.Paper && computerChoice == Choice.Rock) ||
                  (playerChoice == Choice.Scissors && computerChoice == Choice.Paper))
        {
            return "Player 승리!";
        }
        else
        {
            return "Computer 승리!";
        }
    }
}

public enum Choice
{
    Rock,
    Paper,
    Scissors
}