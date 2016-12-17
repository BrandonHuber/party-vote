using System;
using NUnit.Framework;
using System.Collections.Generic;
using PartyVote;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void WhenWikiDataIsGiven_ThenRankingIsCorrect()
        {
            var candidateList = new List<string>();
            candidateList.Add("A");
            candidateList.Add("B");
            candidateList.Add("C");
            candidateList.Add("D");
            candidateList.Add("E");

            Schulze schulze = new PartyVote.Schulze(candidateList);

            for (int i = 0; i < 5; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "A", 1 },
                        { "C", 2 },
                        { "B", 3 },
                        { "E", 4 },
                        { "D", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 5; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "A", 1 },
                        { "D", 2 },
                        { "E", 3 },
                        { "C", 4 },
                        { "B", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 8; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "B", 1 },
                        { "E", 2 },
                        { "D", 3 },
                        { "A", 4 },
                        { "C", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 3; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "C", 1 },
                        { "A", 2 },
                        { "B", 3 },
                        { "E", 4 },
                        { "D", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 7; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "C", 1 },
                        { "A", 2 },
                        { "E", 3 },
                        { "B", 4 },
                        { "D", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 2; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "C", 1 },
                        { "B", 2 },
                        { "A", 3 },
                        { "D", 4 },
                        { "E", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 7; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "D", 1 },
                        { "C", 2 },
                        { "E", 3 },
                        { "B", 4 },
                        { "A", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            for (int i = 0; i < 8; i++)
            {
                var tempBallot = new Dictionary<string, int>
                    {
                        { "E", 1 },
                        { "B", 2 },
                        { "A", 3 },
                        { "D", 4 },
                        { "C", 5 }
                    };
                schulze.AddBallot(tempBallot);
            }

            var ranking = schulze.Ranking;
            
            Assert.AreEqual(new List<string> { "E", "A", "C", "B", "D" }, ranking.ToArray());
        }
    }
}
