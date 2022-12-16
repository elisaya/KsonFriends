using KsonFriends.Items;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace KsonFriends.NPCs
{
	[AutoloadHead]
	public class Kson : ModNPC
	{
		public override string Texture {
			get {return "KsonFriends/NPCs/Kson/Kson"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Kson Souchou");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Steampunker];
			
        }

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add("Good Morning Mother Fuckers~ Kon-mura~");
			chat.Add("It's morning somewhere in the world!");
			chat.Add("WHAT! WHAT THE FUCK DID YOU JUST SAY!");
			chat.Add("Shut up you pervert");
			chat.Add("eMoTiOnAl DaMaGe~!");
			chat.Add("Hey Giri do you know how to say corn in Cantonese?");
			chat.Add("Who said I sound like a drunk Mickey Mouse?!");
			chat.Add("Uzaken jyanai yo BOKE");
			//chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			//chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string.
		}

		public override void SetDefaults()
        {
			NPC.friendly = true;
			NPC.townNPC = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 27;
			NPC.defense = 33;
			NPC.lifeMax = 200;
			NPC.HitSound = SoundID.NPCHit1;
			//NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 2f;
			AIType = NPCID.Steampunker;
			AnimationType = NPCID.Steampunker;
			NPC.homeless = false;
		}


         public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }

/*         public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
			bool DMJ_Exist = ( NPC.FindFirstNPC( ModContent.NPCType<DMJ>() ) != -1 );
			if( DMJ_Exist)
            {
				return false;
            }

			for (int i= 0; i < 255; i++)
            {
                   Player player = Main.player[i];
                   if (!player.active)
                   { continue; }

				   if( player.inventory.Any(item => !item.IsAir && item.type == ModContent.ItemType<Replica_Kson_sword>() ) )
					{
					return true;
					}

            }
			return false;
         }

*/         

    }
}