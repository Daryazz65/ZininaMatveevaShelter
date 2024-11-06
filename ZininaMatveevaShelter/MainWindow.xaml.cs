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
using ZininaMatveevaShelter.Model;

namespace ZininaMatveevaShelter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ZininaITPSISDogEntities _context = new ZininaITPSISDogEntities();
        public MainWindow()
        {
            InitializeComponent();
            AnimalsLv.ItemsSource = _context.Journal.ToList();
            ViewCmb.ItemsSource = _context.Journal.ToList();
            ViewCmb.DisplayMemberPath = "Name";
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StartDp.SelectedDate != null && ViewCmb.SelectedIndex != -1 && !string.IsNullOrEmpty(NickNameTb.Text)
                && !string.IsNullOrEmpty(AgeTb.Text) && !string.IsNullOrEmpty(YslTb.Text) && FinishDp.SelectedDate != null)
            {
                Journal journal = new Journal()
                {
                    DateStart = (DateTime)StartDp.SelectedDate,
                    ViewAnimal = ViewCmb.SelectedItem as ViewAnimal,
                    Nickname = NickNameTb.Text,
                    Pasport = (bool)PassCb.IsChecked,
                    Age = Convert.ToInt32(AgeTb.Text),
                    Service = YslTb.Text,
                    DateEnd = (DateTime)FinishDp.SelectedDate
                };
                _context.Journal.Add(journal);
                _context.SaveChanges();
                MessageBox.Show("Животное добавлено.");
                ZininaITPSISDogEntities context = new ZininaITPSISDogEntities();
                AnimalsLv.ItemsSource = context.Journal.ToList();
            }
            else
            {
                MessageBox.Show("Заполните все поля для ввода.");
            }
        }
    }
}
