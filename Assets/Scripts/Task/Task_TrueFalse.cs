using UnityEngine;
using System.Collections;
using Assets.Scripts.Voting;

public class Task_TrueFalse : TaskBase
{

    public bool isTrue;

    public override bool IsVoteTrue(VoteBase vote)
    {
        BoolVote boolVote = vote as BoolVote;

        if(boolVote != null && boolVote.GetVote() == isTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
