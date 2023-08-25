using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;


namespace Psycasts40k
{
    public class MapComponent_Plaguebearer : MapComponent
    {
        public const int checkingInterval = 100;

        public const int spawnTimer = 200;

        public int tickCounter = 0;

        public List<Corpse> deadDaemonPrincePawns = new List<Corpse>();

        public MapComponent_Plaguebearer(Map map)
            : base(map)
        {
        }

        public override void MapComponentTick()
        {
            base.MapComponentUpdate();
            if (tickCounter >= checkingInterval)
            {
                tickCounter = 0;

                foreach (Thing thing in map.spawnedThings)
                {
                    if (thing is Corpse corpse)
                    {
                        
                        if (corpse.InnerPawn != null && corpse.InnerPawn.health.hediffSet.hediffs.Find((Hediff x) => x.def == Psycasts40kDefOf.BEWH_NurglesRot && x.Visible) != null && !deadDaemonPrincePawns.Contains(corpse))
                        {
                            deadDaemonPrincePawns.Add(corpse);
                        }
                    }
                }
                if (deadDaemonPrincePawns.Count > 0)
                {
                    List<Corpse> toRemove = new List<Corpse>();
                    foreach (Corpse corpse in deadDaemonPrincePawns)
                    {
                        if (Find.TickManager.TicksGame - corpse.timeOfDeath >= spawnTimer)
                        {
                            toRemove.Add(corpse);
                            if (corpse.InnerPawn != null)
                            {
                                corpse.InnerPawn.Strip();
                            }
                            Pawn pb = PawnGenerator.GeneratePawn(Psycasts40kDefOf.BEWH_Plaguebearer);
                            GenSpawn.Spawn(pb, corpse.Position, corpse.Map);
                            pb.HostileTo(Faction.OfPlayer);
                        }
                    }
                    for (int i = 0; i < toRemove.Count; i++)
                    {
                        deadDaemonPrincePawns.Remove(toRemove.First());
                        toRemove.First().DeSpawn();
                    }
                    toRemove.Clear();
                }

            }
            tickCounter++;
        }
    }
}