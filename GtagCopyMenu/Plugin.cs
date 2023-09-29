using System;
using Colossal.Menu;
using MelonLoader;
using Photon.Pun;
using UnityEngine;

namespace Colossal
{
	// Token: 0x02000004 RID: 4
	public class Plugin : MelonMod
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002D7C File Offset: 0x00000F7C
		public override void OnUpdate()
		{
			bool flag = !this.doonce;
			if (flag)
			{
				Menu.LoadOnce();
				this.doonce = true;
			}
			Menu.Load();
			new mods().mod();
			bool flag2 = !PhotonNetwork.IsConnected;
			if (flag2)
			{
				PhotonNetwork.ConnectUsingSettings();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002DCC File Offset: 0x00000FCC
		private Color HexToColor(string hex)
		{
			Color white = Color.white;
			ColorUtility.TryParseHtmlString(hex, ref white);
			return white;
		}

		// Token: 0x04000007 RID: 7
		private bool doonce;

		// Token: 0x04000008 RID: 8
		public static bool excelfly;

		// Token: 0x04000009 RID: 9
		public static bool lagall;

		// Token: 0x0400000A RID: 10
		public static bool TagGun;

		// Token: 0x0400000B RID: 11
		public static bool vibrateCon;

		// Token: 0x0400000C RID: 12
		public static bool TagAll;

		// Token: 0x0400000D RID: 13
		public static bool soundSpam;

		// Token: 0x0400000E RID: 14
		public static bool teleportGun;

		// Token: 0x0400000F RID: 15
		public static bool longArms;

		// Token: 0x04000010 RID: 16
		public static bool platforms;

		// Token: 0x04000011 RID: 17
		public static bool esp;

		// Token: 0x04000012 RID: 18
		public static bool lowQualty;

		// Token: 0x04000013 RID: 19
		public static bool slowAll;

		// Token: 0x04000014 RID: 20
		public static bool tagself;

		// Token: 0x04000015 RID: 21
		public static bool fly;

		// Token: 0x04000016 RID: 22
		public static bool invisGun;

		// Token: 0x04000017 RID: 23
		public static bool noclip;

		// Token: 0x04000018 RID: 24
		public static bool rainBow;

		// Token: 0x04000019 RID: 25
		public static bool matall;

		// Token: 0x0400001A RID: 26
		public static bool speedBoost;

		// Token: 0x0400001B RID: 27
		public static bool noSpeedCap;

		// Token: 0x0400001C RID: 28
		public static bool slowFly;

		// Token: 0x0400001D RID: 29
		public static bool noclipFly;
	}
}
