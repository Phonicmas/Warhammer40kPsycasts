using RimWorld;
using Verse;

namespace Psycasts40k
{
    public class DamageWorker_SymphonyPain : DamageWorker_AddInjury
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            Pawn pawn = victim as Pawn;

            if (pawn != null && pawn.Faction == Faction.OfPlayer)
            {
                Find.TickManager.slower.SignalForceNormalSpeedShort();
            }

            DamageResult damageResult = base.Apply(dinfo, victim);

            if (pawn != null)
            {
                pawn.stances.stunner.StunFor(30, dinfo.Instigator);
            }

            return damageResult;
        }
    }

}