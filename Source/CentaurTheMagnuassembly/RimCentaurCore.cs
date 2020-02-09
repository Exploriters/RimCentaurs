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
    public class CompProperties_SelfHealOvertime : CompProperties
    {
        public double detlaHpPerSec = 0;
        public int ticksBetweenHeal = -1;

        public CompProperties_SelfHealOvertime() : base(typeof(CompSelfHealOvertime))
        {
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("", "IDE0051")]
        public CompProperties_SelfHealOvertime(Type cc) : base(cc == typeof(ThingComp) ? typeof(CompSelfHealOvertime) : cc)
        {
        }
        //GIVE UP FOR NOW TILL I K HOW TO DO
        /*public override IEnumerable<StatDrawEntry> SpecialDisplayStats(StatRequest req)
        {
            IEnumerable<StatDrawEntry> result = base.SpecialDisplayStats(req);
            double detlaHpPerSec=0;
            foreach (object cp in req.Thing.def.comps)
            {
                if (cp.GetType() == typeof(CompProperties_SelfHealOvertime))
                {
                    if (((CompProperties_SelfHealOvertime)cp).detlaHpPerSec != null && ((CompProperties_SelfHealOvertime)cp) != null)
                    {
                        detlaHpPerSec = ((CompProperties_SelfHealOvertime)cp).detlaHpPerSec;
                        if (detlaHpPerSec != 0D)
                        {

                            string valueString;
                            if (1 / Math.Abs(detlaHpPerSec) > 60000D)
                            {
                                valueString = "PeriodYears".Translate(detlaHpPerSec * 60000 + " /");
                            }
                            else if (1 / Math.Abs(detlaHpPerSec) > 15000D)
                            {
                                valueString = "PeriodQuadrums".Translate(detlaHpPerSec * 15000 + " /");
                            }
                            else if (1 / Math.Abs(detlaHpPerSec) > 1000D)
                            {
                                valueString = "PeriodDays".Translate(detlaHpPerSec * 1000 + " /");
                            }
                            else if (1 / Math.Abs(detlaHpPerSec) > 41.666666666666666666666666666667)
                            {
                                valueString = "PeriodHours".Translate(detlaHpPerSec * 41.666666666666666666666666666667 + " /");
                            }
                            else
                            {
                                valueString = "PeriodSeconds".Translate(detlaHpPerSec + " /");
                            }

                            StatDrawEntry stat_detla = new StatDrawEntry(
                                StatCategoryDefOf.Basics,
                                "Magnuassembly_CompProperties_SelfHealOvertime_detlaHpPerSec_label".Translate(),
                                valueString,
                                0,
                                "Magnuassembly_CompProperties_SelfHealOvertime_detlaHpPerSec_description".Translate());
                            (result as List<StatDrawEntry>).Add(stat_detla);
                        }
                    }
                }
            }
            return result;
        }*/
    }
    public class CompSelfHealOvertime : ThingComp
    {
        public double detlaHpPerSec = 0;
        public int ticksBetweenHeal = 60;
        public int ticksWithoutHeal = 0;
        private void OnTickAction(double tickRateFactor = 60.0)
        {
            if (detlaHpPerSec == 0 || parent.HitPoints == parent.MaxHitPoints || parent.HitPoints <= 0)
                return;

            ticksWithoutHeal++;

            if (ticksWithoutHeal >= ticksBetweenHeal)
            {
                double detlaHpAmount = detlaHpPerSec * (ticksWithoutHeal / tickRateFactor);


                double absheal = detlaHpAmount;
                int leastamount;
                if (detlaHpAmount < 0)
                {
                    absheal = -absheal;
                    leastamount = -(int)absheal;
                }
                else
                {
                    leastamount = (int)absheal;
                }

                Random rnd = new Random();

                double chancePerTick = detlaHpAmount % 1;
                parent.HitPoints += leastamount;

                for (int k = 0; k < chancePerTick; k++)
                {
                    if (rnd.Next(0, 9999) / 10000.0 < chancePerTick)
                    {
                        parent.HitPoints += 1;
                    }
                }
                if (parent.HitPoints > parent.MaxHitPoints)
                    parent.HitPoints = parent.MaxHitPoints;

                ticksWithoutHeal -= ticksBetweenHeal;
            }
        }
        public override void CompTick()
        {
            base.CompTick();
            detlaHpPerSec = ((CompProperties_SelfHealOvertime)props).detlaHpPerSec;
            if (((CompProperties_SelfHealOvertime)props).ticksBetweenHeal <= 0)
            {
                ticksBetweenHeal = (int)(60 / detlaHpPerSec + 0.5);
            }
            else
            {
                ticksBetweenHeal = ((CompProperties_SelfHealOvertime)props).ticksBetweenHeal;
            }
            OnTickAction(60);
        }
        /*public override void CompTickRare()
        {
            base.CompTickRare();
            OnTickAction(60);
        }*/
    }
    public class CompSnowExpand_Overtick : CompSnowExpand
    {
        public override void CompTick()
        {
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
            base.CompTick();
        }
        public override void CompTickRare()
        {
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
            base.CompTickRare();
        }
    }
    public class CompUseEffect_HediffApply_HManipulator : CompUseEffect_FixWorstHealthCondition
    {
        /*public override void CompTick()
        {
            base.CompTick();
        }*/
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

            for (int i = 0; i < 1000; i++)
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
    public class Hediff_AddedPart_HManipulator : Hediff_AddedPart
    {

    }
    public class HediffCompProperties_AgeStop : HediffCompProperties_SeverityPerDay
    {
        
    }
    public class JobDriver_UseItem_AlwasAvaible : JobDriver_UseItem
    {

    }


    public class HediffGiver_Overtime : HediffGiver
    {
        public float chancePerTick = 1;
        public float severityAdjust = 0.001f;
        public float doCount = 1;
        public bool doTryApply = true;


        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            /* FOOLED
            IEnumerable<BodyPartRecord> parts = pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined);

            BodyPartRecord Record = new BodyPartRecord();

            foreach (BodyPartRecord part in parts)
            {
                if (partsToAffect.Contains(part.def))
                {
                    Record = part;
                    break;
                }
            }

             pawn.health.AddHediff(this.hediff, null, null);
            HealthUtility.AdjustSeverity(pawn, this.hediff, 1f);*/

            Random rnd = new Random();
            for (int k = 0; k < doCount; k++)
            {
                if (rnd.Next(0, 9999) / 10000f < chancePerTick)
                {
                    if (doTryApply)
                        TryApply(pawn);
                    HealthUtility.AdjustSeverity(pawn, hediff, severityAdjust);
                }
            }
        }
    }

}
