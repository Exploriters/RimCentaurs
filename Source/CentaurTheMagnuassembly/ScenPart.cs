using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using HarmonyLib;
using UnityEngine;
using Verse.AI;
using Verse;
using Verse.Sound;
using static CentaurTheMagnuassembly.RimCentaurCore;
using SaveOurShip2;
using RimworldMod.VacuumIsNotFun;

namespace CentaurTheMagnuassembly
{
    public class ScenPart_FillBattery : ScenPart
    {
        //ModContentPack.PatchOperationFindMod
        public static string Summary(Scenario scen)
        {
            return "Magnuassembly_ScenPart_FillBattery_StaticSummary".Translate();
        }
        private static void ProcessBattery(ref Thing battery)
        {
            //if (battery.def == DefDatabase<ThingDef>.GetNamed("TriBattery"))
            try
            {
                ((ThingWithComps)battery)?.TryGetComp<CompPowerBattery>()?.AddEnergy(36000);
            }
            catch
            { }
        }
        public override void PostGameStart()
        {
            base.PostGameStart();
            List<Thing> things = Find.CurrentMap.listerThings.AllThings;
            foreach (Thing thing in things)
            {
                //if (thing.def == DefDatabase<ThingDef>.GetNamed("TriBattery"))
                //if (thing.TryGetComp<CompPowerBattery>() != null)
                //{
                //    thing?.TryGetComp<CompPowerBattery>()?.AddEnergy(36000);
                //}
                if (thing.def == ThingDefOf.MinifiedThing)
                {
                    Thing thingInside = ((MinifiedThing)thing).InnerThing;
                    if (thingInside.TryGetComp<CompPowerBattery>() != null)
                    {
                        thingInside?.TryGetComp<CompPowerBattery>()?.AddEnergy(36000);
                    }
                }
                if (thing.def == ThingDefOf.DropPodIncoming)
                {
                    foreach (Thing thing3 in ((DropPodIncoming)thing).Contents.innerContainer)
                    {
                        if (thing3.TryGetComp<CompPowerBattery>() != null)
                        {
                            thing3?.TryGetComp<CompPowerBattery>()?.AddEnergy(36000);
                        }
                        if (thing3.def == ThingDefOf.MinifiedThing)
                        {
                            Thing thingInside = ((MinifiedThing)thing3).InnerThing;
                            if (thingInside.TryGetComp<CompPowerBattery>() != null)
                            {
                                thingInside?.TryGetComp<CompPowerBattery>()?.AddEnergy(36000);
                            }
                        }
                    }
                }
            }

            foreach (Letter letter in Find.LetterStack.LettersListForReading)
            {
                Find.LetterStack.RemoveLetter(letter);
            }
            return;
        }
    }
}
