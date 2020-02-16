using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using System.Diagnostics;
using System;
using static CentaurTheMagnuassembly.RimCentaurCore;
using UnityEngine;

namespace CentaurTheMagnuassembly
{
    /*public class FilthWithComps : ThingWithComps, Filth
    { 
    
    }*/
    public class Trishot_ResearchProjectDef : ResearchProjectDef
    {
        /*public override bool CanStartNow {
            get {
                return false;
            }
        }*/
    }
    public static class RimCentaurCore
    {
        public static readonly HediffDef HyperManipulatorHediffDef = DefDatabase<HediffDef>.GetNamed("HyperManipulator");
        public static readonly BodyPartDef CentaurScapularDef = DefDatabase<BodyPartDef>.GetNamed("CentaurScapular");
        public static readonly ThingDef AlienCentaurDef = DefDatabase<ThingDef>.GetNamed("Alien_Centaur");
        public static readonly PawnKindDef CentaurColonistDef = DefDatabase<PawnKindDef>.GetNamed("CentaurColonist");
        public static int InGameTick { get { return Find.TickManager.TicksGame; } }
        public static int InGameTickAbs { get { return Find.TickManager.TicksAbs; } }
        public static string FormattingTickTimeDiv(double number, string ToStringFormat = "0.00")
        {
            string valueString = "PeriodSeconds".Translate("NaN /");
            if (number != 0D)
            {
                if (1 / Math.Abs(number) >= 60000D)
                {
                    valueString = "PeriodYears".Translate((number * 60000).ToString(ToStringFormat) + " /");
                }
                else if (1 / Math.Abs(number) >= 15000D)
                {
                    valueString = "PeriodQuadrums".Translate((number * 15000).ToString(ToStringFormat) + " /");
                }
                else if (1 / Math.Abs(number) >= 1000D)
                {
                    valueString = "PeriodDays".Translate((number * 1000).ToString(ToStringFormat) + " /");
                }
                else if (1 / Math.Abs(number) >= 41.666666666666666666666666666667)
                {
                    valueString = "PeriodHours".Translate((number * 41.666666666666666666666666666667).ToString(ToStringFormat) + " /");
                }
                else
                {
                    valueString = "PeriodSeconds".Translate(number.ToString(ToStringFormat) + " /");
                }
            }
            return valueString;
        }
        public static string FormattingTickTime(double number, string ToStringFormat = "0.00")
        {
            string valueString;
            if (Math.Abs(number) >= 60000D)
            {
                valueString = "PeriodYears".Translate((number / 60000).ToString(ToStringFormat));
            }
            else if (Math.Abs(number) >= 15000D)
            {
                valueString = "PeriodQuadrums".Translate((number / 15000).ToString(ToStringFormat));
            }
            else if (Math.Abs(number) >= 1000D)
            {
                valueString = "PeriodDays".Translate((number / 1000).ToString(ToStringFormat));
            }
            /*else if (Math.Abs(number) > 416.66666666666666666666666666667)
            {
                valueString = "PeriodHours".Translate((number / 41.666666666666666666666666666667).ToString(ToStringFormat));
            }*/
            else
            {
                valueString = "PeriodSeconds".Translate(number.ToString(ToStringFormat));
            }
            return valueString;
        }
        public static Color CastingPixel(Color color)
        {
            System.Random Randy = new System.Random();
            if (Randy.Next(0, 1) == 1)
                return color;
            color.r = (color.r * (1 - color.a)) + (0.5f * color.a);
            color.g = (color.g * (1 - color.a)) + (0.5f * color.a);
            color.b = (color.b * (1 - color.a)) + (0.5f * color.a);
            color.a = Math.Max(0.5f, color.a);
            return color;
        }
        /// <summary>
        /// https://blog.csdn.net/qq_39776199/article/details/81506293
        /// </summary>
        /*public static Texture2D duplicateTexture(Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                        source.width,
                        source.height,
                        0,
                        RenderTextureFormat.Default,
                        RenderTextureReadWrite.Linear);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableText = new Texture2D(source.width, source.height);
            readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableText.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            return readableText;
        }
        public static Texture2D duplicateTexture(Texture2D source)
        {
            byte[] pix = source.GetRawTextureData();
            Texture2D readableText = new Texture2D(source.width, source.height, source.format, false);
            readableText.LoadRawTextureData(pix);
            readableText.Apply();
            return readableText;
        }
        public static Texture2D FloodingTexture(Texture2D inputtex, float range)
        {
            Texture2D target = duplicateTexture(inputtex);
            //range = new System.Random().Next(0,10000)/10000f;\
            //Log.Message("[Magnuassembly]Casting " + target + " by " + range + ".", true);
            if (range <= 0f)
                return target;
            if (range > 1f)
                range = 1f;
            int width = target.width;
            int height = target.height;
            int heightLevel = (int)(height * range);
            int counter = 0;

            for (int X = 0; X < width; X++)
            {
                for (int Y = heightLevel; Y < height; Y++)
                {
                    target.SetPixel(X, Y, CastingPixel(target.GetPixel(X, Y)));
                    counter++;
                }
            }
            //Log.Message("[Magnuassembly]Casted " + counter + " pixels. ", true);
            return target;
        }*/
        public static Texture2D FloodingTexture(Texture2D inputtex, float range)
        {
            return inputtex;

            /*if (range <= 0f)
                return inputtex;
            if (range > 1f)
                range = 1f;
            int width = inputtex.width;
            int height = inputtex.height;
            int heightLevel = (int)(height * range);
            int counter = 0;*/
        }
    }
    public class Verb_DoNothing : Verb
    {
        protected override bool TryCastShot()
        {
            //throw new NotImplementedException();
            return false;
        }
    }
    /// <summary>
    /// TODO: Fix relation
    /// </summary>
    public class ThoughtWorker_AlwaysActive_Centaur : ThoughtWorker // ThoughtWorker_AlwaysActive
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            Log.Message("[Magnuassembly]Soving CurrentSocialStateInternal between \"" + p.Name.ToStringShort + "(" + p.def.defName + ")\" and " + otherPawn.Name.ToStringShort + "(" + otherPawn.def.defName + ")\".");
            if (p.def == AlienCentaurDef && otherPawn.def == AlienCentaurDef)
            {
                //return base.CurrentSocialStateInternal(p, otherPawn);
                return ThoughtState.ActiveAtStage(stageIndex: 0);
            }
            else
                return false;
        }
        /*protected override ThoughtState CurrentStateInternal(Pawn p)
        { 
            
        }*/
    }

}
