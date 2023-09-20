using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.Events;


namespace LuckReader
{
    public class LuckReaderBuff : ModBuff
    {
        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            if (Main.LocalPlayer.TryGetModPlayer(out LuckPlayer lp))
            {
                tip +=  ReaderMethods.FormatDigits(lp.totalLuck) + " Total Luck";
                tip +=
                    "\n  +" + lp.torchLuck + " Torch Luck" +
                    "\n   " + ReaderMethods.FormatDigits(lp.ladyLuck) + " LadyBug Luck" +
                    "\n  +" + lp.potLuck + " Potion Luck" +
                    "\n  +" + lp.lanternLuck + " Lantern Night Luck" +
                    "\n  +" + lp.gnomeLuck + " Gnearby Gnome Luck" +
                    //"\n  +" + "0 Pearl, Equipment, & Coin Lucks" +
                    "\n    +" + lp.missingLuck + " Unaccounted for Mystery Luck";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luck Stat Breakdown:");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (!ModContent.GetInstance<Client>().doPlayerBuff && player.HasBuff(Type))
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
