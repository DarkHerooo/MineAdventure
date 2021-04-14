using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    class Player
    {
        public int HealthPlayer;
        public int SatietyPlayer;

        public Player(int healthPlayer, int satietyPlayer)
        {
            HealthPlayer = healthPlayer;
            SatietyPlayer = satietyPlayer;
        }
    }
}
