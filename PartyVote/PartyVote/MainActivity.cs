using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PartyVote
{
    [Activity(Label = "Party Vote", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button newElectionButton = FindViewById<Button>(Resource.Id.NewElectionButton);

            newElectionButton.Click += delegate
            {
                var electionSetupActivity = new Intent(this, typeof(ElectionSetup));
                StartActivity(electionSetupActivity);
            };
        }
    }
}

