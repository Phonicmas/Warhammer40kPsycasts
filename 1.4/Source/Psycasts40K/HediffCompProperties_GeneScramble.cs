using Verse;


namespace Psycasts40k
{
    public class HediffCompProperties_GeneScramble : HediffCompProperties
    {

        public int scrambleAmount;

        public HediffCompProperties_GeneScramble()
        {
            compClass = typeof(HediffComp_GeneScramble);
        }

    }
}