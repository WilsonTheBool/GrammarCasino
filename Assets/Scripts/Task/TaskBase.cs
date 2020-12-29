using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Assets.Scripts.Voting;

public class TaskBase: MonoBehaviour
{
    public int id;

    public int difficulty;

    public string group;

    public string question;

    public string type;

    [TextArea]
    public string task;

    [TextArea]
    public string answer;

    [TextArea]
    public string explanation;

    public virtual bool IsVoteTrue(VoteBase vote)
    {
        return false;
    }
}

