﻿using System;
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

namespace Aider.View
{
    /// <summary>
    /// Interaction logic for ThreadInfoPage.xaml
    /// </summary>
    public partial class ThreadInfoPage : Page
    {
        public ThreadInfoPage()
        {
            InitializeComponent();
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
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = null;
                DependencyObject currParent = VisualTreeHelper.GetParent(this);
                while (currParent != null && pageFrame == null)
                {
                    pageFrame = currParent as Frame;
                    currParent = VisualTreeHelper.GetParent(currParent);
                }

                if (pageFrame != null)
                    pageFrame.Source = new Uri("EditThreadInfo.xaml", UriKind.Relative);
            
        }
    }
}
