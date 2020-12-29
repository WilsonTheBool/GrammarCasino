using UnityEngine;
using System.Collections;
using Assets.Scripts.Voting;

public class Task_Test : TaskBase
{
    
   
    public int trueAnswer;

    public override bool IsVoteTrue(VoteBase vote)
    {
        IntVote intVote = vote as IntVote;
        if(intVote != null && intVote.GetVote() == trueAnswer)
        {
            return (true);
        }
        else
        {
           return (false);
        }

        
    }
}
