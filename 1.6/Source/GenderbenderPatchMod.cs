using HarmonyLib;
using Verse;

namespace GenderbenderPatch
{
    public class GenderbenderPatchMod : Mod
    {
        public GenderbenderPatchMod(ModContentPack pack) : base(pack)
        {
            new Harmony("GenderbenderPatchMod").PatchAll();
        }
    }
}