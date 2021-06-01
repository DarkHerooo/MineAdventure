using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    public class Sound
    {
        public string nameObject;
        public int healthObject;

        public Sound(string name, int health)
        {
            nameObject = name;
            healthObject = health;
        }

        public void PlayBlockSound()
        {
            Random rnd = new Random();
            SoundPlayer sound;
            if (nameObject == "Dirt")
                sound = new SoundPlayer("../../Sounds/Blocks/" + nameObject + "/" +
                    nameObject + rnd.Next(1, 4) + ".wav");
            else
                sound = new SoundPlayer("../../Sounds/Blocks/Stone/Stone" + rnd.Next(1, 4) + ".wav");
            sound.Play();

        }

        public void PlayMobSound()
        {
            Random rnd = new Random();
            SoundPlayer sound;
            if (healthObject > 0)
                sound = new SoundPlayer("../../Sounds/Mobs/" + nameObject + "/hurt" +
                    rnd.Next(1, 4) + ".wav");
            else
                sound = new SoundPlayer("../../Sounds/Mobs/" + nameObject + "/Death.wav");
            sound.Play();
        }
    }
}
