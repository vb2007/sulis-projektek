using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace EletjatekGUI_VB_WPF.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        class MyCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;
            Action action;

            public MyCommand(Action action)
            {
                this.action = action;
            }

            public bool CanExecute(object? parameter)
                => true;

            public void Execute(object? parameter)
                => action();
        }

        public int[] Meretek { get; init; } = Enumerable.Range(5, 16).ToArray();
        public int Rows { get; set; } = 20;
        public int Columns { get; set; } = 20;

        public ICommand CreateNew { get; init; }
        public ICommand Save { get; init; }
        public MainWindow Context { get; set; }

        void CreateNewTable()
        {
            Context.CheckBoxGrid.Children.Clear();
            Context.CheckBoxGrid.Rows = Rows;
            Context.CheckBoxGrid.Columns = Columns;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var checkBox = new CheckBox();
                    Context.CheckBoxGrid.Children.Add(checkBox);
                }
            }
        }

        void SaveTable()
        {
            using var output = new StreamWriter($"Eletjatek_{Context.CheckBoxGrid.Rows}x{Context.CheckBoxGrid.Columns}.txt");

            for (int i = 0; i < Context.CheckBoxGrid.Rows; i++)
            {
                for (int j = 0; j < Context.CheckBoxGrid.Columns; j++)
                {
                    var checkBox = (Context.CheckBoxGrid.Children[i * Context.CheckBoxGrid.Columns + j] as CheckBox)!;

                    output.Write(checkBox.IsChecked ?? true ? '1' : '0');
                }

                output.WriteLine();
            }

            output.Close();
        }

        public MainViewModel()
        {
            CreateNew = new MyCommand(CreateNewTable);
            Save = new MyCommand(SaveTable);
        }
    }
}
