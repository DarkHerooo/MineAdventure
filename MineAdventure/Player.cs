using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    class Player
    {
        private int _HealthPlayer;
        private int _SatietyPlayer;

        public int HealthPlayer
        {
            get { return _HealthPlayer; }
            set 
            {
                if (value >= 0) _HealthPlayer = value;
                else _HealthPlayer = 0;
            }
        }
        public int SatietyPlayer
        {
            get { return _SatietyPlayer; }
            set
            {
                if (value >= 0) _SatietyPlayer = value;
                else _SatietyPlayer = 0;
            } 
        }

        public Player(int healthPlayer, int satietyPlayer)
        {
            HealthPlayer = healthPlayer;
            SatietyPlayer = satietyPlayer;
        }
    }
}
