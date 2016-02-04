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
using System.IO;

using CefSharp;
using CefSharp.Wpf;
using CefSharp.Wpf.Example.Handlers;

namespace Cloud9_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string cacheLoc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/WebDesk/";
        public MainWindow()
        {
            if (!Directory.Exists(cacheLoc))
            {
                Directory.CreateDirectory(cacheLoc);
            }
            CefSharp.CefSettings settings = new CefSharp.CefSettings();
            settings.CachePath = cacheLoc;
            Cef.Initialize(settings);
            InitializeComponent();
            cefBrowser.LoadingStateChanged += CefBrowser_LoadingStateChanged;
        }

        private void CefBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                //LifeSpanHandler life = new LifeSpanHandler();        
                //cefBrowser.LifeSpanHandler = null;
            });            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
