using Terraria;
using Terraria.ModLoader;
using static LuckReader.Localization;


namespace LuckReader
{
    public class LuckReaderBuff : ModBuff
    {

        private int timer = 0;
        public float[] LuckCategories = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            timer++;
            if (timer >= ModContent.GetInstance<Client>().checkInterval * 2)
            {
                timer = 0;
                LuckCategories = ReaderMethods.GetLucks(Main.LocalPlayer);
            }

            for (int i = 0; i < LuckCategories.Length; i++)
            {
                tip += GetTrans("Stats.Stat" + i, TrimTrailingDigits(LuckCategories[i])) + "\n";
            }

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