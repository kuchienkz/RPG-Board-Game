using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public abstract class JobClass
    {
        public string JobName;
        public string JobDescription;

        // Bonus Stats
        public int bonus_ATK = 0;
        public int bonus_DEF = 0;
        public int bonus_EVA = 0;
        
    }

    public class Adventurer : JobClass
    {
        public Adventurer()
        {
            bonus_ATK = 10;
            bonus_DEF = 10;
            bonus_EVA = 5;
        }
    }
}
