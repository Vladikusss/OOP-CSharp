using Avalonia.Controls;
using AVTesting.ViewModels;

namespace AVTesting.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        WhateverButton.Content = "Example";

    }
}