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


namespace Aider.View
{
    /// <summary>
    /// Interaction logic for CreateThreadPage.xaml
    /// </summary>
    public partial class CreateThreadPage : Page
    {
        
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
        private ObservableCollection<Employee> mItems;
        private ObservableCollection<Employee> mCheckedItems;
        private ObservableCollection<Employee> MCheckedItems
        {
            get { return mCheckedItems; }
            set { mCheckedItems = value; RaisePropertyChanged("MCheckedItems"); }
        }

        public IEnumerable<Employee> Items { get { return mCheckedItems; } }
        private string _text;

        public string Text
        {
            get { return _text; }
            set {  _text=  value; }
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
                    Console.WriteLine("Removed" + item.Ename);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Employee item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                    if (item.IsChecked) mCheckedItems.Add(item);
                    Console.WriteLine("Added" + item.Ename);
                }
            }
            UpdateText();
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                Employee item = (Employee)sender;
                if (item.IsChecked)
                {
                    mCheckedItems.Add(item);
                    Console.WriteLine(item.Ename);
                }
                else
                {
                    mCheckedItems.Remove(item);
                    Console.WriteLine(item.Ename);
                }
                UpdateText();
            }
        }

        private void UpdateText()
        {
            
            foreach (Employee item in mCheckedItems)
                Members.Text += "\n" + mCheckedItems.ToString();
            switch (mCheckedItems.Count)
            {
                case 0:
                    Text = "<none>";
                    break;
                case 1:
                    Text = mCheckedItems.First().Ename;
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
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        void Handle(CheckBox checkBox)
        {
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;

            // Assign Window Title.
            this.Title = "IsChecked = " + flag.ToString();
            Employee item = new Employee(checkBox.Content.ToString());
                if (item.IsChecked)
                {
                    mCheckedItems.Add(item);
                    Console.WriteLine(item.Ename);
                }
                else
                {
                    mCheckedItems.Remove(item);
                    Console.WriteLine(item.Ename);
                }
            foreach (Employee x in mCheckedItems)
                Members.Text += "\n" + x.Ename;
            //MembersList.ItemsSource = mCheckedItems;
            UpdateText();
            
        }
    }

   
}
