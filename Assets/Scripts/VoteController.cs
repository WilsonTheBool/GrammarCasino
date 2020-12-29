using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Voting;

public class VoteController : MonoBehaviour
{
    List<VoteBase> allVotes;
    public void TakeVote(VoteBase vote, TaskBase curentTask)
    {
        vote.SetVoteResult(curentTask.IsVoteTrue(vote));

        allVotes.Add(vote);

        Debug.Log(vote.GetPlayer().playerName + ": " + vote.GetVoteResult().ToString());
    }

    void Start()
    {
        allVotes = new List<VoteBase>();
    }

    public void ResetVotes()
    {
        allVotes.Clear();
    }

    public VoteBase GetVote(Player p)
    {
        if (p != null)
            return allVotes.Find((VoteBase v) => v.GetPlayer() == p);
        else
            return null;
    }
}
