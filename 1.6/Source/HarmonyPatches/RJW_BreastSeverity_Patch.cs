using HarmonyLib;
using RimWorld;
using Verse;

namespace GenderbenderPatch
{
    [HarmonyPatch]
    public static class RJW_BreastSeverity_Patch
    {
        [HarmonyPrepare]
        public static bool Prepare()
        {
            return ModsConfig.IsActive("rim.job.world");
        }

        [HarmonyPatch(typeof(GameComponent_PawnDuplicator), "Duplicate")]
        [HarmonyPostfix]
        public static void AdjustBreastSeverity(Pawn __result, Pawn pawn)
        {
            if (__result.gender == pawn.gender)
            {
                return;
            }

            Hediff breastsHediff = __result.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("Breasts"));
            if (breastsHediff == null)
            {
                return;
            }

            if (__result.gender == Gender.Female)
            {
                breastsHediff.Severity = 1.0f; // Average size
            }
            else if (__result.gender == Gender.Male)
            {
                breastsHediff.Severity = 0.0f; // Nipples
            }
        }
    }
}