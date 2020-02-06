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
        public override bool CanBeUsedBy(Pawn usedBy, out string failReason)
        {
            HediffDef HyperManipulatorHediff = DefDatabase<HediffDef>.GetNamed("HyperManipulator");

            if (usedBy.health.hediffSet.HasHediff(HyperManipulatorHediff))
            {
                failReason = "Magnuassembly_CompUseEffect_HediffApply_HManipulator_UseReject_AlreadyInstalled".Translate(usedBy.Name.ToStringShort);
                return false;
            }

            if (usedBy.def != DefDatabase<ThingDef>.GetNamed("Alien_Centaur"))
            {
                failReason = "Magnuassembly_CompUseEffect_HediffApply_HManipulator_UseReject_NonCentaur".Translate(usedBy.def.LabelCap);
                return false;
            }

            failReason = "";
            return true;
        }
        public override void DoEffect(Pawn usedBy)
        {

            HediffDef HyperManipulatorHediff = DefDatabase<HediffDef>.GetNamed("HyperManipulator");
            Hediff hediff = HediffMaker.MakeHediff(HyperManipulatorHediff, usedBy, null);

            BodyPartDef CentaurScapular = DefDatabase<BodyPartDef>.GetNamed("CentaurScapular");
            BodyPartRecord CentaurScapularRecord = new BodyPartRecord();
            //CentaurScapularRecord.body = DefDatabase<BodyDef>.GetNamed("Centaur");
            //CentaurScapularRecord.def = CentaurScapular;
            //CentaurScapularRecord.parts.Count = 1;
            bool PartNotFound = true;

            IEnumerable<BodyPartRecord> parts = usedBy.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined);
            
            if (!CanBeUsedBy(usedBy, out _))
                return;

            for(int i =0; i <1000;i++)
            {
                foreach (BodyPartRecord part in parts)
                {
                    if (part.def == CentaurScapular)
                    {
                        CentaurScapularRecord = part;
                        PartNotFound = false;
                        break;
                    }
                }
                if (PartNotFound)
                {
                    base.DoEffect(usedBy);
                }
                else
                {
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
