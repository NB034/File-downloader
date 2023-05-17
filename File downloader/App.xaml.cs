﻿using File_downloader.ViewModels;
using FileDownloader.Services.Accessories;
using FileDownloader.Services.Models.DownloaderModels;
using FileDownloader.Services.Models.InfoCollectorModels;
using FileDownloader.Services.Models.JournalModels;
using FluentFTP;
using System;
using System.IO;
using System.Windows;

namespace File_downloader
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IInfoCollector infoCollector = ConstructInfoCollector();
            IDownloader downloader = new TestDownloader();
            IJournal journal = new TestJournal();

            NotificationPanel_VM notificationPanel = new NotificationPanel_VM();
            DownloadList_VM downloadList = new DownloadList_VM(notificationPanel, downloader);
            DownloadTab_VM downloadTab = new DownloadTab_VM(notificationPanel, downloadList, infoCollector);
            JournalTab_VM journalTab = new JournalTab_VM(journal, downloader, notificationPanel);

            MainWindow_VM mainViewModel = new MainWindow_VM(notificationPanel, downloadTab, journalTab);
            MainWindow window = new MainWindow { DataContext = mainViewModel };
            window.Show();
        }

        protected IInfoCollector ConstructInfoCollector()
        {
            string fileName = "Log.txt";
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(folder, fileName);

            IUniversalLogger logger = new FtpTxtLogger(path);

            var config = new FtpConfig
            {
                LogHost = true,
                LogUserName = true,
                LogPassword = true,
            };

            IInfoCollector infoCollector = new InfoCollector(logger, config);

            return infoCollector;
        }
    }
}
