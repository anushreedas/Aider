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
using System.ComponentModel;
using System.Collections.Specialized;

namespace Aider.View
{
    /// <summary>
    /// Interaction logic for CreateThreadPage.xaml
    /// </summary>
    public partial class CreateThreadPage
    {
        /*  private ObservableCollection<Item> mItems;
          private HashSet<Item> mCheckedItems;

          public IEnumerable<Item> Items { get { return mItems; } }

          public string Text
          {
              get { return _text; }
              set { Set(ref _text, value); }
          }
          private string _text;

          public event PropertyChangedEventHandler PropertyChanged;

          public CreateThreadPage()
          {
              mItems = new ObservableCollection<Item>();
              mCheckedItems = new HashSet<Item>();
              mItems.CollectionChanged += Items_CollectionChanged;

              // Adding test data
              for (int i = 0; i < 10; ++i)
              {
                  mItems.Add(new Item(string.Format("Item {0}", i.ToString("00"))));
              }
          }
          private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
          {
              if (e.OldItems != null)
              {
                  foreach (Item item in e.OldItems)
                  {
                      item.PropertyChanged -= Item_PropertyChanged;
                      mCheckedItems.Remove(item);
                  }
              }
              if (e.NewItems != null)
              {
                  foreach (Item item in e.NewItems)
                  {
                      item.PropertyChanged += Item_PropertyChanged;
                      if (item.IsChecked) mCheckedItems.Add(item);
                  }
              }
              UpdateText();
          }

          private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
          {
              if (e.PropertyName == "IsChecked")
              {
                  Item item = (Item)sender;
                  if (item.IsChecked)
                  {
                      mCheckedItems.Add(item);
                  }
                  else
                  {
                      mCheckedItems.Remove(item);
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
                      Text = mCheckedItems.First().Name;
                      break;
                  default:
                      Text = "<multiple>";
                      break;
              }
          }

      }

          internal class Item : ObservableObject
          {
              public string Name { get; private set; }

              public bool IsChecked
              {
                  get { return _isChecked; }
                  set { Set(ref _isChecked, value); }
              }
              private bool _isChecked;

              public Item(string name)
              {
                  Name = name;
              }

              public override string ToString()
              {
                  return Name;
              }


      }






      */
        public CreateThreadPage()
        {
            InitializeComponent();

            List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });
            ListOfUsers.ItemsSource = mylist;
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
    }
}

