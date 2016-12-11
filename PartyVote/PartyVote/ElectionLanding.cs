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
            Button giveResultsButton = FindViewById<Button>(Resource.Id.GiveResultsButton);

            newBallotButton.Click += delegate
            {
                // TODO: Create actual ballot
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
    }
}
