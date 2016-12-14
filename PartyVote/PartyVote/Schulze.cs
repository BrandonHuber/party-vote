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
    class Schulze
    {
        private List<string> mCandidates = null;
        private int[,] mPairwisePreferences = null;
        private int[,] mStrongestPaths = null;

        public Schulze(List<string> candidates)
        {
            mPairwisePreferences = new int[candidates.Count, candidates.Count];
            candidates.Sort();
            mCandidates = candidates;
        }

        public void AddBallot(Dictionary<string, int> ballot)
        {
            foreach (string candidateX in mCandidates)
            {
                foreach (string candidateY in mCandidates)
                {
                    // Less Than means more preferred (1 is most preferred)
                    if (ballot[candidateX] < ballot[candidateY])
                    {
                        mPairwisePreferences[mCandidates.IndexOf(candidateX), mCandidates.IndexOf(candidateY)]++;
                    }
                }
            }
        }

        public List<string> Ranking
        {
            get
            {
                mStrongestPaths = new int[mCandidates.Count, mCandidates.Count];

                for (int i = 0; i < mCandidates.Count; i++)
                {
                    for (int j = 0; j < mCandidates.Count; j++)
                    {
                        if (i != j)
                        {
                            if (mPairwisePreferences[i, j] > mPairwisePreferences[j, i])
                            {
                                mStrongestPaths[i, j] = mPairwisePreferences[i, j];
                            }
                            else
                            {
                                mStrongestPaths[i, j] = 0;
                            }
                        }
                    }
                }

                for (int i = 0; i < mCandidates.Count; i++)
                {
                    for (int j = 0; j < mCandidates.Count; j++)
                    {
                        if (i != j)
                        {
                            for (int k = 0; k < mCandidates.Count; k++)
                            {
                                if ((i != k) && (j != k))
                                {
                                    mStrongestPaths[j, k] = Math.Max(mStrongestPaths[j, k], Math.Min(mStrongestPaths[j, i], mStrongestPaths[i, k]));
                                }
                            }
                        }
                    }
                }

                // TODO: Find more concise way to sort the candidates
                var ranking = mCandidates.ToList<string>();
                ranking.Sort((x, y) => mStrongestPaths[mCandidates.IndexOf(x), mCandidates.IndexOf(y)].CompareTo(mStrongestPaths[mCandidates.IndexOf(y), mCandidates.IndexOf(x)]));
                ranking.Reverse();
                return ranking;
            }
        }
    }
}
