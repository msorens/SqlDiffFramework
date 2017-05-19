using System;
using PotterDiffEngine;

namespace SqlDiffFramework
{
    public class PotterDiffAdapter : IDiffList
    {
        private TextLine[] lines;

        public PotterDiffAdapter(string[] data)
        {
            lines = new TextLine[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                lines[i] = new TextLine(data[i]);
            }
        }

        #region IDiffList Members

        public int Count() { return lines.Length; }
        public IComparable GetByIndex(int index) { return lines[index]; }

        #endregion

    }

    class TextLine : IComparable
    {
        public string Line;
        public int _hash;

        public TextLine(string str)
        {
            Line = str;
            _hash = str.GetHashCode();
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return _hash.CompareTo(((TextLine)obj)._hash);
        }

        #endregion
    }
}
