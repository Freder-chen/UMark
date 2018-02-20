using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 参照 Demo ：
// https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl

namespace UMarkLibrary
{
    public sealed partial class MarkdownEditBox : UserControl
    {
        public MarkdownEditBox()
        {
            this.InitializeComponent();
        }

        #region Dependency properties

        /// <summary>
        /// Markdown格式文本
        /// </summary>
        public string MarkdownText
        {
            get { return (string)GetValue(MarkdownTextProperty); }
            set { SetValue(MarkdownTextProperty, value); }
        }
        public static readonly DependencyProperty MarkdownTextProperty = DependencyProperty.Register(
            nameof(MarkdownText),
            typeof(string),
            typeof(MarkdownEditBox),
            new PropertyMetadata("", new PropertyChangedCallback(OnPropertyChangedStatic))
        );

        public SolidColorBrush SelectionHighlightColor
        {
            get { return (SolidColorBrush)GetValue(SelectionHighlightColorProperty); }
            set { SetValue(SelectionHighlightColorProperty, value); }
        }
        public static readonly DependencyProperty SelectionHighlightColorProperty = DependencyProperty.Register(
            "SelectionHighlightColor",
            typeof(SolidColorBrush),
            typeof(MarkdownEditBox),
            new PropertyMetadata(
                new SolidColorBrush(Colors.Blue),//Color.FromArgb(255, 30, 30, 30)),
                new PropertyChangedCallback(OnPropertyChangedStatic)
            )
        );

        #endregion Dependency properties

        /// <summary>
        /// Calls OnPropertyChanged.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPropertyChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MarkdownEditBox instance)
                instance.OnPropertyChanged(d, e.Property);
        }

        private void OnPropertyChanged(DependencyObject d, DependencyProperty property)
        {
            if (MarkdownText == null) return;
            TextBlock.MarkdownText = MarkdownText;
        }
    }
}
