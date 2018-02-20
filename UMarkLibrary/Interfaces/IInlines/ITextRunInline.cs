using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarkLibrary.Interfaces.IInlines
{
    internal interface ITextRunInline : IMarkdownInline
    {
        string Text { get; }
    }
}
