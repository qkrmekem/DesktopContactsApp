﻿using DesktopContactsApp.Classes;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            // 다이얼로그가 닫혀야만 아래의 로직이 수행되므로 에러가 발생하지 않음
            ReadDatabase();
        }

        void ReadDatabase()
        {
            List<Contact> contacts;
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                // var을 사용하는 경우 변수에 값을 바로 할당할 때에만 사용 가능
                // var contacts = conn.Table<Contact>().ToList();
                contacts = conn.Table<Contact>().ToList();
            }

            if(contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }
    }
}