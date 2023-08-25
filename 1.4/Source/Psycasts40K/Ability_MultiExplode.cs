using RimWorld.Planet;
using System.Collections.Generic;
using Verse;
using VFECore.Abilities;

namespace Psycasts40k
{
    public class Ability_MultiExplode : Ability
    {
        public override void Cast(params GlobalTargetInfo[] targets)
        {
            base.Cast(targets);
            AbilityExtension_Explosion modExtension = def.GetModExtension<AbilityExtension_Explosion>();
            if (modExtension != null)
            {
                foreach (GlobalTargetInfo globalTargetInfo in targets)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        GenExplosion.DoExplosion(modExtension.onCaster ? pawn.Position : globalTargetInfo.Cell, pawn.Map, modExtension.explosionRadius, modExtension.explosionDamageDef, pawn, modExtension.explosionDamageAmount, modExtension.explosionArmorPenetration, modExtension.explosionSound, null, null, null, modExtension.postExplosionSpawnThingDef, modExtension.postExplosionSpawnChance, modExtension.postExplosionSpawnThingCount, modExtension.postExplosionGasType, modExtension.applyDamageToExplosionCellsNeighbors, modExtension.preExplosionSpawnThingDef, modExtension.preExplosionSpawnChance, modExtension.preExplosionSpawnThingCount, modExtension.chanceToStartFire, modExtension.damageFalloff, modExtension.explosionDirection, modExtension.casterImmune ? new List<Thing> { pawn } : null);
                    }
                }
            }
        }
    }

}