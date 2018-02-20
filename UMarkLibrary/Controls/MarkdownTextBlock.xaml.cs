using System.Collections.Generic;
using System.Diagnostics;
using UMarkLibrary.Display;
using UMarkLibrary.Parse;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

// 参照 Demo ：
// textblock.SelectionHighlightColor = new SolidColorBrush(Colors.Blue);
// textblock.SelectAll();
// Debug.WriteLine("offset:" + textblock.SelectionStart.Offset + " " + textblock.SelectionEnd.Offset);
// Debug.WriteLine("position" + textblock.SelectionStart.GetCharacterRect(LogicalDirection.Forward).Left + " "
//      + textblock.SelectionEnd.GetCharacterRect(LogicalDirection.Forward).Left);

namespace UMarkLibrary
{
    public sealed partial class MarkdownTextBlock : UserControl
    {
        public MarkdownTextBlock()
        {
            this.InitializeComponent();
            RegisterPropertyChangedCallback(FontSizeProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(BackgroundProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(BorderBrushProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(BorderThicknessProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(CharacterSpacingProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(FontFamilyProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(FontSizeProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(FontStretchProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(FontStyleProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(FontWeightProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(ForegroundProperty, OnPropertyChanged);
            RegisterPropertyChangedCallback(PaddingProperty, OnPropertyChanged);
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
            typeof(MarkdownTextBlock),
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
            typeof(MarkdownTextBlock),
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
            if (d is MarkdownTextBlock instance)
                instance.OnPropertyChanged(d, e.Property);
        }

        private void OnPropertyChanged(DependencyObject d, DependencyProperty property)
        {
            if (MarkdownText == null || MarkdownText == "") return;
            MarkdownDocument Document = new MarkdownDocument(MarkdownText);
            XamlRenderer renderer = new XamlRenderer();
            Content = renderer.Render(Document);
        }
    }
}
