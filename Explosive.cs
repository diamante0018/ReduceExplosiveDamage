﻿using InfinityScript;
using System.Collections.Generic;

namespace Explosive
{
    public class Explosive : BaseScript
    {
        private HashSet<string> shit_weapons;
        public Explosive()
        {
            shit_weapons = constructor();
            AfterDelay(3000, () => Call("IPrintLn", "^6Reduced explosive damage script^7 Made by ^1Diavolo"));
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            float health_to_restore;

            if (shit_weapons.Contains(weapon))
            {
                health_to_restore = (damage / 100.00f) * 85.00f;
                player.Health += (int)health_to_restore;

                if (player.Health < 101)
                    player.Health = 102;
                //Utilities.SayTo(player, string.Format("Weapon: ^1{0}^7 Damage: ^1{1} ^7Health: ^1{2}", weapon, damage,player.Health));
            }
        }

        private HashSet<string> constructor()
        {
            HashSet<string> weapons = new HashSet<string>();
            weapons.Add("semtex_mp");
            weapons.Add("c4death_mp");
            weapons.Add("frag_grenade_mp");
            weapons.Add("rpg_mp");
            weapons.Add("xm25_mp");
            weapons.Add("m320_mp");
            weapons.Add("claymore_mp");
            weapons.Add("iw5_smaw_mp");
            weapons.Add("gl_mp");
            weapons.Add("javelin_mp");
            weapons.Add("bouncingbetty_mp"); 
            return weapons;
        }
    }
}