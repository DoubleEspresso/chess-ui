﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epdTester
{
    public partial class MoveList : UserControl
    {
        public MoveList()
        {
            InitializeComponent();
            mList.Clear();
        }

        /*todo : link highlight/inserting/next/backward key events with node class*/
        //public bool AddMove(Position2 p)
        //{
        //    // todo : fixme -- Node & ChessGame class will replace the Positions array
        //    // contained in Position2.cs .. so that minimal changes happen here .. 
        //    // and maybe rename Position2.cs as ChessGame or similar
        //    // also - position2.cs info class should have a method/member for sanMove.
        //    //int idx = p.displayIdx;
        //    //Position2.Info i = p.History[idx][0];
        //    //int f = i.From(); int t = i.To();
        //    //string sanmv = p.toSan(Position2.SanSquares[f] + Position2.SanSquares[t]);

        //    //Node n = new Node();
        //    //if (!n.set(i)) return false;
        //    //game.insert(n);

        //    //return appendMove(sanmv, 0, idx);
        //}


        public bool highlightMove(int c, int idx)
        {
            string idxString = Convert.ToString(idx / 2 + 1) + ".";
            int sidx = mList.Text.IndexOf(idxString) + idxString.Length; int eidx = -1;
            if (sidx < 0) return false;
            int count = 0;
            while ((sidx + count < mList.Text.Length) && mList.Text[sidx + count] != ' ') ++count;
            if (c == 0) eidx = sidx + count;
            else
            {
                sidx += count + 1; // move 1 past the ' ' character
                count = 0;
                while ((sidx + count < mList.Text.Length) && mList.Text[sidx + count] != ' ') ++count;
                eidx = sidx + count;
            }
            if (sidx < 0 || sidx > mList.Text.Length) return false; // do not update the highlighted text
            if (eidx <= sidx || eidx > mList.Text.Length ) return false;
            mList.SelectionStart = sidx;
            mList.SelectionLength = eidx - sidx;
            return true;
        }
        public bool appendMove(string m, int c, int idx)
        {
            try
            {
                string entry = " ";
                if (c == 0) entry += Convert.ToString(idx/2 + 1) + ".";
                mList.Text += entry + m;
            }
            catch (Exception any)
            {
                Log.WriteLine("..[MoveList] exception {0}", any.Message);
                return false;
            }
            return true;
        }
    }
}
