using System;
using System.IO;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;

namespace AndroidDeviceConfig.WpfTool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private DeviceConfig _config = new DeviceConfig();
        private string path = String.Empty;
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DeviceConfigViewModel(_config);
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private async void OpenConfig_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files|*.xml";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (File.Exists(ofd.FileName))
            {
                bool failure = false;
                try
                {
                    _config = DeviceConfig.LoadConfig(ofd.FileName);
                    this.DataContext = new DeviceConfigViewModel(_config);
                    path = ofd.FileName;
                }
                catch
                {
                    failure = true;
                }
                if (failure) await this.ShowMessageAsync("Something went wrong", "Config invalid.");
            }
        }

        private void SaveConfig_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "XML Files|*.xml";
            sfd.FileName = path;
            sfd.ShowDialog();

            DeviceConfig.SaveConfig(sfd.FileName, ((DeviceConfigViewModel)DataContext).Model);
        }
    }
}
