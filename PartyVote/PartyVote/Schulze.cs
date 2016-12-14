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
        private Dictionary<string, int> mCandidateIds = null;
        private int[,] mPairwisePreferences = null;
        private int[,] mStrongestPaths = null;

        public Schulze(List<string> candidates)
        {
            mCandidateIds = new Dictionary<string, int>();
            mPairwisePreferences = new int[candidates.Count, candidates.Count];
            
            for (int i = 0; i < candidates.Count; i++)
            {
                mCandidateIds[candidates[i]] = i;
            }
        }

        public void AddBallot(Dictionary<string, int> ballot)
        {
            List<string> candidates = ballot.Keys.ToList();

            foreach (string candidateX in candidates)
            {
                foreach (string candidateY in candidates)
                {
                    // Less Than means more preferred (1 is most preferred)
                    if (ballot[candidateX] < ballot[candidateY])
                    {
                        mPairwisePreferences[mCandidateIds[candidateX], mCandidateIds[candidateY]]++;
                    }
                }
            }
        }

        public List<string> Ranking
        {
            get
            {
                mStrongestPaths = new int[mCandidateIds.Count, mCandidateIds.Count];

                for (int i = 0; i < mCandidateIds.Count; i++)
                {
                    for (int j = 0; j < mCandidateIds.Count; j++)
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

                for (int i = 0; i < mCandidateIds.Count; i++)
                {
                    for (int j = 0; j < mCandidateIds.Count; j++)
                    {
                        if (i != j)
                        {
                            for (int k = 0; k < mCandidateIds.Count; k++)
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
                var ranking = mCandidateIds.Keys.ToList();
                ranking.Sort((x, y) => mStrongestPaths[mCandidateIds[x], mCandidateIds[y]].CompareTo(mStrongestPaths[mCandidateIds[y], mCandidateIds[x]]));
                ranking.Reverse();
                return ranking;
            }
        }
    }
}
