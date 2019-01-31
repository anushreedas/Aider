using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Aider.Model;


namespace Aider.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ThreadModel model = new ThreadModel();

       // public event PropertyChangedEventHandler PropertyChanged;

        
        public MainWindow()
        {
            InitializeComponent();
            
            CurrentUser usr = new CurrentUser() { CompanyName="MET ISDR", CurrentUserName="Anushree Das", CurrentUserProfilePhoto="/images/pic2.jpg" };
            this.CurrentUserInfo.DataContext = usr;

            /*List<Thread> threadslist = new List<Thread>();
            threadslist.Add(new Thread() { ThreadName = "Development", NoOfNewMsgs = 42 });
            threadslist.Add(new Thread() { ThreadName = "Sales", NoOfNewMsgs = 39 });
            threadslist.Add(new Thread() { ThreadName = "Marketing", NoOfNewMsgs = 13 });
            ThreadsList.ItemsSource = threadslist;
            */
            //Threads.CollectionChanged += Items_CollectionChanged;
            //ThreadsList.ItemsSource = threadlist;
            
        List<DirectMsg> directmsgslist = new List<DirectMsg>();
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic1.jpg", UserName = "White Walker", NoOfNewMsgs2 = 4 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic2.jpg", UserName = "Melisandre", NoOfNewMsgs2 = 0 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic3.jpg", UserName = "Daenarys", NoOfNewMsgs2 = 2 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic4.jpg", UserName = "Tywin", NoOfNewMsgs2 = 1 });
            DirectMessages.ItemsSource = directmsgslist;
        }

/*
        public IEnumerable<Thread> Threads
        {
            set {; }
            get { return model.ReadThreads(); }
        }

        public List<string> threadlist
        {
            get
            {
                List<string> tn = new List<string>();
                foreach (Thread t in Threads)
                    tn.Add(t.Name.ToString());
                return tn;
            }
        }

    */
        public class DirectMsg
        {
            public string ProfilePhoto { get; set; }
            public string UserName { get; set; }

            public int NoOfNewMsgs2 { get; set; }

        }

        public class CurrentUser
        {
            public string CompanyName { get; set; }
            public string CurrentUserName { get; set; }
            public string CurrentUserProfilePhoto { get; set; }
        }

        private void CreateThread_Click(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = MainFrame;
            
            if (pageFrame != null)
                pageFrame.Source = new Uri("CreateThreadPage.xaml", UriKind.Relative);
        }

        private void Scroller_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
                e.Handled = true;
            
        }

        private void RefreshThreadsList_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
