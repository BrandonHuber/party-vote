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
    [Activity(Label = "PrepareCandidateList")]
    public class PrepareCandidateList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PrepareCandidateList);

            CandidateCollection = new ObservableCollection<string>();
            ListView mListView = FindViewById<ListView>(Resource.Id.CandidateListView);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, CandidateCollection);
            mListView.Adapter = adapter;

            Button addCandidateButton = FindViewById<Button>(Resource.Id.AddCandidateButton);
            Button beginElectionButton = FindViewById<Button>(Resource.Id.BeginElectionButton);
            EditText candidateTextBox = FindViewById<EditText>(Resource.Id.CandidateTextBox);

            candidateTextBox.KeyPress += (sender, e) =>
            {
                if(e.KeyCode == Keycode.Enter)
                {
                    addCandidateButton.PerformClick();
                    candidateTextBox.RequestFocus();
                }
                else
                {
                    e.Handled = false;
                }
            };

            addCandidateButton.Click += delegate
            {
                // TODO: Check if empty before adding
                Toast.MakeText(this, candidateTextBox.Text, ToastLength.Long).Show();
                if(candidateTextBox.Text != "")
                {
                    adapter.Insert(candidateTextBox.Text, 0);
                    candidateTextBox.Text = "";
                }
            };

            beginElectionButton.Click += delegate
            {
                Bundle b = new Bundle();
                b.PutString("electionTitle", this.Intent.Extras.GetString("electionTitle"));
                b.PutString("votingMethod", this.Intent.Extras.GetString("votingMethod"));
                b.PutStringArray("ballotCandidates", adapter.ToArray<string>());

                // TODO: Go to next activity
                //var prepareCandidatesActivity = new Intent(this, typeof(PrepareCandidateList));
                //prepareCandidatesActivity.PutExtras(b);
                //StartActivity(prepareCandidatesActivity);
            };
            
        }

        public ObservableCollection<string> CandidateCollection { get; set; }
    }
}