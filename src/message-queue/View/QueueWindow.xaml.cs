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
using System.Windows.Shapes;

namespace message_queue.View
{
    /// <summary>
    /// Interaction logic for QueueWindow.xaml
    /// </summary>
    public partial class QueueWindow : Window
    {
        public QueueWindow()
        {
            InitializeComponent();
        }

        private void onPrevious(object sender, RoutedEventArgs e)
        {
            var pageIndex = int.Parse(this.PageIndex.Content.ToString());
            pageIndex--;
            this.PageIndex.Content = pageIndex;
        }

        private void onNext(object sender, RoutedEventArgs e)
        {
            var pageIndex = int.Parse(this.PageIndex.Content.ToString());
            pageIndex++;
            this.PageIndex.Content = pageIndex;
        }
    }
}
