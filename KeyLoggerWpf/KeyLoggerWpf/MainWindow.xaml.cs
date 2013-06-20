using KeyLogger.Core;
using KeyLoggerWpf.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;

namespace KeyLoggerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon()
                             {
                                 Icon = new System.Drawing.Icon("spy.ico")
                             };
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;


            DataContext=new KeyLoggerViewModel(new KeyLoggerInstance(new KeyCheker(), new LogSaver()));
        }

        void NotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState==WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }

            if(this.WindowState==WindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }
    }
}
