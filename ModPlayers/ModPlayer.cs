using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ModLoader.Utilities;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.ModLoader.IO;

namespace KsonFriends.ModPlayers
{
	internal class KsonFriendsMP : ModPlayer
	{
		public int Kson_sword_kill_count;
		public int Yura_sword_kill_count;
		public int Reto_scissors_kill_count;
		public int Extra_counter_1;
		public int Extra_counter_2;
		public int Extra_counter_3;
		public int Extra_counter_4;
		public int Extra_counter_5;
		public int Extra_counter_6;
		public int Extra_counter_7;

		public override void SaveData(TagCompound tag)
		{
			tag["Kson_sword_kill_count"] = Kson_sword_kill_count;
			tag["Yura_sword_kill_count"] = Yura_sword_kill_count;
			tag["Reto_scissors_kill_count"] = Reto_scissors_kill_count;
			tag["Extra_counter_1"] = Extra_counter_1;
			tag["Extra_counter_2"] = Extra_counter_2;
			tag["Extra_counter_3"] = Extra_counter_3;
			tag["Extra_counter_4"] = Extra_counter_4;
			tag["Extra_counter_5"] = Extra_counter_5;
			tag["Extra_counter_6"] = Extra_counter_6;
			tag["Extra_counter_7"] = Extra_counter_7;
		}

		public override void LoadData(TagCompound tag)
        {
            Kson_sword_kill_count = (int)tag["Kson_sword_kill_count"];
			Yura_sword_kill_count = (int)tag["Yura_sword_kill_count"];
			Reto_scissors_kill_count = (int)tag["Reto_scissors_kill_count"];
			Extra_counter_1 = (int)tag["Extra_counter_1"];
			Extra_counter_2 = (int)tag["Extra_counter_2"];
			Extra_counter_3 = (int)tag["Extra_counter_3"];
			Extra_counter_4 = (int)tag["Extra_counter_4"];
			Extra_counter_5 = (int)tag["Extra_counter_5"];
			Extra_counter_6 = (int)tag["Extra_counter_6"];
			Extra_counter_7 = (int)tag["Extra_counter_7"];
		}

    }
}