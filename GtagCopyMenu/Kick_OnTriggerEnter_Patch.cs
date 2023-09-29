using System;
using HarmonyLib;

// Token: 0x02000002 RID: 2
[HarmonyPatch(typeof(kick))]
public static class Kick_OnTriggerEnter_Patch
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002064 File Offset: 0x00000264
	private static bool Prefix()
	{
		return false;
	}
}
