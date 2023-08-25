using System.Collections.Generic;
using Verse;
using VanillaPsycastsExpanded;

namespace Psycasts40k
{
    public class PsykerPathDef : PsycasterPathDef
    {
        private List<GeneDef> requiredGeneAny = new List<GeneDef>();

        private List<GeneDef> requiredGeneAll = new List<GeneDef>();

        public override bool CanPawnUnlock(Pawn pawn)
        {
            return base.CanPawnUnlock(pawn) && PawnHasGeneAny(pawn) && PawnHasGeneAll(pawn);
        }

        private bool PawnHasGeneAny(Pawn pawn)
        {
            if (requiredGeneAny.NullOrEmpty())
                return true;

            foreach (var gene in requiredGeneAny)
            {
                if (pawn.genes.HasGene(gene))
                    return true;
            }
            return false;
        }

        private bool PawnHasGeneAll(Pawn pawn)
        {
            if (requiredGeneAny.NullOrEmpty())
                return true;

            foreach (var gene in requiredGeneAll)
            {
                if (!pawn.genes.HasGene(gene))
                    return false;
            }
            return true;
        }
    }
}