using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace CentaurTheMagnuassembly
{
    public class RimCentaurCore
    {
    }
    class CompUseEffect_HediffApply_HManipulator : CompUseEffect_FixWorstHealthCondition
    {
        public override void DoEffect(Pawn usedBy)
        {
            for (int i = 0; i < 1000; i++)
            {
                base.DoEffect(usedBy);
            }

            HediffDef HyperManipulatorHediff = DefDatabase<HediffDef>.GetNamed("HyperManipulator");
            Hediff hediff = HediffMaker.MakeHediff(HyperManipulatorHediff, usedBy, null);

            BodyPartDef CentaurScapular = DefDatabase<BodyPartDef>.GetNamed("CentaurScapular");
            BodyPartRecord CentaurScapularRecord = new BodyPartRecord();
            //CentaurScapularRecord.body = DefDatabase<BodyDef>.GetNamed("Centaur");
            //CentaurScapularRecord.def = CentaurScapular;
            //CentaurScapularRecord.parts.Count = 1;


            IEnumerable<BodyPartRecord> parts = usedBy.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined);
            foreach (BodyPartRecord part in parts)
            {
                if (part.def == CentaurScapular)
                {
                    CentaurScapularRecord = part;
                    break;
                }
            }

            if (!usedBy.health.hediffSet.HasHediff(HyperManipulatorHediff) && usedBy.def == DefDatabase<ThingDef>.GetNamed("Alien_Centaur"))
            {
                //   HealthUtility.AdjustSeverity(usedBy, HyperManipulatorHediff, 0.001f);

                usedBy.health.RestorePart(CentaurScapularRecord);
                usedBy.health.AddHediff(hediff, CentaurScapularRecord, null);
                //usedBy.health.AddHediff(hediff, null, null);
                hediff.Severity = 0.001f;

                this.parent.Destroy();
            }



        }
    }

}
