using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace LuckReader
{
	public class Client : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Disable Features")]
        [Label("Display Luck Buff")]
        [Tooltip("Default: Enabled")]
        [DefaultValue(true)]
            public bool doPlayerBuff;

        [Header("Tune Features")]
        [Label("Interval to update Luck, in game-ticks")]
        [Tooltip("1 = every 2 ticks - Default: 5")]
        [Range(1, 60)]
        [DefaultValue(5)]
            public int checkInterval;
    }
}