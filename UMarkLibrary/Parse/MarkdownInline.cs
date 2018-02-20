using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Interfaces;
using Windows.UI.Xaml.Documents;

namespace UMarkLibrary.Parse
{
    public enum MarkdownInlineType
    {
        TextRun,
        Bold,
        Italic,
        MarkdownLink,
        RawHyperlink,
        RawSubreddit,
        Strikethrough,
        Superscript,
        Code,
    };

    public abstract class MarkdownInline : MarkdownElement, IMarkdownInline
    {
        public MarkdownInlineType Type { get { return _type; } }
        private MarkdownInlineType _type;

        internal MarkdownInline(MarkdownInlineType type)
        {
            _type = type;
        }
    }
}
