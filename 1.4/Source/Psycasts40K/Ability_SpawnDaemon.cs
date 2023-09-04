using RimWorld.Planet;
using UnityEngine;
using Verse;
using Core40k;

namespace Psycasts40k
{
    public class Ability_SpawnDaemon : VFECore.Abilities.Ability
    {
        public override void Cast(params GlobalTargetInfo[] targets)
        {
            if (!def.HasModExtension<DefModExtension_DaemonSummon>())
            {
                return;
            }
            base.Cast(targets);
            foreach (GlobalTargetInfo globalTargetInfo in targets)
            {
                IntVec3 position = globalTargetInfo.Cell;
                PawnKindDef summon = def.GetModExtension<DefModExtension_DaemonSummon>().daemonToSummon;

                int summonAmount = Mathf.FloorToInt(GetPowerForPawn());

                for (int i = 0; i < summonAmount; i++)
                {
                    GenSpawn.Spawn(PawnGenerator.GeneratePawn(summon, pawn.Faction), position, pawn.Map);
                }

            }
        }
    }

}