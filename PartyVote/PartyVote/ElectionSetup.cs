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
    [Activity(Label = "New Election")]
    public class ElectionSetup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ElectionSetup);

            EditText electionTitleText = FindViewById<EditText>(Resource.Id.ElectionTitleTextBox);
            Button prepareBallot = FindViewById<Button>(Resource.Id.PrepareBallotButton);
            Spinner votingMethodSpinner = FindViewById<Spinner> (Resource.Id.VotingMethodSpinner);

            var adapter = ArrayAdapter.CreateFromResource (
                this, Resource.Array.voting_methods_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
            votingMethodSpinner.Adapter = adapter;

            prepareBallot.Click += delegate
            {
                Bundle b = new Bundle();
                b.PutString("electionTitle", electionTitleText.Text);
                b.PutString("votingMethod", votingMethodSpinner.SelectedItem.ToString());

                var prepareCandidatesActivity = new Intent(this, typeof(PrepareCandidateList));
                prepareCandidatesActivity.PutExtras(b);
                StartActivity(prepareCandidatesActivity);
            };
        }
    }
}