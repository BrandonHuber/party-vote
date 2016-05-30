using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PartyVote
{
    abstract class Candidate
    {
        public string name { get; set; }
    }

    class FppCandidate : Candidate
    {
        public FppCandidate(string name)
        {
            this.name = name;
            this.isSelected = false;
        }

        public bool isSelected { get; set; }
    }
}