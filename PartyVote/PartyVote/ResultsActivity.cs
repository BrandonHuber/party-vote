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
    [Activity(Label = "Results")]
    public class ResultsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Results);
            
            this.Title = "Election: " + this.Intent.Extras.GetString("electionTitle");

            var newElectionButton = FindViewById<Button>(Resource.Id.NewElectionButton);
            newElectionButton.Click += delegate
            {
                var electionSetupActivity = new Intent(this, typeof(ElectionSetup));
                StartActivity(electionSetupActivity);
            };
        }
    }
}