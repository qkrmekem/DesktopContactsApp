using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Save Contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            // using : IDisposable을 사용하는 객체의 생명주기를 관리할 때 사용하는 키워드
            // 해당 코드 블럭을 벗어나면 IDisposable의 dispose메서드를 자동으로 호출하는데
            // SQLiteConnection의 경우 IDisposable을 구현하고 있어 dispose를 호출할 때 connection.Close()를 수행함
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // 테이블을 생성, 만약 테이블이 이미 존재한다면 추가로 테이블을 생성하지 않고 무시됨
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            // connection.Close();

            Close();
        }
    }
}
