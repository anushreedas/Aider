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
using System.Collections.ObjectModel;
using Aider.Model;
using System.ComponentModel;
using System.Collections.Specialized;
using Aider.ViewModel;

namespace Aider.View
{
    /// <summary>
    /// Interaction logic for CreateThreadPage.xaml
    /// </summary>
    public partial class CreateThreadPage : Page
    {
        private ObservableCollection<Employee> mItems;
        private ObservableCollection<Employee> mCheckedItems;
        public IEnumerable<Employee> Items { get { return mCheckedItems; } }


        public CreateThreadPage()
        {
            InitializeComponent();

            mItems = new ObservableCollection<Employee>();
            mCheckedItems = new ObservableCollection<Employee>();
            mItems.CollectionChanged += Items_CollectionChanged;
            
            ListOfUsers.ItemsSource = mItems;
            MembersList.ItemsSource = Items;
            // Adding test data
            for (int i = 0; i < 10; ++i)
            {
                mItems.Add(new Employee(string.Format("Item {0}", i.ToString("00"))));
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }



        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed");
            if (e.OldItems != null)
            {
                foreach (Employee item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                    mCheckedItems.Remove(item);
                    Console.WriteLine("Removed" + item.Name);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Employee item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                    if (item.IsChecked) mCheckedItems.Add(item);
                    Console.WriteLine("Added" + item.Name);
                }
            }
            UpdateText();
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Item Property Changed");
            if (e.PropertyName == "IsChecked")
            {
                Employee item = (Employee)sender;
                if (item.IsChecked)
                {
                    mCheckedItems.Add(item);
                    Console.WriteLine(item.Name);
                }
                else
                {
                    mCheckedItems.Remove(item);
                    Console.WriteLine(item.Name);
                }
                UpdateText();
            }
        }

        private void UpdateText()
        {

            switch (mCheckedItems.Count)
            {
                case 0:
                    Text = "<none>";
                    break;
                case 1:
                    Text = "";
                    break;
                default:
                    Text = "<multiple>";
                    break;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("MessagePage.xaml", UriKind.Relative);
        }

        public class CreateThread
        {
            public string ThreadName { get; set; }
            public string Description { get; set; }
            public bool IsPrivate { get; set; }
            public List<string> Members { get; set; }
        }
        private List<string> mem;

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Thread Created");
            mem = new List<string>();
            if (mCheckedItems.Count == 0) mCheckedItems = mItems;
            foreach (Employee x in mCheckedItems)
            { mem.Add(x.Name);  }
            new CreateThread() { ThreadName = ThreadName_TextBox.Text, Description = ThreadDescription_TextBox.Text, IsPrivate = true, Members = mem };

            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("MessagePage.xaml", UriKind.Relative);
            
        }
        
    }
}