﻿using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WinQuickLook.Handlers
{
    public class HtmlPreviewHandler : PreviewHandlerBase
    {
        public override bool CanOpen(string fileName)
        {
            var extension = (Path.GetExtension(fileName) ?? "").ToLower();

            return ((IList)_supportFormats).Contains(extension);
        }

        public override FrameworkElement GetElement(string fileName)
        {
            var maxWidth = SystemParameters.WorkArea.Width - 100;
            var maxHeight = SystemParameters.WorkArea.Height - 100;

            var webBrowser = new WebBrowser();

            webBrowser.BeginInit();
            webBrowser.Width = maxWidth / 2;
            webBrowser.Height = maxHeight / 2;
            webBrowser.EndInit();

            webBrowser.Navigate(new Uri(fileName, UriKind.Absolute));

            return webBrowser;
        }

        private static readonly string[] _supportFormats =
        {
            ".htm", ".html", ".xhtml"
        };
    }
}
