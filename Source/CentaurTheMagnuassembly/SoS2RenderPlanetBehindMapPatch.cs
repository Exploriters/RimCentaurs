using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
//using Harmony;
using HarmonyLib;
using UnityEngine;
using Verse.AI;
using Verse;
using Verse.Sound;
using SaveOurShip2;
using static CentaurTheMagnuassembly.RimCentaurCore;

namespace CentaurTheMagnuassembly
{
    /*
    [StaticConstructorOnStartup]
    public static class SoS2RenderPlanetBehindMapPatch
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Type patchType = typeof(PawnGeneratorPatch);

        static SoS2RenderPlanetBehindMapPatch()
        {
            Harmony harmonyInstance = new Harmony(id: "CentaurTheMagnuassembly.rimworld.mod.SoS2RenderPlanetBehindMapPatch");

            harmonyInstance.Patch(AccessTools.Method(typeof(SaveOurShip2.RenderPlanetBehindMap), nameof(SaveOurShip2.RenderPlanetBehindMap.PreDraw)),
                postfix: new HarmonyMethod(patchType, nameof(PreDrawPostfix) ));
        }
        [HarmonyPostfix]
        public static void PreDrawPostfix()
        {
            Find.World.renderer.wantedMode = RimWorld.Planet.WorldRenderMode.None;
        }
    }*/
    
}
