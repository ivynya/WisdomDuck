using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomDuck
{
    public class Persistence
    {
        public class Referral
        {
            public string From;
            public int Visitors;
            public int APIDispensations = 0;
        }

        public int Visitors = 0;
        public int APIDispensations = 0;
        public int LegacyDispensations = 0;
        public List<Referral> Referrals = new List<Referral>();
    }
}
