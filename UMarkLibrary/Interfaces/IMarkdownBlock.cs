using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces
{
    internal interface IMarkdownBlock : IMarkdownElement
    {
        MarkdownBlockType Type { get; }
    }
}
