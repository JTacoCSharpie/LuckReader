using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace LuckReader
{
	public class LuckReader : Mod {}

	public static class ReaderMethods
    {

		/// <summary> Formula re-used from Terraria 1.4.4 </summary>
		public static float GetLadyBugLuck(Player player)
		{
			if (player.ladyBugLuckTimeLeft > 0)
			{
				return (float)player.ladyBugLuckTimeLeft / (float)NPC.ladyBugGoodLuckTime;
			}
			if (player.ladyBugLuckTimeLeft < 0)
			{
				return (0f - (float)player.ladyBugLuckTimeLeft) / (float)NPC.ladyBugBadLuckTime;
			}
			return 0f;
		}

		/// <summary> Formula re-used from Terraria 1.4.4 </summary>
		public static float GetCoinLuck(Player player)
		{
			double coinLuck = (double)player.coinLuck;
            return coinLuck switch
            {
                0f => 0f,
                > 249000f => 0.2f,
                > 24900f => 0.175f,
                > 2490f => 0.15f,
                > 249f => 0.125f,
                > 24.9 => 0.1f,
                > 2.49 => 0.075f,
                > 0.249 => 0.05f,
                _ => 0.025f
            };
        }

		public static float[] GetLucks(Player Player)
        {
			float [] lucks = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            lucks[0] = GetLadyBugLuck(Player) * 0.2f;
            lucks[1] = Player.torchLuck * 0.2f;
            lucks[2] = Player.luckPotion * 0.1f;
            lucks[3] = (LanternNight.LanternsUp) ? 0.3f : 0;
            lucks[4] = (Player.HasGardenGnomeNearby) ? 0.2f : 0;
            lucks[5] = GetCoinLuck(Player);
            lucks[6] = (Player.usedGalaxyPearl) ? 0.03f : 0;
            lucks[7] = Player.equipmentBasedLuckBonus;

            lucks[lucks.Length - 2] = 0;
            for (int i = 0; i < 8; i++)
            {
                lucks[lucks.Length - 2] += lucks[i];
            }
            lucks[lucks.Length - 1] = lucks[lucks.Length - 2] - Player.luck;

            return lucks;
        }

	}
}