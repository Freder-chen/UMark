using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarkLibrary.Interfaces.IBlocks
{
    interface ILinkReferenceBlock : IMarkdownBlock
    {
        string ID { get; }
        string Url { get; }
        string Tooltip { get; }
    }
}
