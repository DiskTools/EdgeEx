﻿using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Webbrowser_winui3.Models;
using Webbrowser_winui3.Services;
using Webbrowser_winui3.ViewModels;
using Windows.Devices.Enumeration;
using System.Xml;
using System.Net;
using Microsoft.UI.Xaml.Media;
using System.Text;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Text.RegularExpressions;
using Sgml;
using Microsoft.UI.Xaml;

namespace Webbrowser_winui3.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class HomePage : Page
{
    ListViewModel listDetailsViewModel = new ListViewModel();
    private string _TabTag = "";
    public HomePage()
    {
        _TabTag = MainViewModel._TagCount.ToString();
        InitializeComponent();
        this.Loaded += (s, e) =>
        {
            HomePageViewModel.InitCommand.Execute(gv);
            foreach(var lines in PageLinks.Children)
            {
                foreach (var links in ((StackPanel)lines).Children)
                {
                    Grid item = links as Grid;

                    string site = (item.Tag as string) ?? "blanks";

                    if (site == "blanks")
                        continue;
                    /*
                    WebClient wc = new WebClient();

                    byte[] downloaddata = wc.DownloadData(site);
                    string codestr = Encoding.GetEncoding("UTF-8").GetString(downloaddata);

                    XmlDocument xd = new XmlDocument();
                    var xml = HtmlToStdXml(codestr);
                    xd.LoadXml(xml);

                    string iconpath = "";
                    foreach (var headitems in xd.DocumentElement["head"])
                    {
                        var node = headitems as XmlElement;
                        if (node.Name != "link")
                            continue;

                        if (node.GetAttribute("rel") != "icon")
                            continue;

                        iconpath = node.GetAttribute("href");
                        break;
                    }

                    item.Background = new ImageBrush
                    {

                        ImageSource = new BitmapImage(new Uri((iconpath.StartsWith("/")) ? site.Split("/")[0] + iconpath : iconpath))
                    };*/
                    item.PointerPressed += (sender, e) =>
                    {
                        /*int index = 0;
                        bool ok = false;
                        MainViewModel._MainPage.tabView.TabItems.ToList().ForEach(e =>
                        {
                            if(!ok)
                            {
                                var item = e as TabViewItem;
                                if (item.Tag == this._TabTag)
                                {
                                    ok = true;
                                    return;
                                }
                                index++;
                            }
                        });

                        var newpage = new WebView2Page();
                        newpage.SetUrl(site);
                        MainViewModel._MainPage.g_frames.Children[index] = newpage;*/
                        MainViewModel.OpenWebPageCommand.Execute(site);
                    };
                    
                }
            }
        };
    }

    private static string HtmlToStdXml(string html)
    {
        SgmlReader sr = new SgmlReader();

        sr.DocType = "HTML";
        sr.InputStream = new StringReader(html);

        StringWriter XMLText = new();
        XmlTextWriter xmlTextWriter = new XmlTextWriter(XMLText);

        while (!sr.EOF)
        {
            xmlTextWriter.WriteNode(sr, true);
        }

        xmlTextWriter.Close();

        string result = XMLText.ToString();
        XMLText.Close();
        sr.Close();
        return result;
    }

    private void GobnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        MainViewModel.OpenWebPageCommand.Execute(tb_url.Text);
    }


    private void Grid_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        var properties = e.GetCurrentPoint(root).Properties;
        if (properties.IsLeftButtonPressed)
        {
            HomePageViewModel.gv_ItemClickCommand.Execute(sender as Grid);
        }
    }

    private void TextBox_KeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            MainViewModel.OpenWebPageCommand.Execute(tb_homeurl.Text);
        }
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        MainViewModel.OpenWebPageCommand.Execute(tb_homeurl.Text);
    }

    private void Grid_Holding(object sender, Microsoft.UI.Xaml.Input.HoldingRoutedEventArgs e)
    {
        HomePageViewModel.RightMenuCommand.Execute(sender as Grid);
    }

    private void Grid_RightTapped(object sender, Microsoft.UI.Xaml.Input.RightTappedRoutedEventArgs e)
    {
        HomePageViewModel.RightMenuCommand.Execute(sender as Grid);
    }

    private void TextBox_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.Background = textBox.Background;
    }

    private void TextBox_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.Background = textBox.Background;
    }

    private void TextBox_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.Background = textBox.Background;
    }
    private void TextBox_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.Background = textBox.Background;
    }
}
