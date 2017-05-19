using Algorithm.Diff;
using PotterDiffEngine;

namespace SqlDiffFramework
{

    // converts elements from various difference engines to a canonical form
    public struct DiffChunk
    {
        #region constructor

        public struct Range
        {
            public int Start, End, Count;

            public Range(int Start, int End, int Count)
            {
                this.Start = Start;
                this.End = End;
                this.Count = Count;
            }

            public Range(int Start, int Count)
            {
                this.Start = Start;
                this.Count = Count;
                // By Tauberer convention, End < Start indicates none
                this.End = Count == 0 ? Start - 1 : Start + Count - 1;
            }
        }

        #endregion constructor

        public Range Left, Right;

        // Hertel
        public DiffChunk(int StartA, int StartB, int deletedA, int insertedB)
        {
            Left = new Range(StartA, deletedA);
            Right = new Range(StartB, insertedB);
            //TempDump("H ");
        }

        // Tauberer
        public DiffChunk(Diff.Hunk hunk)
        {
            Left = new Range(hunk.Left.Start, hunk.Left.End, hunk.Left.Count);
            Right = new Range(hunk.Right.Start, hunk.Right.End, hunk.Right.Count);
            //TempDump("T ");
        }

        // Potter
        public DiffChunk(DiffResultSpanStatus status, int length, int StartA, int StartB)
        {
            int CountA = (status == DiffResultSpanStatus.AddDestination ? 0 : length);
            Left = new Range(StartA, CountA);
            int CountB = (status == DiffResultSpanStatus.DeleteSource ? 0 : length);
            Right = new Range(StartB, CountB);
            //TempDump("P ");
        }

        //private void TempDump(string marker)
        //{
        //    Console.WriteLine(marker + "Left[{0}] = {1} to {2}; Right[{3}] = {4} to {5}",
        //        Left.Count, Left.Start, Left.End,
        //        Right.Count, Right.Start, Right.End);
        //}

    }
}
