using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using Verse;
using SaveOurShip2;

namespace CentaurTheMagnuassembly
{
    [StaticConstructorOnStartup]
    internal static class SoS2Tester
    {
        internal static bool inaccessible = false;
        static SoS2Tester()
        {
            try
            {
                ShipCombatManager.GenerateShip(null, null, null, null, null, out _);
                Log.Message("[Magnuassembly]SoS2 accessible.");
            }
            catch (MemberAccessException)
            {
                Log.Warning("[Magnuassembly]Warning, SoS2 inaccessible. Future more StartInSpaceCentaur attemption will be blocked.");
                inaccessible = true;
            }
            catch (Exception)
            {
            }
        }
    }

}
