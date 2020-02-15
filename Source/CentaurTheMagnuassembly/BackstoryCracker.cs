using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RimWorld;
using Verse;
using static CentaurTheMagnuassembly.RimCentaurCore;

namespace CentaurTheMagnuassembly
{
    [StaticConstructorOnStartup]
    internal static class BackstoryCracker
    {
        public static string targetTag = "Civil";
        public static string appTagPrefix = "CentaurAdulthood";
        public static BackstorySlot backstorySlot = BackstorySlot.Adulthood;
        static BackstoryCracker()
        {
            THE_ULTRA_FLOOD();
            //AddExtraPrefixViaTag();
            //ExportBackstoriesToLog();
        }
        public static void THE_ULTRA_FLOOD()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Message("[Magnuassembly]Backstory flooder triggered.");

            uint solvedBackstoryCount = 0;

            string[] BStheFLOOD = {
                "ColonySettler53",
                "UrbworldEntrepreneur14",
                "DeepSpaceMiner3",
                "NavyScientist46",
                "MilitaryCommissar49",
                "MedievalDoctor40",
                "Inventor6",
                "Teacher20",
                "GlitterworldSurgeon15",
                "Bartender55",
                "CaveworldIlluminator23",
                "Herbalist54",
                "CivilServant2",
                "StarshipJanitor33",
                "Paramedic45",
                "Geologist66",
                "Drifter67",
                "MachineCollector55",
                "Sheriff52",
                "CivilEngineer23",
                "GraphicDesigner99",
                "MilitaryEngineer45",
                "Reporter51",
                "Archaeologist85",
                "EngineeredPilot9",
                "SpaceHumanitarian9",
                "StateEngineer18",
                "SpaceHunter67",
                "ArmyScientist35",
                "Mercenary40",
                "Microbiologist35",
                "InformationBroker77",
                "MedicalScientist25",
                "CoreWorldJeweler59",
                "SpaceshipSalesman6",
                "RocketEngineer31",
                "CombatEngineer4",
                "Guardian55",
                "UrbworldSergeant71",
                "EnergyResearcher67",
                "LoneTraveler95",
                "HiredAssassin2",
                "Engineer47",
                "ArtificerRampant24",
                "NeuroScientist84",
                "HedgeFundManager85",
                "ExiledResearcher68",
                "SpaceNavyDoctor72",
                "SpaceRaider65",
                "Spy58",
                "SanitationCaptain28",
                "CorpResearcher93",
                "Explorer28",
                "StarshipDoctor82",
                "BountyHunter41",
                "OrbitalReservist22",
                "ParticlePhysicist78",
                "ProstheticSurgeon0",
                "StilettoAssassin50",
                "ExoticChef96",
                "Blacksmith7",
                "PoliticalActivist61",
                "Flaneur69",
                "AddictionCounsel60",
                "BattleMechanic27",
                "Chemist73",
                "MechanicsEngineer64",
                "NetworkEngineer83",
                "Caravaneer53",
                "MilitaryGunsmith27",
                "Aromatherapist80",
                "SpaceBartender0",
                "ShockTrooper15",
                "PirateDoctor0",
                "BloodyDentist9",
                "MasterChef48",
                "WarshipCaptain67",
                "RunawayDancer35",
                "TheaterTechnician98",
                "ArmySergeant1",
                "StellarPirate99",
                "LanguageAnalyst27",
                "Philosopher97",
                "CasketBuilder76",
                "Fugitive32",
                "GunDealer14",
                "DeepSpaceSurveyor87",
                "RenownedProfessor51",
                "SpaceMarineMedic10",
                "ShadowMarine63",
            };

            string solved = "";

            foreach (string str in BStheFLOOD)
            {
                BackstoryDatabase.allBackstories.TryGetValue(str).spawnCategories.Add("CentaurAdulthoodCivil");
                solved += $"{str}, ";
                solvedBackstoryCount++;
            }
            Log.Message($"[Magnuassembly]Solved CentaurAdulthoodCivil: {(solved+"&").Replace(", &",".")}");
            stopwatch.Stop();
            Log.Message($"[Magnuassembly]Backstory export complete, solved total {solvedBackstoryCount} backstories, in {stopwatch.ElapsedMilliseconds}ms.");

        }
        public static void AddExtraPrefixViaTag()
        {
            uint solvedBackstoryCount = 0;
            uint solvedTagCount = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Message("[Magnuassembly]Backstory cracker triggered for \"" + targetTag + "\" in \"" + backstorySlot + "\" by \"" + appTagPrefix + "\".");

            Dictionary<string, Backstory> DiBs = BackstoryDatabase.allBackstories;
            Log.Message("[Magnuassembly]Scanning backstory total : " + DiBs.Count);
            foreach (KeyValuePair<string, Backstory> Bs in DiBs)
            {
                if (
                    Bs.Value.slot == backstorySlot
                    && Bs.Value.DisabledWorkGivers.Count() == 0
                    && Bs.Value.DisabledWorkTypes.Count() == 0
                    && Bs.Value.workDisables == 0
                    && Bs.Value.spawnCategories.Contains("Civil")
                    )
                {
                    //Log.Message("[Magnuassembly]Scanning backstory in DiBs[" + Bs.Key + "]" + Bs.Value.identifier + " : " + Bs.Value.title);
                    if (Bs.Value.identifier.StartsWith(appTagPrefix))
                    {
                        Bs.Value.requiredWorkTags = (WorkTags)65535;
                    }
                    List<string> posttag = new List<string>();
                    foreach (string tag in Bs.Value.spawnCategories)
                    {
                        if (!Bs.Value.identifier.StartsWith(appTagPrefix))
                        {
                            posttag.Add(appTagPrefix + tag);
                        }
                    }
                    foreach (string tag in posttag)
                    {
                        //Log.Message("[Magnuassembly]Adding \"" + tag + "\" to backstory " + Bs.Value.identifier + " : " + Bs.Value.title);
                        Bs.Value.spawnCategories.Add(tag);
                        solvedTagCount++;
                    }
                    solvedBackstoryCount++;
                }
            }
            stopwatch.Stop();
            Log.Message("[Magnuassembly]Backstory crack complete, solved total " + solvedTagCount + " tags in " + solvedBackstoryCount + " backstories, in " + stopwatch.ElapsedMilliseconds + "ms.");
        }
        public static void ExportBackstoriesToLog()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Dictionary<string, Backstory> DiBs = BackstoryDatabase.allBackstories;
            Log.Message("[Magnuassembly]Scanning backstory total : " + DiBs.Count);
            uint solvedBackstoryCount = 0;

            string result = "[Magnuassembly]Export backstories:\n";

            foreach (KeyValuePair<string, Backstory> Bs in DiBs)
            {
                if (Bs.Value.spawnCategories.Contains("CentaurAdulthoodCivil"))
                {
                    result += $"identifier:{Bs.Value.identifier}, title:{Bs.Value.titleShort}/{Bs.Value.title}, Desc:\"{Bs.Value.baseDesc}\".\n";
                    solvedBackstoryCount++;
                }
            }
            stopwatch.Stop();
            Log.Message(result);
            Log.Message($"[Magnuassembly]Backstory export complete, solved total {solvedBackstoryCount} backstories, in {stopwatch.ElapsedMilliseconds}ms.");

        }
    }
    /*public class BackstoryPrefixDef : Def
    {
        public string targetTag = "Civil";
        public string appTagPrefix = "Centaur";
        public BackstorySlot backstorySlot = BackstorySlot.Adulthood;
    }*/

}
