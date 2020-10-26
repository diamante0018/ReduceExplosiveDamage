using InfinityScript;
using System.Collections.Generic;

namespace Explosive
{
    public class Explosive : BaseScript
    {
        private HashSet<string> shit_weapons;
        private HashSet<string> shit_ks;
        public Explosive()
        {
            shit_weapons = constructor();
            shit_ks = constructor2();

            AfterDelay(3000, () => Call("IPrintLn", "^6Reduced explosive damage script^7 ^0V2 ^7Made by ^1Diavolo"));
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            if (shit_weapons.Contains(weapon))
            {
                if(player.IsPlayer)
                    player.Health += System.Math.Abs(damage - 15);
            }

            if (shit_ks.Contains(weapon))
            {
                if (player.IsPlayer)
                    player.Health += System.Math.Abs(damage - 5);
            }

            //Utilities.SayTo(player, string.Format("Weapon: ^1{0}^7 Damage: ^1{1} ^7Health: ^1{2}", weapon, damage,player.Health));

            /*
             * Nerf Vests
            */
            if (player.IsPlayer && player.IsAlive && player.Health > 130)
                player.Health = 130;
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

        private HashSet<string> constructor2()
        {
            HashSet<string> weapons = new HashSet<string>();
            weapons.Add("stealth_bomb_mp");
            weapons.Add("killstreak_remote_turret_mp");
            weapons.Add("killstreak_stealth_airstrike_mp");
            weapons.Add("cobra_20mm_mp");
            weapons.Add("littlebird_guard_minigun_mp");
            weapons.Add("pavelow_minigun_mp");
            weapons.Add("ac130_25mm_mp");
            weapons.Add("ac130_40mm_mp");
            weapons.Add("osprey_minigun_mp");
            weapons.Add("osprey_player_minigun_mp");
            return weapons;
        }
    }
}