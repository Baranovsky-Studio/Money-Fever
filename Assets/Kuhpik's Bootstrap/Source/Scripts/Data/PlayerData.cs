using System;
using System.Collections.Generic;
using Idle_Arcade_Components.Scripts.Components;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        // Example (I use public fields for data, but u free to use properties\methods etc)
        // [BoxGroup("level")] public int level;
        // [BoxGroup("currency")] public int money;
        
        public bool Sounds = true;
        public bool Vibration = true;
        
        public int[] ResourcesCounts;

        public int LevelId = 1;
        public int GameId = 1;

        public List<UnlockableItemData> UnlockableItemsData = new List<UnlockableItemData>();
        public List<UpgradableItemData> UpgradableItemsData = new List<UpgradableItemData>();
    }

    [Serializable]
    public class LevelData
    {
    }
}