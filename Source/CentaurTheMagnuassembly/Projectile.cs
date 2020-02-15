using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using static CentaurTheMagnuassembly.RimCentaurCore;

namespace CentaurTheMagnuassembly
{
    public class Projectile_Explosive_Teleshot : Projectile_Explosive
    {
        protected override void Explode()
        {
            Map map = Map;
            IntVec3 pos = Position;
            base.Explode();
            if (launcher.Map.uniqueID == map.uniqueID)
            {
                //if ((map.AllCells as List<IntVec3>).Contains(pos)
                //&& map.pathGrid.Walkable(pos)
                //    )
                {
                    launcher.SetPositionDirect(pos);
                    //if (launcher is Pawn)
                    //{
                        //if (((Pawn)launcher).CanReach(intendedTarget, PathEndMode.OnCell, Danger.Unspecified))
                        ((Pawn)launcher)?.pather?.TryRecoverFromUnwalkablePosition(false);
                        //((Pawn)launcher).Draw();
                    //}
                    map.fogGrid.Unfog(launcher.Position);
                }
            }
        }
        /*public override void Tick()
        {
            base.Tick();
            if (!landed && intendedTarget.HasThing && intendedTarget.Thing.Map.uniqueID == Map.uniqueID)
            {
                origin = Position.ToVector3();
                destination = intendedTarget.Thing.Position.ToVector3();
            }
        }*/
    }
    public class Projectile_Explosive_Spotshot : Projectile_Explosive
    {
        protected override void Explode()
        {
            Map.fogGrid.Unfog(Position);
            base.Explode();
        }
    }
    public class Projectile_Explosive_Waggingshot : Projectile_Explosive
    {
        public override void Tick()
        {
            base.Tick();
            if (!landed)
            {
                ticksToImpact = Math.Max(ticksToImpact + new Random().Next(-10, 10), 0);
            }
        }
    }

}
