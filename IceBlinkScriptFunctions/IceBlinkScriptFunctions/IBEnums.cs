using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IceBlink
{
    public enum AiBasicTactic
    {
        BasicAttacker = 0,
        Healer = 1,
        BattleHealer = 2,
        DamageCaster = 3,
        BattleDamageCaster = 4,
        DebuffCaster = 5,
        BattleDebuffCaster = 6,
        GeneralCaster = 7,
        BattleGeneralCaster = 8
    }
    public enum TargetType //SD_20131110
    {
        Self = 0,
        Enemy = 1,
        Friend = 2,
        PointLocation = 3
    }
    public enum ChosenAction
    {
        MeleeRangedAttack = 0,
        CastSpell = 1,
        UseTrait = 2,
        UseSkill = 3,
        DoNothing = 4
    }
    public enum UsableInSituation
    {
        InCombat = 0,
        OutOfCombat = 1,
        Always = 2,
        Passive = 3
    }
    public enum DamageType
    {
        Bludgeoning = 0,
        Piercing = 1,
        Slashing = 2,
        Acid = 3,
        Cold = 4,
        Electricity = 5,
        Fire = 6,
        Light = 7,
        Sonic = 8,
        Magic = 9,
        Poison = 10
    }
}
