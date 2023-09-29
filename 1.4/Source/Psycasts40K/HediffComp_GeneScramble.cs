using Core40k;
using System;
using System.Collections.Generic;
using Verse;


namespace Psycasts40k
{

    public class HediffComp_AddMutation : HediffComp
    {

        //All mutation hediffs
        static List<HediffDef> mutations = new List<HediffDef> {
            DefDatabase<HediffDef>.GetNamed("BEWH_MutationTentaclesRandom"),  
            DefDatabase<HediffDef>.GetNamed("Carcinoma")};

    public HediffCompProperties_AddMutation Props => (HediffCompProperties_AddMutation)props;

        public override void CompPostMake()
        {
            Pawn pawn = base.Pawn;

            if (pawn == null || pawn.DestroyedOrNull() || pawn.genes == null || pawn.Dead)
            {
                return;
            }

            var rand = new Random();

            List<HediffDef> mutationsThatCanBeAdded = mutations;

            HediffDef hediffToAdd = mutationsThatCanBeAdded[rand.Next(0, mutationsThatCanBeAdded.Count)];
            List<BodyPartDef> canApplyTo = new List<BodyPartDef>()
            {
                DefDatabase<BodyPartDef>.GetNamed("Leg"),
                DefDatabase<BodyPartDef>.GetNamed("Arm"),
                DefDatabase<BodyPartDef>.GetNamed("Head"),
            };

            List<BodyPartRecord> record = new List<BodyPartRecord>();

            int j = 0;
            //Makes list of bodyparts records for adding the hediff
            while (j < canApplyTo.Count)
            {
                BodyPartDef part = canApplyTo[j];
                List<BodyPartRecord> bpList = pawn.RaceProps.body.AllParts;
                for (int k = 0; k < bpList.Count; k++)
                {
                    BodyPartRecord bodyPartRecord = bpList[k];
                    if (bodyPartRecord.def == part)
                    {
                        record.Add(bodyPartRecord);
                    }
                }
                j += 1;
            }

            pawn.health.AddHediff(hediffToAdd, record[rand.Next(0, record.Count)]);

        }

    }

}