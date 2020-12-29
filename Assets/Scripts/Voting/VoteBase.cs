using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Voting
{
    public abstract class VoteBase
    {
        public abstract void SetVoteResult(bool result);
        public abstract bool GetVoteResult();

        public abstract Player GetPlayer();
    }
}
