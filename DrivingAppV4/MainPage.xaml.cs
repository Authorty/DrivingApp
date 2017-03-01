using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrivingAppV4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SocketClient _socket;

        private string _ipAddress = "IpAddress";
        private string _port = "8080";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            _socket.Send("forward");
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            _socket.Send("backward");
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            _socket.Send("turnleft");
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            _socket.Send("turnright");
        }





        //private void btn_connectClick(object sender, RoutedEventArgs e)
        //{
        //    Connect();
        //}

        private void Connect()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.OnDataRecived -= socket_OnDataRecived;
                _socket = null;
            }
            _socket = new SocketClient(_ipAddress, Convert.ToInt32(_port));
            _socket.Connect();
            _socket.OnDataRecived += socket_OnDataRecived;
        }


        private void socket_OnDataRecived(string data)
        {
            //txbMessageRecived.Text = data;
        }

        //private void btn_upClick(object sender, RoutedEventArgs e)
        //{
        //    _socket.Send("forward");
        //}

        //private void btn_right_Click(object sender, RoutedEventArgs e)
        //{
        //    _socket.Send("turnright");
        //}

        //private void btn_down_Click(object sender, RoutedEventArgs e)
        //{
        //    _socket.Send("backward");
        //}

        //private void btn_left_Click(object sender, RoutedEventArgs e)
        //{
        //    _socket.Send("turnleft");
        //}

        //private void btnSend_Click(object sender, RoutedEvent e)
        //{
        //}
    }
}
