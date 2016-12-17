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
    public class RankedCandidate
    {
        public RankedCandidate(string name, int strength=0)
        {
            this.Name = name;
            this.Strength = strength;
        }

        public string Name { get; set; }
        public int Strength { get; set; }
    }
}