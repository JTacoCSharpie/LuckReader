﻿using System;
using Terraria.Localization;

namespace LuckReader
{
    public class Localization
    {
        /// <summary> Shorthand for Language.GetTextValue("Mods.LuckReader."+partialPath)
        /// <para> Includes overloads for adding up to 3 additional System.Object arguments </para> </summary>
        public static string GetTrans(string partialPath)
        {
            return Language.GetTextValue("Mods.LuckReader." + partialPath);
        }
        public static string GetTrans(string partialPath, object args1)
        {
            return Language.GetTextValue("Mods.LuckReader." + partialPath, args1);
        }
        public static string GetTrans(string partialPath, object args1, object args2)
        {
            return Language.GetTextValue("Mods.LuckReader." + partialPath, args1, args2);
        }
        public static string GetTrans(string partialPath, object args1, object args2, object args3)
        {
            return Language.GetTextValue("Mods.LuckReader." + partialPath, args1, args2, args3);
        }

        // ModCalls load before translations do so an if-else block manually translates the string
        public static string GetModCallTranslation(string modName, string cultureID)
        {
            string output = "";
            if (modName == "Census")
            {
                if (cultureID == "en-US")
                {
                    output = "";
                }
                else
                {
                    output = "";
                }
            }
            return output;
        }

        /// <summary> Trims decimal places to the 2nd digit like String.Format can, without appending extra zeros </summary>
        public static string TrimTrailingDigits(float num)
        {
            // Round suitably low floats to 0 to prevent rounding error shenanigans
            if (num < 0.01 && num > -0.01)
            {
                num = 0;
            }

            if (num % 1 == 0)
            {
                return num.ToString();
            }
            else // If the decimals are non-zero
            {
                // Remove minus sign as a factor
                float trim = MathF.Abs(num);
                // Get the numbers before the decimal place
                int height = (int)MathF.Log10(trim) + 1;
                // Get the string size we want, minus the decimal seperator & the integer numbers
                int size = Math.Clamp(num.ToString().Length - (height + 1), 0, 2);
                return string.Format("{0:F" + size + "}", num);
            }
        }

    }
}