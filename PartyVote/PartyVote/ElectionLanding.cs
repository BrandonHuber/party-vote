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
                // TODO: Create actual results activity
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Election Finished");
                alert.SetMessage("The results are on the next (nonexistent) page. Now we'll never know who won.");

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