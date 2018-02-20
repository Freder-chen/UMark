using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface IQuoteBlock : IMarkdownBlock
    {
        IList<MarkdownBlock> Blocks { get; }
    }
}
