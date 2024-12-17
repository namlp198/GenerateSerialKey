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

namespace GenerateSerialKey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            passWord.Password = "ndev";
            txtDays.Text = "185";
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            SKGL.Generate generate = new SKGL.Generate();
            generate.secretPhase = passWord.Password.Trim();
            int.TryParse(txtDays.Text.Trim(), out int res);
            txtSerialKey.Text = generate.doKey(res);
        }

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            SKGL.Validate validate = new SKGL.Validate();
            validate.secretPhase = passWord.Password.Trim();
            validate.Key = txtSerialKey.Text;
            tbStatus.Text = "Create date: " + validate.CreationDate + "\r\n" + "Expire date: " + validate.ExpireDate + "\r\n" + "Day Left: " + validate.DaysLeft;
        }
    }
}
