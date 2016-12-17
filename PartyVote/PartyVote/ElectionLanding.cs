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
using System.Collections.ObjectModel;

namespace PartyVote
{
    [Activity(Label = "ElectionLanding")]
    public class ElectionLanding : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ElectionLanding);

            this.Title = "Election: " + this.Intent.Extras.GetString("electionTitle");

            Button newBallotButton = FindViewById<Button>(Resource.Id.NewBallotButton);
            finishElectionButton = FindViewById<Button>(Resource.Id.FinishElectionButton);     

            UpdateActivity();

            newBallotButton.Click += delegate
            {
                // TODO: Create actual ballot
                ballotsCount++;
                UpdateActivity();

                Toast.MakeText(this, "Ballot successfully cast", ToastLength.Short).Show();
            };

            finishElectionButton.Click += delegate
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Show the election results?");
                alert.SetMessage("This will end the election and show the results. You will no longer be able to cast ballots for this election.");
                
                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    var bundle = new Bundle();
                    bundle.PutString("electionTitle", this.Intent.Extras.GetString("electionTitle"));
                    var resultsActivity = new Intent(this, typeof(ResultsActivity));
                    resultsActivity.PutExtras(bundle);
                    StartActivity(resultsActivity);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) => {});

                Dialog dialog = alert.Create();
                dialog.Show();
            };
        }

        private void UpdateActivity()
        {
            var descriptionTextView = FindViewById<TextView>(Resource.Id.ElectionLandingDescription);

            switch (ballotsCount)
            {
                case 0:
                    finishElectionButton.Enabled = false;
                    descriptionTextView.Text = "No ballots have been cast yet.";
                    break;
                case 1:
                    finishElectionButton.Enabled = true;
                    descriptionTextView.Text = "1 ballot has been cast so far. Anyone else voting?";
                    break;
                default:
                    finishElectionButton.Enabled = true;
                    descriptionTextView.Text = Convert.ToString(ballotsCount) + " ballots have been cast so far. Anyone else voting?";
                    break;
            }
        }

        private int ballotsCount = 0;
        private Button finishElectionButton;
    }
}
