using HarmonyLib;
using RimWorld;
using Verse;


namespace Psycasts40k
{
    [HarmonyPatch(typeof(StunHandler), "StunFor")]
    public class IgnoreStunPatch
    {
        public static void Postfix(StunHandler __instance)
        {
            StunHandler instance = __instance;
            Pawn pawn = instance.parent as Pawn;
            if (pawn.DestroyedOrNull() || pawn.Dead)
            {
                return;
            }

            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.def == Psycasts40kDefOf.BEWH_EcstaticOblivion && x.Visible);

            //Find a way to do this another way? Do prefix instead that just sets the ticks to stun to 0
            if (hediff != null && pawn.stances.stunner.Stunned)
            {
                pawn.stances.stunner = new StunHandler(pawn);
            }
                
            return;
        }
    }
}