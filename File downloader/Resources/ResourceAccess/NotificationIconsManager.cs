﻿using System.Windows;
using System.Windows.Media;

namespace File_downloader.Resources.ResourcesAccess

{
    static class NotificationIconsManager
    {
        public static ImageBrush PositiveIcon => Application.Current.Resources["CheckMarkCircle"] as ImageBrush ?? new ImageBrush();
        public static ImageBrush NeutralIcon => Application.Current.Resources["EmptyCircle"] as ImageBrush ?? new ImageBrush();
        public static ImageBrush NegativeIcon => Application.Current.Resources["CrossCircle"] as ImageBrush ?? new ImageBrush();
    }
}
