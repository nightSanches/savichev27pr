﻿using savichev27pr.Classes;
using savichev27pr.Models;
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

namespace savichev27pr.Pages.Afisha.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        AfishaContext item;
        Main main;
        public Item(AfishaContext item, Main main)
        {
            InitializeComponent();

            kinoteatrs.Text = AllKinoteatrs.Find(x => x.Id == item.IdKinoteatr).Name;
            name.Text = item.Name;
            date.Text = item.Time.ToString("yyyy-MM-dd");
            time.Text = item.Time.ToString("HH:mm");
            price.Text = item.Price.ToString();
            this.item = item;
            this.main = main;
            
        }

        private void EditRecord(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Afisha.Add(this.item));
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            item.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
