using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuckReader
{
	public class Client : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.LuckReader.Configs.Headers.DisableFeatures")]
        [DefaultValue(true)]
            public bool doPlayerBuff;

        [Header("$Mods.LuckReader.Configs.Headers.TuneFeatures")]
        [Range(1, 60)]
        [DefaultValue(5)]
            public int checkInterval;
    }
}