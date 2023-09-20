using Terraria;
using Terraria.ModLoader;

namespace LuckReader
{
	public class LuckPlayer : ModPlayer
	{
        public override void PreUpdate()
        {
            if (ModContent.GetInstance<Client>().doPlayerBuff && !Player.HasBuff<LuckReaderBuff>())
            {
                Player.AddBuff(ModContent.BuffType<LuckReaderBuff>(), 5184000); //24 hours of buff l o l.
            }
        }
    }
}