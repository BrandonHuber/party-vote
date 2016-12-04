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
    enum BallotTypes
    {
        FirstPastThePost
    }

    abstract class Ballot
    {
        public bool IsCompleted { get; set; }
    }

    class FppBallot : Ballot
    {
        List<FppCandidate> candidates = new List<FppCandidate>();

        public FppBallot(List<string> candidateNames)
        {
            foreach (string name in candidateNames)
            {
                candidates.Add(new FppCandidate(name));
            }
        }

        public Dictionary<string, int> CalculateResults(List<FppBallot> ballots) // TODO: Should override?
        {
            var votes = new Dictionary<string, int>();

            foreach (Ballot ballot in ballots)
            {
                foreach (FppCandidate candidate in candidates)
                {
                    if (candidate.isSelected)
                    {
                        votes[candidate.name]++;
                    }
                }
            }

            return votes;
        }
    }
}