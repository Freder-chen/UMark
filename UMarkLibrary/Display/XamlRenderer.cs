using System;
using System.Collections;
using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;
using UMarkLibrary.Parse.Inlines;
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
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        // paragraph.Margin = Header1Margin;
                        paragraph.FontSize = 40;
                        // paragraph.FontWeight = Header1FontWeight;
                        break;
                }
                RenderInlines(block.Inlines, paragraph.Inlines);
                var textBlock = CreateOrReuseRichTextBlock(blockUIElementCollection);
                textBlock.Blocks.Add(paragraph);
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
