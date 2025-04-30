using Labo_7___Polymorphism.Data;
using Labo_7___Polymorphism.Entities;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Labo_7___Polymorphism;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private Store<Machine> _dataStore = new Store<Machine>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ImportButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "CSV bestanden|*.csv";
        ofd.InitialDirectory = Environment.CurrentDirectory;

        if (ofd.ShowDialog() == true)
        {
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                //Eerste Readline om de headers te skippen. Regel wordt gelezen en er wordt niks mee gedaan.
                sr.ReadLine();

                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(",");

                    Machine machine = null;

                    switch (values[0])
                    {
                        case "L": //Laser
                            machine = new LaserCutter(values[1], 
                                double.Parse(values[2]),
                                double.Parse(values[3]),
                                double.Parse(values[4]),
                                double.Parse(values[5]));
                            break;

                        case "R": //Router
                            machine = new Router(values[1],
                                double.Parse(values[2]),
                                double.Parse(values[3]),
                                double.Parse(values[4]));
                            break;

                        case "G": //General
                            machine = new General(values[1]);
                            break;
                    }

                    if (machine is not null) 
                    { 
                        _dataStore.AddItem(machine);
                    }
                }
            }

            UpdateListBox();

            clearButton.IsEnabled = true;
            sortButton.IsEnabled = true;
            filterButton.IsEnabled = true;
        }
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UseButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void FilterButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void itemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UpdateListBox()
    {
        itemsListBox.Items.Clear();

        foreach (Machine machine in _dataStore.GetAllItems())
        {
            itemsListBox.Items.Add(machine);
        }

        useButton.IsEnabled = false;
        removeButton.IsEnabled = false;
    }
}