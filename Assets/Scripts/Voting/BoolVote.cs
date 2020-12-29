using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Voting
{
    public class BoolVote: VoteBase
    {
        Player player;
        bool result;

        bool isCorrect = false;

        public override Player GetPlayer()
        {
            return player;
        }

        public override bool GetVoteResult()
        {
            return isCorrect;
        }

        public bool GetVote()
        {
            return result;
        }

        public void SetVote(bool value)
        {
            result = value;
        }

        public override void SetVoteResult(bool result)
        {
            isCorrect = result;
        }
        
        public BoolVote(Player p)
        {
            player = p;
        }
    }
}
