using savichev27pr.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace savichev27pr.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        AfishaContext afisha;
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach(var item in AllKinoteatrs)
            {
                kinoteatrs.Items.Add(item.Name);
            }
            kinoteatrs.Items.Add("Выберите...");

            if (afisha != null)
            {
                this.afisha = afisha;
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.Id ==  afisha.IdKinoteatr);
                name.Text = afisha.Name;
                date.Text = afisha.Time.ToString("yyyy-MM-dd");
                time.Text = afisha.Time.ToString("HH:mm");
                price.Text = afisha.Price.ToString();
                bthAdd.Content = "Изменить";
            }
            else
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            TimeSpan timeAfisha;
            int pprice = -1
            if (name.Text == "")
            {
                MessageBox.Show("Не заполнено наименоваие");
                return;
            }
            if (kinoteatrs.SelectedIndex  == kinoteatrs.Items.Count-1)
            {
                MessageBox.Show("Выберите кинотеатр");
                return;
            }
            if (date.Text == "")
            {
                MessageBox.Show("Не заполнена дата");
                return;
            }
            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha)==false)
            {
                MessageBox.Show("Не заполнено время");
                return;
            }
            if (price.Text == "" || int.TryParse(price.Text, out pprice) == false)
            {
                MessageBox.Show("Не заполнена стоиомсть");
                return;
            }
            
            if(this.afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                    0,
                    kinoteatrs.SelectedItem,
                    countZalInt,
                    countInt);
                newKinoteatr.Add();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                kinoteatr = new KinoteatrContext(
                    kinoteatr.Id,
                    name.Text,
                    countZalInt,
                    countInt);
                kinoteatr.Update();
                MessageBox.Show("Запись успешно обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Main());
        }
    }
}
