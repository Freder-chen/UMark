using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UMark
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TextBlock.Loaded += Editor_Loaded;
        }

        private void Editor_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock.MarkdownText = "# Hello\r\n* Hahaha\r\n* List2\r\n";
        }
    }
}
