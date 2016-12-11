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

            this.Title = this.Intent.Extras.GetString("electionTitle");

            Button newBallotButton = FindViewById<Button>(Resource.Id.NewBallotButton);
            giveResultsButton = FindViewById<Button>(Resource.Id.GiveResultsButton);     

            UpdateActivity();

            newBallotButton.Click += delegate
            {
                // TODO: Create actual ballot
                ballotsCount++;
                UpdateActivity();

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("You Voted");
                alert.SetMessage("Doesn't it feel good?");

                Dialog dialog = alert.Create();
                dialog.Show();
            };

            giveResultsButton.Click += delegate
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Show the election results?");
                alert.SetMessage("This will end the election and show the results. You will no longer be able to cast ballots for this election.");
                
                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    // TODO: Create actual results activity
                    var mainActivity = new Intent(this, typeof(MainActivity));
                    StartActivity(mainActivity);
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
                    giveResultsButton.Enabled = false;
                    descriptionTextView.Text = "No ballots have been cast yet.";
                    break;
                case 1:
                    giveResultsButton.Enabled = true;
                    descriptionTextView.Text = "1 ballot has been cast so far. Anyone else voting?";
                    break;
                default:
                    giveResultsButton.Enabled = true;
                    descriptionTextView.Text = Convert.ToString(ballotsCount) + " ballots have been cast so far. Anyone else voting?";
                    break;
            }
        }

        private int ballotsCount = 0;
        private Button giveResultsButton;
    }
}
