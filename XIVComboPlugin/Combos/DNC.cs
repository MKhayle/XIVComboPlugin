using System;
using System.Linq;

using Dalamud.Game.ClientState.JobGauge.Types;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace XIVCombo.Combos;

internal static class DNC
{
    public const byte JobID = 38;

    public const uint
        // Single Target
        Cascade = 15989,
        Fountain = 15990,
        ReverseCascade = 15991,
        Fountainfall = 15992,
        // AoE
        Windmill = 15993,
        Bladeshower = 15994,
        RisingWindmill = 15995,
        Bloodshower = 15996,
        // Dancing
        StandardStep = 15997,
        StandardFinish = 16003,
        TechnicalStep = 15998,
        TechnicalFinish = 16004,
        Tillana = 25790,
        LastDance = 36983,
        FinishingMove = 36984,
        // Fans
        FanDance1 = 16007,
        FanDance2 = 16008,
        FanDance3 = 16009,
        FanDance4 = 25791,
        // Steps
        Emboite = 15999,
        Entrechat = 16000,
        Jete = 16001,
        Pirouette = 16002,

        // Other
        SaberDance = 16005,
        ClosedPosition = 16006,
        EnAvant = 16010,
        Devilment = 16011,
        Flourish = 16013,
        Improvisation = 16014,
        StarfallDance = 25792,
        DanceOfTheDawn = 36985;

    public static class Buffs
    {
        public const ushort
            ClosedPosition = 1823,
            FlourishingSymmetry = 3017,
            FlourishingFlow = 3018,
            FlourishingFinish = 2698,
            FlourishingStarfall = 2700,
            SilkenSymmetry = 2693,
            SilkenFlow = 2694,
            StandardStep = 1818,
            StandardFinish = 1821,
            TechnicalStep = 1819,
            TechnicalFinish = 1822,
            ThreefoldFanDance = 1820,
            FourfoldFanDance = 2699,
            LastDanceReady = 3867,
            FinishingMoveReady = 3868,
            DanceOfTheDawnReady = 3869;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Cascade = 1,
            Fountain = 2,
            Windmill = 15,
            StandardStep = 15,
            ReverseCascade = 20,
            Bladeshower = 25,
            RisingWindmill = 35,
            Fountainfall = 40,
            Bloodshower = 45,
            ClosedPosition = 60,
            FanDance3 = 66,
            TechnicalStep = 70,
            Flourish = 72,
            SaberDance = 76,
            Tillana = 82,
            FanDance4 = 86,
            StarfallDance = 90,
            LastDance = 92,
            FinishingMove = 96,
            DanceOfTheDawn = 100;
    }
}


internal class DancerFanDance12 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.FanDance1 || actionID == DNC.FanDance2)
        {
            if (level < DNC.Levels.FanDance3)
                return actionID;

            if (IsEnabled(CustomComboPreset.DancerFanDance3Feature) && HasEffect(DNC.Buffs.ThreefoldFanDance))
                    return DNC.FanDance3;
        }

        return actionID;
    }
}


internal class DancerFlourish : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Flourish)
        {
            if (IsEnabled(CustomComboPreset.DancerFlourishFan4Feature))
            {
                if (level >= DNC.Levels.FanDance4 && HasEffect(DNC.Buffs.FourfoldFanDance))
                    return DNC.FanDance4;
            }
        }

        return actionID;
    }
}

internal class DancerCascadeFountain : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerSingleTargetProcs;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Cascade && level >= DNC.Levels.ReverseCascade &&
            (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
            return DNC.ReverseCascade;

        if (actionID == DNC.Fountain && level >= DNC.Levels.Fountainfall &&
            (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
            return DNC.Fountainfall;

        return actionID;
    }
}

internal class DancerWindmillBladeshower : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerAoeProcs;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Windmill || actionID == DNC.Bladeshower ||
            actionID == DNC.RisingWindmill || actionID == DNC.Bloodshower)
        {
            if (actionID == DNC.Windmill && level >= DNC.Levels.RisingWindmill &&
                (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
                return DNC.RisingWindmill;

            if (actionID == DNC.Bladeshower && level >= DNC.Levels.Bloodshower &&
                (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
                return DNC.Bloodshower;
        }

        return actionID;
    }
}

internal class DancerLastDanceFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerLastDanceFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.StandardStep)
        {
            if (level >= DNC.Levels.LastDance && HasEffect(DNC.Buffs.LastDanceReady))
            {                
                return DNC.LastDance;
            }
        }

        return actionID;
    }
}