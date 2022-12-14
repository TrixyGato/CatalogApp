using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalogApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public List<User> DatabaseUsers { get; private set; }

    public MainWindow()
    {
      InitializeComponent();
    }

    public void Create() 
    {
      using (DataContext context = new DataContext())
      {
        var name = NameTextBox.Text;
        var address = AddressTextBox.Text;


        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(address))
        {
          context.Users.Add(new User { Name = name, Address = address });
          context.SaveChanges();
          Read();
        }
        
      }
    }

    public void Read() 
    {
      using (DataContext context = new DataContext())
      {
        DatabaseUsers = context.Users.ToList();
        ItemList.ItemsSource = DatabaseUsers;
      }
    }

    public void Update() 
    {
      using (DataContext context = new DataContext())
      {
        User selectedUser = ItemList.SelectedItem as User;

        var name = NameTextBox.Text;
        var address = AddressTextBox.Text;


        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(address))
        {
          User user = context.Users.Find(selectedUser.Id);
          user.Name = name;
          user.Address = address;

          context.SaveChanges();
          Read();
        }

      }
    }

    public void Delete() 
    {
      using (DataContext context = new DataContext())
      {
        User selectedUser = ItemList.SelectedItem as User;

        if (selectedUser != null) 
        {
          User user = context.Users.Find(selectedUser.Id);

          context.Remove(user);
          context.SaveChanges();
          Read();
        }      
      }

    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
      Create();
    }

    private void ReadButton_Click(object sender, RoutedEventArgs e)
    {
      Read();
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
      Update();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
      Delete();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      ItemList.Items.Clear();
    }
  }
}
