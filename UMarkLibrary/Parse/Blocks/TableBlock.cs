using System;
using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class TableBlockItem
    {
        TableBlockItem(string markdownText, int start, int length, int row, int col)
        {
            _row = row;
            _col = col;
            Parse(markdownText, start, length);
        }

        private int _row;        
        public int Row => _row;

        private int _col;
        public int Col => _col;

        private IList<MarkdownBlock> _blocks;
        public IList<MarkdownBlock> Blocks => _blocks;

        private void Parse(string markdownText, int start, int length)
        {
            _blocks = Common.ParseBlocks(markdownText, start, length);
        }
    }

    public class TableBlock : MarkdownBlock, ITableBlock
    {
        public TableBlock(string markdownText, int start, int length) : base(MarkdownBlockType.Table)
        {
            Parse(markdownText, start, length);
        }

        private IList<TableBlockItem> _items;
        public IList<TableBlockItem> Items => _items;

        private void Parse(string markdownText, int start, int length)
        {
            _items = ParseTableItems(markdownText, start, length);
        }

        private static IList<TableBlockItem> ParseTableItems(string markdownText, int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}
