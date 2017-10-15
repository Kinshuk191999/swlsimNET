using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using swlsimNET.Models;
using swlsimNET.ServerApp;
using swlsimNET.ServerApp.Combat;
using swlsimNET.ServerApp.Models;
using swlsimNET.ServerApp.Spells;
using swlsimNET.ServerApp.Weapons;

namespace swlsimNET.Tests
{
    [TestClass]
    public class BladeTest
    {
        [TestMethod]
        public void TestBladeGimmick()
        {
            var setting = new Settings
            {
                PrimaryWeapon = WeaponType.Blade,
                SecondaryWeapon = WeaponType.Fist,
                FightLength = 3,
                TargetType = TargetType.Champion,
                Apl = ""
            };

            var player = new Player(setting);
            var bSpell = new BladeSpell();

            player.Spells.Add(bSpell);

            var engine = new Engine(setting);
            var fight = engine.StartFight(player);

            var bSpells = fight.RoundResults
                .SelectMany(r => r.Attacks.Where(a => a.Spell is BladeSpell)).Count();

            // TODO: ChiGenerator(player); ChiConsumer(); SpiritBladeConsumer(player, rr); SpiritBladeExtender(); Not all in same test ofc
            Assert.IsTrue(false);
        }

        private sealed class BladeSpell : Spell
        {
            public BladeSpell()
            {
                PrimaryGimmickGain = 50;
                WeaponType = WeaponType.Blade;
                SpellType = SpellType.Cast;
                BaseDamage = 1;
            }
        }
    }
}
