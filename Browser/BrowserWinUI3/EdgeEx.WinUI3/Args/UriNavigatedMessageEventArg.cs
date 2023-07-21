﻿using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeEx.WinUI3.Args
{
    public class UriNavigatedMessageEventArg
    {
        public string PersistenceId { get; set; }
        public string TabItemName { get; set; }
        public Uri NavigatedUri { get; set; } 
        public string Title { get; set; }
        public IconSource Icon { get; set; }
        public UriNavigatedMessageEventArg(string persistenceId, string tabItemName,  Uri uri, string title, IconSource icon)
        {
            NavigatedUri = uri;
            TabItemName = tabItemName;
            PersistenceId = persistenceId;
            Title = title;
            Icon = icon;
        }
    }
}