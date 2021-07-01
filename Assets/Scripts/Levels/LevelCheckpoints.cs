using System;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Misc;

    [Serializable]
    public struct LevelCheckpoints
    {
        public Transform start;
        public EndLevelTrigger end;
    }
}