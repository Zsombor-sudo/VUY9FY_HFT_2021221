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
using VUY9FY_HFT_20212202.WPF.ViewModels;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_20212202.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ArtistWindow.xaml
    /// </summary>
    public partial class ArtistWindow : Window
    {
        public ArtistWindow(song song)
        {
            InitializeComponent();
            this.DataContext = new ArtistWindowViewModel();
            (this.DataContext as ArtistWindowViewModel).Setup(song);
        }
    }
}
