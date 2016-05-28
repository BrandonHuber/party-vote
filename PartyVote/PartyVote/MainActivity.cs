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

            // Get our button from the layout resource,
            // and attach an event to it
            Button castVoteButton = FindViewById<Button>(Resource.Id.CastVoteButton);
            RadioGroup Candidates = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            castVoteButton.Click += (object sender, EventArgs e) =>
            {
                // Cast Vote from Radio Button selection
                int SelectedCandidate = Candidates.CheckedRadioButtonId;
                string candidateName = FindViewById<RadioButton>(SelectedCandidate).Text;

                var resultsDialog = new AlertDialog.Builder(this);
                resultsDialog.SetMessage("Winner: " + candidateName);

                resultsDialog.Show();
            };
        }
    }
}

