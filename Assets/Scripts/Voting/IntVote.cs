using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Voting
{
    public class IntVote: VoteBase
    {
        Player player;
        int result;

        bool isCorrect = false;

        public override Player GetPlayer()
        {
            return player;
        }

        public override bool GetVoteResult()
        {
            return isCorrect;
        }

        public override void SetVoteResult(bool result)
        {
            isCorrect = result;
        }

        public int GetVote()
        {
            return result;
        }

        public void SetVote(int value)
        {
            result = value;
        }


        public IntVote(Player p)
        {
            player = p;
        }
    }
}
