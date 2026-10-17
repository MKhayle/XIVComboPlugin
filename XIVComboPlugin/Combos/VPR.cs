using System.Collections;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class VPR
{
    public const byte JobID = 41;

    public const uint
        SteelFangs = 34606,
        ReavingFangs = 34607,
        HuntersSting = 34608,
        SwiftskinsSting = 34609,
        FlankstingStrike = 34610,
        FlanksbaneFang = 34611,
        HindstingStrike = 34612,
        HindsbaneFang = 34613,

        SteelMaw = 34614,
        ReavingMaw = 34615,
        HuntersBite = 34616,
        SwiftskinsBite = 34617,
        JaggedMaw = 34618,
        BloodiedMaw = 34619,

        Vicewinder = 34620,
        HuntersCoil = 34621,
        SwiftskinsCoil = 34622,
        VicePit = 34623,
        HuntersDen = 34624,
        SwiftskinsDen = 34625,

        SerpentsTail = 35920,
        DeathRattle = 34634,
        LastLash = 34635,
        Twinfang = 35921,
        Twinblood = 35922,
        TwinfangBite = 34636,
        TwinfangThresh = 34638,
        TwinbloodBite = 34637,
        TwinbloodThresh = 34639,

        UncoiledFury = 34633,
        UncoiledTwinfang = 34644,
        UncoiledTwinblood = 34645,

        SerpentsIre = 34647,
        Reawaken = 34626,
        FirstGeneration = 34627,
        SecondGeneration = 34628,
        ThirdGeneration = 34629,
        FourthGeneration = 34630,
        Ouroboros = 34631,
        FirstLegacy = 34640,
        SecondLegacy = 34641,
        ThirdLegacy = 34642,
        FourthLegacy = 34643,

        WrithingSnap = 34632,
        Slither = 34646;

    public static class Buffs
    {
        public const ushort
            FlankstungVenom = 3645,
            FlanksbaneVenom = 3646,
            HindstungVenom = 3647,
            HindsbaneVenom = 3648,
            GrimhuntersVenom = 3649,
            GrimskinsVenom = 3650,
            HuntersVenom = 3657,
            SwiftskinsVenom = 3658,
            FellhuntersVenom = 3659,
            FellskinsVenom = 3660,
            PoisedForTwinfang = 3665,
            PoisedForTwinblood = 3666,
            HuntersInstinct = 3668, // Double check, might also be 4120
            Swiftscaled = 3669,     // Might also be 4121
            Reawakened = 3670,
            ReadyToReawaken = 3671,
            HonedSteel = 3672,
            HonedReavers = 3772;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SteelFangs = 1,
            HuntersSting = 5,
            ReavingFangs = 10,
            WrithingSnap = 15,
            SwiftskinsSting = 20,
            SteelMaw = 25,
            Single3rdCombo = 30, // Includes Flanksting, Flanksbane, Hindsting, and Hindsbane
            ReavingMaw = 35,
            Slither = 40,
            HuntersBite = 40,
            SwiftskinsBite = 45,
            AoE3rdCombo = 50,    // Jagged Maw and Bloodied Maw
            DeathRattle = 55,
            LastLash = 60,
            Vicewinder = 65,     // Also includes Hunter's Coil and Swiftskin's Coil
            VicePit = 70,        // Also includes Hunter's Den and Swiftskin's Den
            TwinsSingle = 75,    // Twinfang Bite and Twinblood Bite
            TwinsAoE = 80,       // Twinfang Thresh and Twinblood Thresh
            UncoiledFury = 82,
            SerpentsIre = 86,
            EnhancedRattle = 88, // Third stack of Rattling Coil can be accumulated
            Reawaken = 90,       // Also includes First Generation through Fourth Generation
            UncoiledTwins = 92,  // Uncoiled Twinfang and Uncoiled Twinblood
            Ouroboros = 96,      // Also includes a 5th Anguine Tribute stack from Reawaken
            Legacies = 100;      // First through Fourth Legacy
    }
}

internal class ViperFangs : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VprAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == VPR.SteelFangs || actionID == VPR.ReavingFangs)
        {
            var gauge = GetJobGauge<VPRGauge>();
            var maxtribute = level >= VPR.Levels.Ouroboros ? 5 : 4;

            if (IsEnabled(CustomComboPreset.ViperSteelTailFeature) &&
                OriginalHook(VPR.SerpentsTail) == VPR.DeathRattle && CanUseAction(VPR.DeathRattle))
                return VPR.DeathRattle;

            if (IsEnabled(CustomComboPreset.ViperGenerationLegaciesFeature))
            {
                if (actionID == VPR.SteelFangs && OriginalHook(VPR.SerpentsTail) == VPR.FirstLegacy)
                    return VPR.FirstLegacy;

                if (actionID == VPR.ReavingFangs && OriginalHook(VPR.SerpentsTail) == VPR.SecondLegacy)
                    return VPR.SecondLegacy;
            }
        }
        return actionID;
    }
}

internal class ViperMaws : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VprAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == VPR.SteelMaw || actionID == VPR.ReavingMaw)
        {
            var gauge = GetJobGauge<VPRGauge>();
            var maxtribute = level >= VPR.Levels.Ouroboros ? 5 : 4;

            if (IsEnabled(CustomComboPreset.ViperSteelTailFeature) &&
                OriginalHook(VPR.SerpentsTail) == VPR.LastLash && CanUseAction(VPR.LastLash))
                return VPR.LastLash;

            if (IsEnabled(CustomComboPreset.ViperGenerationLegaciesFeature))
            {
                if (actionID == VPR.SteelMaw && OriginalHook(VPR.SerpentsTail) == VPR.FirstLegacy)
                    return VPR.FirstLegacy;

                if (actionID == VPR.ReavingMaw && OriginalHook(VPR.SerpentsTail) == VPR.SecondLegacy)
                    return VPR.SecondLegacy;
            }
        }

        return actionID;
    }
}

internal class ViperCoils : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VprAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == VPR.HuntersCoil || actionID == VPR.SwiftskinsCoil)
        {
            if (IsEnabled(CustomComboPreset.ViperGenerationLegaciesFeature))
            {
                if (actionID == VPR.HuntersCoil && OriginalHook(VPR.SerpentsTail) == VPR.ThirdLegacy)
                    return VPR.ThirdLegacy;

                if (actionID == VPR.SwiftskinsCoil && OriginalHook(VPR.SerpentsTail) == VPR.FourthLegacy)
                    return VPR.FourthLegacy;
            }

            if (IsEnabled(CustomComboPreset.ViperCoilTwinsFeature) && level >= VPR.Levels.TwinsSingle)
            {
                // The coil turns both twins into their empowered versions, two uses in total.
                // The venom administered by the coil (and then by each twin) tells which one comes next.
                var fangReady = OriginalHook(VPR.Twinfang) == VPR.TwinfangBite;
                var bloodReady = OriginalHook(VPR.Twinblood) == VPR.TwinbloodBite;

                if (fangReady && bloodReady)
                    return HasEffect(VPR.Buffs.SwiftskinsVenom) ? VPR.TwinbloodBite : VPR.TwinfangBite;

                if (fangReady)
                    return VPR.TwinfangBite;

                if (bloodReady)
                    return VPR.TwinbloodBite;
            }
        }

        return actionID;
    }
}

internal class ViperDens : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VprAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == VPR.HuntersDen || actionID == VPR.SwiftskinsDen)
        {
            if (IsEnabled(CustomComboPreset.ViperGenerationLegaciesFeature))
            {
                if (actionID == VPR.HuntersDen && OriginalHook(VPR.SerpentsTail) == VPR.ThirdLegacy)
                    return VPR.ThirdLegacy;

                if (actionID == VPR.SwiftskinsDen && OriginalHook(VPR.SerpentsTail) == VPR.FourthLegacy)
                    return VPR.FourthLegacy;
            }

            if (IsEnabled(CustomComboPreset.ViperDenTwinsFeature) && level >= VPR.Levels.TwinsAoE)
            {
                // Same two-use rule as the coils, with the AoE venom picking which twin comes first.
                var fangReady = OriginalHook(VPR.Twinfang) == VPR.TwinfangThresh;
                var bloodReady = OriginalHook(VPR.Twinblood) == VPR.TwinbloodThresh;

                if (fangReady && bloodReady)
                    return HasEffect(VPR.Buffs.FellskinsVenom) ? VPR.TwinbloodThresh : VPR.TwinfangThresh;

                if (fangReady)
                    return VPR.TwinfangThresh;

                if (bloodReady)
                    return VPR.TwinbloodThresh;
            }
        }

        return actionID;
    }
}

internal class ViperUncoiledFury : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VprAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID != VPR.UncoiledFury)
            return actionID;

        if (!IsEnabled(CustomComboPreset.ViperUncoiledTwinsFeature) || level < VPR.Levels.UncoiledTwins)
            return actionID;

        // Uncoiled Fury always unlocks Twinfang first; Twinfang then unlocks Twinblood.
        var fangReady = OriginalHook(VPR.Twinfang) == VPR.UncoiledTwinfang;
        var bloodReady = OriginalHook(VPR.Twinblood) == VPR.UncoiledTwinblood;

        if (fangReady && bloodReady)
            return HasEffect(VPR.Buffs.PoisedForTwinblood) ? VPR.UncoiledTwinblood : VPR.UncoiledTwinfang;

        if (fangReady)
            return VPR.UncoiledTwinfang;

        if (bloodReady)
            return VPR.UncoiledTwinblood;

        return actionID;
    }
}