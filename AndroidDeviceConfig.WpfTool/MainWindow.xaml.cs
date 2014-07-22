using System;
using System.IO;
using System.Windows.Input;
using AndroidDeviceConfig.WpfTool.Models;
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
            this.DataContext = new DeviceConfigModel(_config);
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
                    this.DataContext = new DeviceConfigModel(_config);
                    path = ofd.FileName;
                }
                catch(Exception ex)
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

            DeviceConfig.SaveConfig(sfd.FileName, ((DeviceConfigModel)DataContext).GetConfig());
        }
    }
}
