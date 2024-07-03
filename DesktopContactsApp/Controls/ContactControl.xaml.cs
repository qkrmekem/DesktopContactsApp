using DesktopContactsApp.Classes;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        // 일반 property
        // Severity	Code	Description	Project	File	Line	Suppression State
        // Error XDG0006	'ContactControl' 형식의 'Contact' 속성에서 'Binding'을(를) 설정할 수 없습니다. 'Binding'은(는) DependencyObject의 DependencyProperty에서만 설정할 수 있습니다.DesktopContactsApp C:\Users\qkrmekem\source\repos\DesktopContactsApp\DesktopContactsApp\MainWindow.xaml	20	
        //private Contact Contact;

        //public Contact Contact
        //{
        //    get { return Contact; }
        //    set { Contact = value; }
        //}

        // 종속성 property
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            // (종속성 프로퍼티 이름, 프로퍼티 타입, 소유하고 있는 클래스 타입, 메타데이터(기본값, 콜백))
            DependencyProperty.Register(
                "Contact", 
                typeof(Contact), 
                typeof(ContactControl), 
                new PropertyMetadata(new Contact() { Name = "Name LastName", Phone = "010 1234 1234", Email = "text@domain.com"}, SetText)
            );

        // 종속성 프로퍼티(여기서는 Contact)가 변경될 때마다 실행될 때마다 실행될 콜백
        // 이벤트 핸들러와 형태는 비슷함
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // 여기서 d는 위에서 DependencyProperty를 Register할 때 지정했던
            ContactControl control = d as ContactControl;

            if(control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
