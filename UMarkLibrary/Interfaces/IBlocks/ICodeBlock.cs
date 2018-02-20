namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface ICodeBlock : IMarkdownBlock
    {
        string CodeText { get; }
    }
}
