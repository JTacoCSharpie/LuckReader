using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace LuckReader
{
	public class LuckReader : Mod
	{
	}
	public static class ReaderMethods
    {
		public static string FormatDigits(float num)
		{
			if (num % 1 == 0)
			{
				return num.ToString();
			}
			else // If the decimals are non-zero
			{
				float trim = MathF.Abs(num); // Remove minus sign as a factor
				int height = (int)MathF.Log10(trim) + 1; // Get the numbers before the decimal place
				int size = Math.Clamp(num.ToString().Length - (height + 1), 0, 2); // Cap the numbers after decimal to 2, while removing the period
				return string.Format("{0:F" + size + "}", num);
			}
		}

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
		/*public static float CalculateCoinLuck(Player player)
		{
			double coinLuck = 0f;
			if (coinLuck == 0f)
			{
				return 0f;
			}
			if (coinLuck > 249000f)
			{
				return 0.2f;
			}
			if (coinLuck > 24900f)
			{
				return 0.175f;
			}
			if (coinLuck > 24900f)
			{
				return 0.175f;
			}
			if (coinLuck > 2490f)
			{
				return 0.15f;
			}
			if (coinLuck > 249f)
			{
				return 0.125f;
			}
			if ((double)coinLuck > 24.9)
			{
				return 0.1f;
			}
			if ((double)coinLuck > 2.49)
			{
				return 0.075f;
			}
			if ((double)coinLuck > 0.249)
			{
				return 0.05f;
			}
			return 0.025f;
		}*/
	}
}