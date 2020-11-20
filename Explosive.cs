using InfinityScript;
using static InfinityScript.ThreadScript;
using static InfinityScript.GSCFunctions;
using System;
using System.Collections.Generic;
using System.Collections;

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

            PlayerConnected += SpawnedPlayer;

            AfterDelay(3000, () => IPrintLn("^6Reduced explosive damage script^7 ^0V3.1 ^7Made by ^1Diavolo"));
        }

        public void SpawnedPlayer(Entity player)
        {
            Thread(OnPlayerSpawned(player), (entRef, notify, paras) =>
            {
                if (notify == "disconnect" && player.EntRef == entRef)
                    return false;

                return true;
            });
        }

        private static IEnumerator OnPlayerSpawned(Entity player)
        {
            while (true)
            {
                yield return player.WaitTill("spawned_player");

                if (player.HasWeapon("stinger_mp"))
                {
                    player.TakeWeapon("stinger_mp");
                    player.GiveWeapon("iw5_usp45_mp");
                    player.SetWeaponAmmoClip("iw5_usp45_mp", 0);
                    player.SetWeaponAmmoStock("iw5_usp45_mp", 0);

                }

                if (player.HasWeapon("flash_grenade_mp"))
                {
                    player.SetWeaponAmmoStock("flash_grenade_mp", 1);
                }

                else if (player.HasWeapon("concussion_grenade_mp"))
                {
                    player.SetWeaponAmmoStock("concussion_grenade_mp", 1);
                }
            }
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
           /*
            * Nerf Vests
           */
            if (player.IsPlayer && player.IsAlive && player.Health > 100)
                player.Health = 100;

            if (shit_weapons.Contains(weapon))
            {
                if(player.IsPlayer)
                    player.Health += Math.Abs(damage - 13);
            }

            if (shit_ks.Contains(weapon))
            {
                if (player.IsPlayer)
                    player.Health += Math.Abs(damage - 3);
            }

            if (weapon.Contains("m320") || weapon.Contains("gl") || weapon.Contains("gp25"))
            {
                player.Health += Math.Abs(damage - 3);
            }

            //Utilities.SayTo(player, string.Format("Weapon: ^1{0}^7 Damage: ^1{1} ^7Health: ^1{2}", weapon, damage,player.Health));
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
            weapons.Add("killstreak_precision_airstrike_mp"); //Should kill player with two runs
            return weapons;
        }

        private HashSet<string> constructor2()
        {
            HashSet<string> weapons = new HashSet<string>();
            weapons.Add("stealth_bomb_mp");
            weapons.Add("frag_grenade_short_mp");
            weapons.Add("killstreak_remote_turret_mp");
            weapons.Add("killstreak_stealth_airstrike_mp");
            weapons.Add("cobra_20mm_mp");
            weapons.Add("littlebird_guard_minigun_mp");
            weapons.Add("pavelow_minigun_mp");
            weapons.Add("ac130_25mm_mp");
            weapons.Add("ac130_40mm_mp");
            weapons.Add("osprey_minigun_mp");
            weapons.Add("osprey_player_minigun_mp");
            weapons.Add("ims_projectile_mp");
            weapons.Add("killstreak_ims_mp");
            weapons.Add("manned_minigun_turret_mp");
            weapons.Add("manned_gl_turret_mp");
            weapons.Add("ugv_turret_mp");
            weapons.Add("ugv_gl_turret_mp");
            weapons.Add("remote_turret_mp");
            return weapons;
        }
    }
}