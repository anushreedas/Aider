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
using System.Windows.Media.Animation;
namespace Aider.View
{
    /// <summary>
    /// Interaction logic for MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public MessagePage()
        {
            InitializeComponent();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowRightMenu", SettingsPanel);
            SettingsButton.IsEnabled = false;
        }


        private void CancelSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideRightMenu", SettingsPanel);
            SettingsButton.IsEnabled = true;
        }

        private void ShowHideMenu(string Storyboard, Panel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            pnl.Visibility = System.Windows.Visibility.Visible;
            sb.Begin(pnl);

        }

        private void AttachmentsButton_Click(object sender, RoutedEventArgs e)
        {
            if ((AttachmentsPanel.Visibility == System.Windows.Visibility.Collapsed) || (AttachmentsPanel.Margin == new Thickness(0, 0, 0, -100)))
                ShowHideMenu("sbShowBottomMenu", AttachmentsPanel);
            else
            {
                ShowHideMenu("sbHideBottomMenu", AttachmentsPanel);
            }
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("EditProfilePage.xaml", UriKind.Relative);
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {

            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("ChangePasswordPage.xaml", UriKind.Relative);
        }

        private void ThreadInfoLink_Click(object sender, RoutedEventArgs e)
        {
             Frame pageFrame = null;
                DependencyObject currParent = VisualTreeHelper.GetParent(this);
                while (currParent != null && pageFrame == null)
                {
                    pageFrame = currParent as Frame;
                    currParent = VisualTreeHelper.GetParent(currParent);
                }

                if (pageFrame != null)
                    pageFrame.Source = new Uri("ThreadInfoPage.xaml", UriKind.Relative);
            
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("AboutPage.xaml", UriKind.Relative);

        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            if (pageFrame != null)
                pageFrame.Source = new Uri("Feedback.xaml", UriKind.Relative);

        }
    }

}
