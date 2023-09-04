using RimWorld;
using Verse;
using VanillaPsycastsExpanded;

namespace Psycasts40k
{
    public class AbilityExtension_Psycast40k : AbilityExtension_Psycast
    {
        public HediffDef mustHaveHediff;

        public override bool ValidateTarget(LocalTargetInfo target, VFECore.Abilities.Ability ability, bool throwMessages = false)
        {
            if (psychic)
            {
                Pawn pawn = target.Pawn;
                if (pawn != null && pawn.GetStatValue(StatDefOf.PsychicSensitivity) < float.Epsilon)
                {
                    if (throwMessages)
                    {
                        Messages.Message("Ineffective".Translate(), MessageTypeDefOf.RejectInput, historical: false);
                    }
                    return false;
                }

                if (pawn != null && !pawn.health.hediffSet.HasHediff(mustHaveHediff))
                {
                    if (throwMessages)
                    {
                        Messages.Message("NoNurgleRot".Translate(), MessageTypeDefOf.RejectInput, historical: false);
                    }
                    return false;
                }
            }
            return true;
        }
    }
}