using HarmonyLib;
using System.Collections.Generic;
using VanillaPsycastsExpanded;
using Verse;

namespace Psycasts40k
{
    [HarmonyPatch(typeof(ThingDefGenerator_Neurotrainer_ImpliedThingDefs_Patch), "ImpliedThingDefs")]
    public class ExcludePsytrainerVPE
    {
        public static IEnumerable<ThingDef> Postfix(IEnumerable<ThingDef> __result)
        {
            List<ThingDef> newResult = new List<ThingDef>();

            foreach (ThingDef thingDef in __result)
            {
                bool addThing = true;

                CompProperties_UseEffect_Psytrainer compProperties = thingDef.GetCompProperties<CompProperties_UseEffect_Psytrainer>();

                if (compProperties != null && compProperties.ability != null)
                {
                    if (compProperties.ability.HasModExtension<DefModExtension_ExcludePsytrainer>())
                    {
                        thingDef.generateCommonality = 0;
                        addThing = false;
                    }
                }
                if (addThing)
                {
                    newResult.Add(thingDef);
                }
            }

            return newResult;
        }
    }
}