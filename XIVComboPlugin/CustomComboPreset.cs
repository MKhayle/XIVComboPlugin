using System;
using XIVCombo.Attributes;
using XIVCombo.Combos;

using UTL = XIVCombo.Attributes.IconsComboAttribute;

namespace XIVCombo;

/// <summary>
/// Combo presets.
/// </summary>
public enum CustomComboPreset
{
    // ====================================================================================
    #region Misc

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", ADV.JobID)]
    AdvAny = 0,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", AST.JobID)]
    AstAny = AdvAny + AST.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BLM.JobID)]
    BlmAny = AdvAny + BLM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BRD.JobID)]
    BrdAny = AdvAny + BRD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DNC.JobID)]
    DncAny = AdvAny + DNC.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOH.JobID)]
    DohAny = AdvAny + DOH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOL.JobID)]
    DolAny = AdvAny + DOL.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRG.JobID)]
    DrgAny = AdvAny + DRG.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRK.JobID)]
    DrkAny = AdvAny + DRK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", GNB.JobID)]
    GnbAny = AdvAny + GNB.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MCH.JobID)]
    MchAny = AdvAny + MCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MNK.JobID)]
    MnkAny = AdvAny + MNK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", NIN.JobID)]
    NinAny = AdvAny + NIN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PLD.JobID)]
    PldAny = AdvAny + PLD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PCT.JobID)]
    PctAny = AdvAny + PCT.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RDM.JobID)]
    RdmAny = AdvAny + RDM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RPR.JobID)]
    RprAny = AdvAny + RPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SAM.JobID)]
    SamAny = AdvAny + SAM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SCH.JobID)]
    SchAny = AdvAny + SCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SGE.JobID)]
    SgeAny = AdvAny + SGE.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SMN.JobID)]
    SmnAny = AdvAny + SMN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", VPR.JobID)]
    VprAny = AdvAny + VPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
    WarAny = AdvAny + WAR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
    WhmAny = AdvAny + WHM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BST.JobID)]
    BstAny = AdvAny + BST.JobID,

    [CustomComboInfo("Disabled", "This should not be used.", ADV.JobID)]
    Disabled = 99999,

    #endregion
    // ====================================================================================
    #region ADV

    #endregion
    // ====================================================================================
    #region ASTROLOGIAN

    [SectionCombo("Draw features")]
    [IconsCombo([AST.Play1, AST.Play2, AST.Play3, AST.MinorArcanaDT, UTL.ArrowLeft, AST.AstralDraw, AST.UmbralDraw])]
    [CustomComboInfo("Play to Astral/Umbral Draw", "Replace Play I / II / III & Minor Arcana with with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianPlayDrawFeature = 3323,

    #endregion
    // ====================================================================================
    #region BLACK MAGE

    [IconsCombo([BLM.Fire4, BLM.Flare, UTL.Cycle, BLM.Blizzard4, BLM.Freeze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Enochian Feature", "Replace Fire 4/Flare and Blizzard 4/Freeze with whichever action you can currently use.", BLM.JobID)]
    BlackEnochianFeature = 2501,

    #endregion
    // ====================================================================================
    #region BARD

    [IconsCombo([BRD.StraightShot, UTL.ArrowLeft, BRD.HeavyShot, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Heavy Shot into Straight Shot", "Replace Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
    BardStraightShotUpgradeFeature = 2302,

    [IconsCombo([BRD.QuickNock, UTL.ArrowLeft, BRD.WideVolley, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Quick Nock into Wide Volley/Shadowbite", "Replace Quick Nock with Wide Volley/Shadowbite when available.", BRD.JobID)]
    BardShadowbiteFeature = 2305,

    #endregion
    // ====================================================================================
    #region DANCER

    [IconsCombo([DNC.Windmill, UTL.ArrowLeft, DNC.RisingWindmill, UTL.Blank, DNC.Bladeshower, UTL.ArrowLeft, DNC.Bloodshower])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("AoE to Procs", "Replace Windmill and Bladeshower with Rising Windmill and Bloodshower respectively when available.", DNC.JobID)]
    DancerAoeProcs = 3812,

    [IconsCombo([DNC.FanDance1, DNC.FanDance2, UTL.ArrowLeft, DNC.FanDance3, UTL.Blank, DNC.Buffs.ThreefoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [CustomComboInfo("Fan Dance 3 Feature", "Replace Fan Dance and Fan Dance 2 with Fan Dance 3 when available.", DNC.JobID)]
    DancerFanDance3Feature = 3801,

    [IconsCombo([DNC.Flourish, UTL.ArrowLeft, DNC.FanDance4, UTL.Blank, DNC.Buffs.FourfoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [CustomComboInfo("Flourishing Fan Dance 4", "Replace Flourish with Fan Dance 4 when available.", DNC.JobID)]
    DancerFlourishFan4Feature = 3808,

    [IconsCombo([DNC.StandardStep, UTL.ArrowLeft, DNC.LastDance, UTL.Blank, DNC.Buffs.LastDanceReady, UTL.Checkmark])]
    [SectionCombo("Dances features")]
    [CustomComboInfo("Last Dance Feature", "Replace Standard Step by Last Dance if available.", DNC.JobID)]
    DancerLastDanceFeature = 3813,

    #endregion
    // ====================================================================================
    #region DARK KNIGHT

    [SectionCombo("Single Target")]
    [IconsCombo([DRK.Souleater, UTL.ArrowLeft, DRK.SyphonStrike, UTL.ArrowLeft, DRK.HardSlash])]
    [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
    DarkSouleaterCombo = 3201,

    [SectionCombo("Area of Effect")]
    [IconsCombo([DRK.StalwartSoul, UTL.ArrowLeft, DRK.Unleash])]
    [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
    DarkStalwartSoulCombo = 3202,

    #endregion
    // ====================================================================================
    #region DRAGOON

    [TintableCombo]
    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.FangAndClaw, UTL.ArrowLeft, DRG.FullThrust, UTL.ArrowLeft, DRG.VorpalThrust, UTL.ArrowLeft, DRG.TrueThrust])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
    DragoonFullThrustCombo = 2204,

    [TintableCombo]
    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.WheelingThrust, UTL.ArrowLeft, DRG.ChaosThrust, UTL.ArrowLeft, DRG.Disembowel, UTL.ArrowLeft, DRG.TrueThrust])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
    DragoonChaosThrustCombo = 2203,

    [IconsCombo([DRG.CoerthanTorment, UTL.ArrowLeft, DRG.SonicThrust, UTL.ArrowLeft, DRG.DoomSpike])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
    DragoonCoerthanTormentCombo = 2202,

    #endregion
    // ====================================================================================
    #region GUNBREAKER

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.SolidBarrel, UTL.ArrowLeft, GNB.BrutalShell, UTL.ArrowLeft, GNB.KeenEdge])]
    [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
    GunbreakerSolidBarrelCombo = 3701,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.Hypervelocity, UTL.ArrowLeft, GNB.BurstStrike, UTL.Blank, GNB.Buffs.ReadyToBlast, UTL.Checkmark])]
    [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerBurstStrikeCont = 3703,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.EyeGouge, UTL.ArrowLeft, GNB.WickedTalon, UTL.ArrowLeft, GNB.AbdomenTear, UTL.ArrowLeft, GNB.SavageClaw, UTL.ArrowLeft, GNB.JugularRip, UTL.ArrowLeft, GNB.GnashingFang])]
    [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerGnashingFangCont = 3702,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.DemonSlaughter, UTL.ArrowLeft, GNB.DemonSlice])]
    [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
    GunbreakerDemonSlaughterCombo = 3705,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.FatedCircle, UTL.ArrowLeft, GNB.FatedBrand, UTL.Blank, GNB.Buffs.ReadyToFated, UTL.Checkmark])]
    [CustomComboInfo("Fated Circle Continuation", "Replace Fated Circle with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerFatedCircleCont = 3714,

    #endregion
    // ====================================================================================
    #region MACHINIST

    [IconsCombo([MCH.CleanShot, UTL.ArrowLeft, MCH.SplitShot, UTL.ArrowLeft, MCH.SlugShot])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("(Heated) Shot Combo", "Replace Clean Shot with its combo chain.", MCH.JobID)]
    MachinistMainCombo = 3101,

    [IconsCombo([MCH.Hypercharge, UTL.ArrowLeft, MCH.HeatBlast, UTL.Blank, MCH.Buffs.Overheat, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Hypercharge Blaster", "Replaces Hypercharge with Heat Blast while overheated.", MCH.JobID)]
    MachinistHypercomboFeature = 3108,

    [IconsCombo([MCH.SpreadShot, UTL.ArrowLeft, MCH.AutoCrossbow, UTL.Blank, MCH.Buffs.Overheat, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow while overheated.", MCH.JobID)]
    MachinistSpreadShotFeature = 3102,

    #endregion
    // ====================================================================================
    #region MONK

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.DragonKick])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Opo Feature", "Replace Bootshine/Leaping Opo with Dragon Kick if you don't have any Opo's fury stack.", MNK.JobID)]
    MonkOpoFeature = 2017,

    [IconsCombo([MNK.TrueStrike, UTL.ArrowLeft, MNK.TwinSnakes])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Raptor Feature", "Replace True Strike with Twin Snakes if you don't have any Raptor's fury stack.", MNK.JobID)]
    MonkRaptorFeature = 2018,

    [IconsCombo([MNK.SnapPunch, UTL.ArrowLeft, MNK.Demolish])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Coeurl Feature", "Replace Snap Punch with Demolish if you don't have any Coeurl's fury stack.", MNK.JobID)]
    MonkCoeurlFeature = 2019,

    [IconsCombo([MNK.PerfectBalance, UTL.ArrowLeft, MNK.MasterfulBlitz, UTL.Blank, UTL.Blank, UTL.Checkmark])]
    [SectionCombo("Masterful Blitz")]
    [CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra.", MNK.JobID)]
    MonkPerfectBalanceFeature = 2004,

    #endregion
    // ====================================================================================
    #region NINJA

    [TintableCombo]
    [IconsCombo([NIN.AeolianEdge, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
    NinjaAeolianEdgeCombo = 3002,

    [TintableCombo]
    [IconsCombo([NIN.ArmorCrush, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
    NinjaArmorCrushCombo = 3001,

    [IconsCombo([NIN.HakkeMujinsatsu, UTL.ArrowLeft, NIN.DeathBlossom])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
    NinjaHakkeMujinsatsuCombo = 3003,

    #endregion
    // ====================================================================================
    #region PALADIN

    [IconsCombo([PLD.RoyalAuthority, UTL.ArrowLeft, PLD.RiotBlade, UTL.ArrowLeft, PLD.FastBlade])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
    PaladinRoyalAuthorityCombo = 1902,

    [IconsCombo([PLD.Prominence, UTL.ArrowLeft, PLD.TotalEclipse])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
    PaladinProminenceCombo = 1904,

    [IconsCombo([PLD.Requiescat, UTL.ArrowLeft, PLD.Confiteor, PLD.BladeOfFaith, PLD.BladeOfTruth, PLD.BladeOfValor, PLD.BladeOfHonor])]
    [SectionCombo("Cooldowns")]
    [CustomComboInfo("Requiescat/Imperator Confiteor", "Replace Requiescat/Imperator with Confiteor and combo chain when available, and then with Holy Spirit if there are remaining charges.", PLD.JobID)]
    PaladinRequiescatConfiteorFeature = 1905,

    #endregion
    // ====================================================================================
    #region PICTOMANCER

    [IconsCombo([PCT.FireRedST, UTL.ArrowLeft, PCT.BlizzardCyanST, UTL.Blank, PCT.SubstractivePalette, UTL.Cross])]
    [SectionCombo("Substractive")]
    [CustomComboInfo("Subtractive Single-Target Combo", "Fire in Red's combo chain is always correct even when under Substractive Palette's effect.", PCT.JobID)]
    PictomancerSubtractiveSTCombo = 4201,

    [IconsCombo([PCT.FireRedAoE, UTL.ArrowLeft, PCT.BlizzardCyanAoE, UTL.Blank, PCT.SubstractivePalette, UTL.Cross])]
    [SectionCombo("Substractive")]
    [CustomComboInfo("Subtractive AoE Combo", "Fire in Red II's combo chain is always correct even when under Substractive Palette's effect.", PCT.JobID)]
    PictomancerSubtractiveAoECombo = 4202,

    [IconsCombo([PCT.CreatureMotif, UTL.ArrowLeft, PCT.LivingMuse, UTL.Blank, PCT.PomMuse, PCT.WingedMuse, PCT.ClawedMuse, PCT.FangedMuse, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Creature Muse/Motif Combo", "Replace Creature Motifs with Creature Muses when the Creature Canvas is painted.", PCT.JobID)]
    PictomancerCreatureMotifCombo = 4206,

    [IconsCombo([PCT.CreatureMotif, UTL.ArrowLeft, PCT.MogOftheAges, PCT.Retribution, UTL.Blank, PCT.MogOftheAges, PCT.Retribution, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [ParentCombo(PictomancerCreatureMotifCombo)]
    [CustomComboInfo("Creature Muse/Mog of the Ages Combo", "Also replace Creature Motifs with Mog of the Ages and Retribution of the Madeen when they are usable.", PCT.JobID)]
    PictomancerCreatureMogCombo = 4207,

    [IconsCombo([PCT.WeaponMotif, UTL.ArrowLeft, PCT.StrikingMuse, UTL.Blank, PCT.HammerMotif, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Weapon Muse/Motif Combo", "Replace Hammer Motif with Striking Muse when the Weapon Canvas is painted.", PCT.JobID)]
    PictomancerWeaponMotifCombo = 4208,

    [IconsCombo([PCT.HammerMotif, UTL.ArrowLeft, PCT.HammerStamp, PCT.HammerBrush, PCT.PolishingHammer, UTL.Blank, PCT.Buffs.HammerReady, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Hammer Time", "Replace Hammer Motif with Hammer Brush and its combo chain when they are usable.", PCT.JobID)]
    PictomancerWeaponHammerCombo = 4209,

    [IconsCombo([PCT.LandscapeMotif, UTL.ArrowLeft, PCT.ScenicMuse, UTL.Blank, PCT.StarryMuse, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Starry Muse/Motif Combo", "Replace Starry Sky Motif with Starry Muse when the Landscape Canvas is painted.", PCT.JobID)]
    PictomancerLandscapeMotifCombo = 4210,

    [IconsCombo([PCT.StarryMuse, UTL.ArrowLeft, PCT.StarPrism, UTL.Blank, PCT.Buffs.StarPrismReady, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Starry Muse/Star Prism Combo", "Replace Starry Muse with Star Prism when it is usable.  Also replaces Starry Sky Motif if the Starry Muse/Motif Combo is selected.", PCT.JobID)]
    PictomancerLandscapePrismCombo = 4211,

    [IconsCombo([PCT.HolyWhite, UTL.ArrowLeft, PCT.CometBlack, UTL.Blank, PCT.CometBlack, UTL.Checkmark])]
    [SectionCombo("Holy Comet")]
    [CustomComboInfo("Holy Comet Combo", "Replace Holy in White with Comet in Black when usable.", PCT.JobID)]
    PictomancerHolyCometCombo = 4203,

    #endregion
    // ====================================================================================
    #region REAPER
    // Currently unused: 3913, 3914, 3915, 3919, 3920, 3921, 3922, 3923, 3924, 3927, 3928, 3929, 3935, 3941, 3946

    [IconsCombo([RPR.InfernalSlice, UTL.ArrowLeft, RPR.WaxingSlice, UTL.ArrowLeft, RPR.Slice])]
    [SectionCombo("Main Combos")]
    [CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
    ReaperSliceCombo = 3901,

    [IconsCombo([RPR.NightmareScythe, UTL.ArrowLeft, RPR.SpinningScythe])]
    [SectionCombo("Main Combos")]
    [CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
    ReaperScytheCombo = 3902,

    [IconsCombo([RPR.Enshroud, UTL.ArrowLeft, RPR.Communio, UTL.Blank, RPR.Buffs.Enshrouded, UTL.Checkmark])]
    [SectionCombo("Enshroud")]
    [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
    ReaperEnshroudCommunioFeature = 3909,

    [IconsCombo([RPR.ArcaneCircle, UTL.ArrowLeft, RPR.PlentifulHarvest, UTL.Blank, RPR.Buffs.ImmortalSacrifice, UTL.Checkmark])]
    [SectionCombo("Arcane Circle")]
    [CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID)]
    ReaperArcaneHarvestFeature = 3908,

    [IconsCombo([RPR.HellsIngress, RPR.HellsEgress, UTL.ArrowLeft, RPR.Regress, UTL.Blank, RPR.Buffs.Threshold])]
    [SectionCombo("Miscellaneous")]
    [CustomComboInfo("Regress Feature", "Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
    ReaperRegressFeature = 3910,

    #endregion
    // ====================================================================================
    #region RED MAGE
    [TintableCombo]
    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Jolt, UTL.Blank, RDM.Buffs.VerstoneReady, RDM.Buffs.VerfireReady, UTL.Cross])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Verstone/Verfire Feature", "Replace Verstone/Verfire with Jolt when no proc is available.", RDM.JobID)]
    RedMageVerprocFeature = 3504,

    [TintableCombo]
    [ParentCombo(RedMageVerprocFeature)]
    [CustomComboInfo("Separate Verfire Jolt Color", "Pick a distinct color for the Jolt shown on the Verfire button, instead of sharing the color above.", RDM.JobID)]
    RedMageVerprocVerfireTint = 3505,

    [IconsCombo([RDM.Veraero2, RDM.Verthunder2, UTL.ArrowLeft, RDM.Impact, UTL.Blank, RDM.Buffs.Acceleration, ADV.Swiftcast, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("AoE Combo", "Replace Veraero/Verthunder 2 with Impact when various instant-cast effects are active.", RDM.JobID)]
    RedMageAoEFeature = 3501,

    [IconsCombo([RDM.EnchantedRedoublement, RDM.Redoublement, UTL.ArrowLeft, RDM.EnchantedZwerchhau, RDM.Zwerchhau, UTL.ArrowLeft, RDM.EnchantedRiposte, RDM.Riposte])]
    [SectionCombo("Melee features")]
    [CustomComboInfo("Melee Combo", "Replace Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
    RedMageMeleeCombo = 3502,

    #endregion
    // ====================================================================================
    #region SAGE

    
    #endregion
    // ====================================================================================
    #region SAMURAI

    [TintableCombo]
    [IconsCombo([SAM.Yukikaze, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
    SamuraiYukikazeCombo = 3401,

    [TintableCombo]
    [IconsCombo([SAM.Gekko, UTL.ArrowLeft, SAM.Jinpu, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
    SamuraiGekkoCombo = 3402,

    [TintableCombo]
    [IconsCombo([SAM.Kasha, UTL.ArrowLeft, SAM.Shifu, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
    SamuraiKashaCombo = 3403,

    [TintableCombo]
    [IconsCombo([SAM.Mangetsu, UTL.ArrowLeft, SAM.Fuga, SAM.Fuko])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its own combo chain.", SAM.JobID)]
    SamuraiMangetsuCombo = 3404,

    [TintableCombo]
    [IconsCombo([SAM.Oka, UTL.ArrowLeft, SAM.Fuga, SAM.Fuko])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Oka Combo", "Replace Oka with its own combo chain.", SAM.JobID)]
    SamuraiOkaCombo = 3405,

    [IconsCombo([SAM.Iaijutsu, UTL.ArrowLeft, SAM.TsubameGaeshi])]
    [SectionCombo("Iaijutsu")]
    [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when it is usable.", SAM.JobID)]
    SamuraiIaijutsuTsubameGaeshiFeature = 3409,

    #endregion
    // ====================================================================================
    #region SCHOLAR

    [IconsCombo([SCH.EnergyDrain, UTL.ArrowLeft, SCH.Aetherflow, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ED Aetherflow", "Replace Energy Drain with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarEnergyDrainAetherflowFeature = 2802,

    #endregion
    // ====================================================================================
    #region SUMMONER

    [IconsCombo([SMN.Fester, UTL.ArrowLeft, SMN.EnergyDrain, UTL.Blank, SMN.EnergyDrain, UTL.Cross])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ED Fester/Necrosis Feature", "Replace Fester/Necrosis with Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
    SummonerEDFesterFeature = 2701,

    [IconsCombo([SMN.Painflare, UTL.ArrowLeft, SMN.EnergySyphon, UTL.Blank, SMN.EnergySyphon, UTL.Cross])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ES Painflare Feature", "Replace Painflare with Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
    SummonerESPainflareFeature = 2702,

    [IconsCombo([SMN.SummonBahamut, UTL.ArrowLeft, SMN.LuxSolaris, UTL.Blank, SMN.Buffs.LuxSolarisReady, UTL.Checkmark])]
    [SectionCombo("Summons features")]
    [CustomComboInfo("Summon Lux Solaris Feature", "Replace Summon Bahamut with Lux Solaris when you have Refulgent Lux ready.", SMN.JobID)]
    SummonerSummonLuxSolarisFeature = 2717,

    #endregion
    // ====================================================================================
    #region VIPER

    [SectionCombo("Standard Combos")]
    [IconsCombo([VPR.SteelFangs, VPR.ReavingFangs, UTL.ArrowLeft, VPR.DeathRattle, UTL.Blank, VPR.SteelMaw, VPR.ReavingMaw, UTL.ArrowLeft, VPR.LastLash])]
    [CustomComboInfo("Serpent's Fang Feature", "Replace Steel Fangs, Reaving Fangs, Steel Maw, and Reaving Maw with Serpent's Tail after finishing a combo.", VPR.JobID)]
    ViperSteelTailFeature = 4101,

    [SectionCombo("Vicewinder")]
    [IconsCombo([VPR.HuntersCoil, UTL.ArrowLeft, VPR.TwinfangBite, UTL.ArrowLeft, VPR.TwinbloodBite, UTL.Blank, VPR.SwiftskinsCoil, UTL.ArrowLeft, VPR.TwinbloodBite, UTL.ArrowLeft, VPR.TwinfangBite])]
    [CustomComboInfo("Coil Twin Feature", "Replace Hunter's Coil and Swiftskin's Coil with their available Twinfang and Twinblood actions.", VPR.JobID)]
    ViperCoilTwinsFeature = 4106,

    [SectionCombo("Vicepit")]
    [IconsCombo([VPR.HuntersDen, UTL.ArrowLeft, VPR.TwinfangThresh, UTL.ArrowLeft, VPR.TwinbloodThresh, UTL.Blank, VPR.SwiftskinsDen, UTL.ArrowLeft, VPR.TwinbloodThresh, UTL.ArrowLeft, VPR.TwinfangThresh])]
    [CustomComboInfo("Den Twin Feature", "Replace Hunter's Den and Swiftskin's Den with their available Twinfang and Twinblood actions.", VPR.JobID)]
    ViperDenTwinsFeature = 4107,

    [SectionCombo("Uncoiled Fury")]
    [IconsCombo([VPR.UncoiledFury, UTL.ArrowLeft, VPR.UncoiledTwinfang, UTL.ArrowLeft, VPR.UncoiledTwinblood])]
    [CustomComboInfo("Uncoiled Fury Twin Feature", "Replace Uncoiled Fury with its Uncoiled Twinfang and Uncoiled Twinblood follow-ups.", VPR.JobID)]
    ViperUncoiledTwinsFeature = 4108,

    [SectionCombo("Reawaken")]
    [IconsCombo([VPR.FirstGeneration, VPR.FirstLegacy, VPR.SecondGeneration, VPR.SecondLegacy, VPR.ThirdGeneration, VPR.ThirdLegacy, VPR.FourthGeneration, VPR.FourthLegacy, UTL.Blank])]
    [CustomComboInfo("Generation Legacy Feature", "Replace the Generation skills with their respective Legacies.", VPR.JobID)]
    ViperGenerationLegaciesFeature = 4105,

    #endregion
    // ====================================================================================
    #region WARRIOR

    [TintableCombo]
    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.Maim, UTL.ArrowLeft, WAR.HeavySwing])]
    [CustomComboInfo("Storm's Path Combo", "Replace Storm's Path with its combo chain.", WAR.JobID)]
    WarriorStormsPathCombo = 2101,

    [TintableCombo]
    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsEye, UTL.ArrowLeft, WAR.Maim, UTL.ArrowLeft, WAR.HeavySwing])]
    [CustomComboInfo("Storm's Eye Combo", "Replace Storms Eye with its combo chain.", WAR.JobID)]
    WarriorStormsEyeCombo = 2102,

    [SectionCombo("Area of Effect")]
    [IconsCombo([WAR.MythrilTempest, UTL.ArrowLeft, WAR.Overpower])]
    [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
    WarriorMythrilTempestCombo = 2103,

    #endregion
    // ====================================================================================
    #region WHITE MAGE

    [SectionCombo("Afflatus Misery")]
    [IconsCombo([WHM.AfflatusSolace, UTL.ArrowLeft, WHM.AfflatusMisery, UTL.Blank, UTL.Blank, UTL.Enemy])]
    [CustomComboInfo("Solace into Misery", "Replace Afflatus Solace with Afflatus Misery when ready and you have an enemy target and 3 Blood Lilies.", WHM.JobID)]
    WhiteMageSolaceMiseryFeature = 2401,

    [SectionCombo("Afflatus Misery")]
    [IconsCombo([WHM.AfflatusRapture, UTL.ArrowLeft, WHM.AfflatusMisery, UTL.Blank, UTL.Blank, UTL.Enemy])]
    [CustomComboInfo("Rapture into Misery", "Replace Afflatus Rapture with Afflatus Misery when ready and you have an enemy target and 3 Blood Lilies.", WHM.JobID)]
    WhiteMageRaptureMiseryFeature = 2402,

    #endregion
    // ====================================================================================
    #region BEASTMASTER

    [SectionCombo("Single Target")]
    [IconsCombo([BST.Shieldsplitter, UTL.ArrowLeft, BST.AxebladeBite, UTL.ArrowLeft, BST.SmashAxe])]
    [CustomComboInfo("Shieldsplitter Combo", "Replace Shieldsplitter with its combo chain.", BST.JobID)]
    BeastmasterShieldsplitterCombo = 4301,

    #endregion
    // ====================================================================================
    #region DOH

    // [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
    // DohPlaceholder = 50001,

    #endregion
    // ====================================================================================
    #region DOL

    #endregion
    // ====================================================================================
}
