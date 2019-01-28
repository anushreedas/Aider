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
using System.Windows.Shapes;


namespace Aider.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Thread> threadslist = new List<Thread>();
            threadslist.Add(new Thread() { ThreadName = "Development", NoOfNewMsgs = 42 });
            threadslist.Add(new Thread() { ThreadName = "Sales", NoOfNewMsgs = 39 });
            threadslist.Add(new Thread() { ThreadName = "Marketing", NoOfNewMsgs = 13 });
            ThreadsList.ItemsSource = threadslist;

            List<DirectMsg> directmsgslist = new List<DirectMsg>();
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic1.jpg", UserName = "White Walker", NoOfNewMsgs2 = 4 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic2.jpg", UserName = "Melisandre", NoOfNewMsgs2 = 0 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic3.jpg", UserName = "Daenarys", NoOfNewMsgs2 = 2 });
            directmsgslist.Add(new DirectMsg() { ProfilePhoto = "/images/pic4.jpg", UserName = "Tywin", NoOfNewMsgs2 = 1 });
            DirectMessages.ItemsSource = directmsgslist;
        }

        public class Thread
        {
            public string ThreadName { get; set; }

            public int NoOfNewMsgs { get; set; }

        }   

        public class DirectMsg
        {
            public string ProfilePhoto { get; set; }
            public string UserName { get; set; }

            public int NoOfNewMsgs2 { get; set; }

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
    }
}
