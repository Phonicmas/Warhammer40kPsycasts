using HarmonyLib;
using Verse;


namespace Psycasts40k
{
    public class Psycasts40kMod : Mod
    {
        public static Harmony harmony;
        public Psycasts40kMod(ModContentPack content) : base(content)
        {
            harmony = new Harmony("Psycasts40k.Mod");
            harmony.PatchAll();
        }
    }
}