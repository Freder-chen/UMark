using System;
using System.Collections;
using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;
using UMarkLibrary.Parse.Inlines;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace UMarkLibrary
{
    namespace Display
    {
        public class XamlRenderer
        {
            public UIElement Render(MarkdownDocument document)
            {
                var stackPanel = new StackPanel();
                RenderBlocks(document.Blocks, stackPanel.Children);
                return stackPanel;
            }

            #region Block

            private void RenderBlocks(IList<MarkdownBlock> blocks, UIElementCollection blockUIElementCollection)
            {
                foreach (MarkdownBlock block in blocks)
                    RenderBlcok(block, blockUIElementCollection);
            }

            private void RenderBlcok(MarkdownBlock block, UIElementCollection blockUIElementCollection)
            {
                switch (block.Type)
                {
                    case MarkdownBlockType.Paragraph:
                        RenderParagraph((ParagraphBlock)block, blockUIElementCollection);
                        break;
                    case MarkdownBlockType.Header:
                        RenderHeader((HeaderBlock)block, blockUIElementCollection);
                        break;
                    case MarkdownBlockType.ListElement:
                        RenderListElement((ListElement)block, blockUIElementCollection);
                        break;
                }
            }

            private void RenderParagraph(ParagraphBlock block, UIElementCollection blockUIElementCollection)
            {
                var paragraph = new Paragraph();
                RenderInlines(block.Inlines, paragraph.Inlines);
                var textBlock = CreateOrReuseRichTextBlock(blockUIElementCollection);
                textBlock.Blocks.Add(paragraph);
            }

            private void RenderHeader(HeaderBlock block, UIElementCollection blockUIElementCollection)
            {
                var paragraph = new Paragraph();
                switch(block.HeaderLevel)
                {
                    case 1:
                        paragraph.FontSize = 20;
                        paragraph.FontWeight = FontWeights.Bold;
                        break;
                    case 2:
                        paragraph.FontSize = 20;
                        break;
                    case 3:
                        paragraph.FontSize = 17;
                        paragraph.FontWeight = FontWeights.Bold;
                        break;
                    case 4:
                        paragraph.FontSize = 17;
                        break;
                    case 5:
                        paragraph.FontSize = 15;
                        break;
                    case 6:
                    default:
                        paragraph.FontWeight = FontWeights.Bold;
                    break;
                }
                RenderInlines(block.Inlines, paragraph.Inlines);
                var textBlock = CreateOrReuseRichTextBlock(blockUIElementCollection);
                textBlock.Blocks.Add(paragraph);
            }

            private void RenderListElement(ListElement block, UIElementCollection blockUIElementCollection)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var bullet = CreateTextBlock();
                switch (block.Style)
                {
                    case ListStyle.Bulleted:
                        bullet.Text = "•";
                        break;
                    case ListStyle.Numbered:
                        bullet.Text = "•";
                        //bullet.Text = $"{rowIndex + 1}.";
                        break;
                }
                // Add the list item bullet.
                bullet.HorizontalAlignment = HorizontalAlignment.Right;
                bullet.Margin = new Thickness(0, 0, 10, 0);
                Grid.SetColumn(bullet, 0);
                grid.Children.Add(bullet);
                // Add the list item content.
                var content = new RichTextBlock();
                var paragraph = new Paragraph();
                RenderInlines(block.Inlines, paragraph.Inlines);
                content.Blocks.Add(paragraph);
                Grid.SetColumn(content, 1);
                grid.Children.Add(content);

                blockUIElementCollection.Add(grid);
            }

            #endregion Block

            #region Inline

            private void RenderInlines(IList<MarkdownInline> inlines, InlineCollection inlineCollection)
            {
                foreach (MarkdownInline inline in inlines)
                    RenderInline(inline, inlineCollection);
            }

            private void RenderInline(MarkdownInline inline, InlineCollection inlineCollection)
            {
                switch (inline.Type)
                {
                    case MarkdownInlineType.TextRun:
                        RenderTextRun((TextRunInline)inline, inlineCollection);
                        break;
                }
            }

            private void RenderTextRun(TextRunInline inline, InlineCollection inlineCollection)
            {

                Run run = new Run { Text = inline.Text };
                inlineCollection.Add(run);
            }

            #endregion Inline

            private TextBlock CreateTextBlock()
            {
                var result = new TextBlock();
                return result;
            }

            private static RichTextBlock CreateOrReuseRichTextBlock(UIElementCollection blockUIElementCollection)
            {
                if (blockUIElementCollection != null
                && blockUIElementCollection.Count > 0
                && blockUIElementCollection[blockUIElementCollection.Count - 1] is RichTextBlock)
                    return (RichTextBlock)blockUIElementCollection[blockUIElementCollection.Count - 1];

                var result = new RichTextBlock();
                if (blockUIElementCollection != null)
                    blockUIElementCollection.Add(result);
                return result;
            }
        }
    }
}
