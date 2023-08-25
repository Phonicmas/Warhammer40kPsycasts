using System;
using System.Collections.Generic;
using Verse;


namespace Psycasts40k
{

    public class HediffComp_GeneScramble : HediffComp
    {

        //All mutation genes
        static List<GeneDef> mutations = new List<GeneDef> {
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation1"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation2"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation3"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation4"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation5"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation6"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation7"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation8"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation9"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation10"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation11"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation12"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation13"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation14"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation15"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation16"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation17"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation18"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation19"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation20")};

        public HediffCompProperties_GeneScramble Props => (HediffCompProperties_GeneScramble)props;

        public override void CompPostMake()
        {
            Pawn pawn = base.Pawn;

            if (pawn.DestroyedOrNull() || pawn.genes == null || pawn.Dead)
            {
                return;
            }

            var rand = new Random();

            int scrambleAmount;

            List<Gene> xenogenes = new List<Gene>(pawn.genes.Xenogenes);

            List<GeneDef> mutationsThatCanBeAdded = mutations;

            //Finds mutations that can be added
            foreach (var gene in xenogenes)
            {
                if (mutations.Contains(gene.def))
                {
                    mutationsThatCanBeAdded.Remove(gene.def);
                }
            }

            //Checking if there are fewer mutations left than scrambles to add
            if (Props.scrambleAmount > mutationsThatCanBeAdded.Count)
            {
                scrambleAmount = mutationsThatCanBeAdded.Count;
            }
            else
            {
                scrambleAmount = Props.scrambleAmount;
            }

            List<int> randomList = new List<int>();

            int num;

            //Finding mutations to add
            while (randomList.Count < scrambleAmount)
            {
                num = rand.Next(0, mutationsThatCanBeAdded.Count);
                if (!randomList.Contains(num))
                {
                    randomList.Add(num);
                }
            }

            //Adds genes
            for (int i = 0; i < scrambleAmount; i++)
            {
                pawn.genes.AddGene(mutations[randomList[i]], true);
            }

        }

    }

}