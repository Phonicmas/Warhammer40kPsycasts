using RimWorld;
using Verse;


namespace Psycasts40k
{
    [DefOf]
    public static class Psycasts40kDefOf
    {
        

        public static HediffDef BEWH_EcstaticOblivion;
        public static HediffDef BEWH_NurglesRot;

        public static PawnKindDef BEWH_SummonedPinkHorror;
        public static PawnKindDef BEWH_SummonedPlaguebearer;
        public static PawnKindDef BEWH_SummonedDaemonette;

        public static PawnKindDef BEWH_Plaguebearer;



        static Psycasts40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Psycasts40kDefOf));
        }
    }
}