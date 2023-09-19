using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace LuckReader
{
	public class LuckPlayer : ModPlayer
	{
        private int timer;
        public float ladyLuck;
        public float torchLuck;
        public float potLuck;
        public float lanternLuck;
        public float gnomeLuck;

        public float coinLuck;
        public float galaxyPearl;
        public float equipLuck;

        public float totalLuck;
        public float missingLuck;

        public override void PreUpdate()
        {
            if (ModContent.GetInstance<Client>().doPlayerBuff && !Player.HasBuff<LuckReaderBuff>())
            {
                Player.AddBuff(ModContent.BuffType<LuckReaderBuff>(), 6000);
            }
        }
        public override void PostUpdate()
        {
            timer++;
            if (timer >= ModContent.GetInstance<Client>().checkInterval*2)
            {
                timer = 0;
                ladyLuck = ReaderMethods.GetLadyBugLuck(Player) * 0.2f;
                torchLuck = Player.torchLuck * 0.2f;
                potLuck = Player.luckPotion * 0.1f;
                if (LanternNight.LanternsUp)
                {
                    lanternLuck = 0.3f;
                }
                else
                {
                    lanternLuck = 0f;
                }
                if (Player.HasGardenGnomeNearby)
                {
                    gnomeLuck = 0.2f;
                }
                else
                {
                    gnomeLuck = 0f;
                }
                //equipLuck = Player.equipLuck // Doesn't exist yet
                //coinLuck = ReaderMethods.CalculateCoinLuck(Player);
                totalLuck = ladyLuck + torchLuck + potLuck + lanternLuck + gnomeLuck + coinLuck + galaxyPearl + equipLuck;
                missingLuck = Player.luck - totalLuck;
            }
        }
    }
}