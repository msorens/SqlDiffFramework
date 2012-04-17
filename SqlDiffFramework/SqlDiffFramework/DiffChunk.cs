using Algorithm.Diff;
using PotterDiffEngine;

/*
 * ==============================================================
 * @ID       $Id: DiffChunk.cs 971 2010-09-30 16:09:30Z ww $
 * @created  2008-06-01
 * ==============================================================
 *
 * The official license for this file is shown next.
 * Unofficially, consider this e-postcardware as well:
 * if you find this module useful, let us know via e-mail, along with
 * where in the world you are and (if applicable) your website address.
 */

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MIT License
 *
 * Copyright (c) 2010 Michael Sorens
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * ***** END LICENSE BLOCK *****
 */

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
