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

namespace Aider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
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

            if (Storyboard.Contains("Show"))
            {                
                
            }

            if (Storyboard.Contains("Hide"))
            {
                
            }

        }

        private void AttachmentsButton_Click(object sender, RoutedEventArgs e)
        {
            if((AttachmentsPanel.Visibility==System.Windows.Visibility.Collapsed) || (AttachmentsPanel.Margin == new Thickness(0, 0, 0, -100)) )
                ShowHideMenu("sbShowBottomMenu", AttachmentsPanel);
            else
            {
                ShowHideMenu("sbHideBottomMenu", AttachmentsPanel);
            }
        }
    }
}
