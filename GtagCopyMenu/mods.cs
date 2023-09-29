using System;
using System.Collections.Generic;
using easyInputs;
using GorillaLocomotion;
using Il2CppSystem;
using MelonLoader;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Colossal
{
	// Token: 0x02000003 RID: 3
	public class mods : MelonMod
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
		public void mod()
		{
			bool tagGun = Plugin.TagGun;
			if (tagGun)
			{
				bool flag = !EasyInputs.GetGripButtonDown(1);
				if (flag)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = true;
					Object.Destroy(mods.pointer3);
					return;
				}
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightHandTransform.position - Player.Instance.rightHandTransform.up, -Player.Instance.rightHandTransform.up, ref raycastHit) && mods.pointer3 == null;
				if (flag2)
				{
					mods.pointer3 = GameObject.CreatePrimitive(0);
					Object.Destroy(mods.pointer3.GetComponent<Rigidbody>());
					Object.Destroy(mods.pointer3.GetComponent<SphereCollider>());
					mods.pointer3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					mods.pointer3.GetComponent<Renderer>().material.color = Color.white;
				}
				mods.pointer3.transform.position = raycastHit.point;
				Player owner = raycastHit.collider.GetComponentInParent<PhotonView>().Owner;
				bool triggerButtonDown = EasyInputs.GetTriggerButtonDown(1);
				if (triggerButtonDown)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new Object[]
					{
						owner
					});
					PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
					mods.pointer3.GetComponent<Renderer>().material.color = Color.blue;
					return;
				}
			}
			bool invisGun = Plugin.invisGun;
			if (invisGun)
			{
				bool flag3 = !EasyInputs.GetGripButtonDown(1);
				if (flag3)
				{
					Object.Destroy(mods.pointer);
					return;
				}
				RaycastHit raycastHit2;
				bool flag4 = Physics.Raycast(Player.Instance.rightHandTransform.position - Player.Instance.rightHandTransform.up, -Player.Instance.rightHandTransform.up, ref raycastHit2) && mods.pointer == null;
				if (flag4)
				{
					mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(mods.pointer.GetComponent<SphereCollider>());
					mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					mods.pointer.GetComponent<Renderer>().material.color = Color.white;
				}
				mods.pointer.transform.position = raycastHit2.point;
				bool triggerButtonDown2 = EasyInputs.GetTriggerButtonDown(1);
				if (triggerButtonDown2)
				{
					PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
					mods.pointer.GetComponent<Renderer>().material.color = Color.red;
					PhotonNetwork.DestroyPlayerObjects(raycastHit2.collider.GetComponentInParent<PhotonView>().Owner);
					return;
				}
			}
			bool noclipFly = Plugin.noclipFly;
			if (noclipFly)
			{
				bool primaryButtonDown = EasyInputs.GetPrimaryButtonDown(1);
				if (primaryButtonDown)
				{
					Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
					Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 20f;
				}
				bool primaryButtonDown2 = EasyInputs.GetPrimaryButtonDown(1);
				if (primaryButtonDown2)
				{
					using (IEnumerator<MeshCollider> enumerator = Object.FindObjectsOfType<MeshCollider>().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							MeshCollider meshCollider = enumerator.Current;
							meshCollider.enabled = false;
						}
						goto IL_3E9;
					}
				}
				foreach (MeshCollider meshCollider2 in Object.FindObjectsOfType<MeshCollider>())
				{
					meshCollider2.enabled = true;
				}
			}
			IL_3E9:
			bool flag5 = Plugin.slowFly && EasyInputs.GetPrimaryButtonDown(1);
			if (flag5)
			{
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
			}
			bool flag6 = Plugin.matall && EasyInputs.GetTriggerButtonDown(1);
			if (flag6)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				GorillaTagManager[] array = Object.FindObjectsOfType<GorillaTagManager>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ClearInfectionState();
				}
				foreach (GorillaTagManager gorillaTagManager in Object.FindObjectsOfType<GorillaTagManager>())
				{
					gorillaTagManager.checkCooldown = 0f;
					gorillaTagManager.tagCoolDown = 0f;
				}
			}
			bool speedBoost = Plugin.speedBoost;
			if (speedBoost)
			{
				Player.Instance.maxJumpSpeed = 10000000f;
				Player.Instance.jumpMultiplier = 2f;
			}
			else
			{
				Player.Instance.maxJumpSpeed = 7f;
				Player.Instance.jumpMultiplier = 1.1f;
			}
			bool noSpeedCap = Plugin.noSpeedCap;
			if (noSpeedCap)
			{
				Player.Instance.maxJumpSpeed = 100000000f;
			}
			else
			{
				Player.Instance.maxJumpSpeed = 7f;
			}
			bool teleportGun = Plugin.teleportGun;
			if (teleportGun)
			{
				bool flag7 = !EasyInputs.GetGripButtonDown(1);
				if (flag7)
				{
					Object.Destroy(mods.pointer1);
					return;
				}
				RaycastHit raycastHit3;
				bool flag8 = Physics.Raycast(Player.Instance.rightHandTransform.position - Player.Instance.rightHandTransform.up, -Player.Instance.rightHandTransform.up, ref raycastHit3) && mods.pointer1 == null;
				if (flag8)
				{
					mods.pointer1 = GameObject.CreatePrimitive(0);
					Object.Destroy(mods.pointer1.GetComponent<Rigidbody>());
					Object.Destroy(mods.pointer1.GetComponent<SphereCollider>());
					mods.pointer1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					mods.pointer1.GetComponent<Renderer>().material.color = Color.white;
				}
				mods.pointer1.transform.position = raycastHit3.point;
				bool triggerButtonDown3 = EasyInputs.GetTriggerButtonDown(1);
				if (triggerButtonDown3)
				{
					PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
					Player.Instance.transform.position = mods.pointer1.transform.position;
					mods.pointer1.GetComponent<Renderer>().material.color = Color.red;
					return;
				}
			}
			bool excelfly = Plugin.excelfly;
			if (excelfly)
			{
				bool secondaryButtonDown = EasyInputs.GetSecondaryButtonDown(1);
				if (secondaryButtonDown)
				{
					Player.Instance.bodyCollider.attachedRigidbody.velocity += Player.Instance.rightHandTransform.right / 2f;
				}
				bool secondaryButtonDown2 = EasyInputs.GetSecondaryButtonDown(0);
				if (secondaryButtonDown2)
				{
					Player.Instance.bodyCollider.attachedRigidbody.velocity += -Player.Instance.leftHandTransform.right / 2f;
				}
			}
			bool noclip = Plugin.noclip;
			if (noclip)
			{
				bool triggerButtonDown4 = EasyInputs.GetTriggerButtonDown(1);
				if (triggerButtonDown4)
				{
					using (IEnumerator<MeshCollider> enumerator4 = Object.FindObjectsOfType<MeshCollider>().GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							MeshCollider meshCollider3 = enumerator4.Current;
							meshCollider3.enabled = false;
						}
						goto IL_816;
					}
				}
				foreach (MeshCollider meshCollider4 in Object.FindObjectsOfType<MeshCollider>())
				{
					meshCollider4.enabled = true;
				}
			}
			IL_816:
			bool slowAll = Plugin.slowAll;
			if (slowAll)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				foreach (Player player in PhotonNetwork.PlayerList)
				{
					PhotonView photonView = GorillaGameManager.instance.FindVRRigForPlayer(player);
					bool flag9 = photonView != null;
					if (flag9)
					{
						photonView.RPC("SetTaggedTime", 1, null);
					}
				}
			}
			bool flag10 = Plugin.fly && EasyInputs.GetPrimaryButtonDown(1);
			if (flag10)
			{
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 30f;
			}
			bool longArms = Plugin.longArms;
			if (longArms)
			{
				bool triggerButtonDown5 = EasyInputs.GetTriggerButtonDown(1);
				if (triggerButtonDown5)
				{
					Player.Instance.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
					Player.Instance.maxArmLength = 100000f;
					Player.Instance.maxJumpSpeed = 50f;
				}
				else
				{
					bool gripButtonDown = EasyInputs.GetGripButtonDown(0);
					if (gripButtonDown)
					{
						Player.Instance.rightHandOffset = new Vector3(0f, 0f, 0f);
						Player.Instance.leftHandOffset = new Vector3(0f, 0f, 0f);
						Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
						Player.Instance.maxJumpSpeed = 7.5f;
					}
				}
			}
			bool flag11 = Plugin.TagAll && EasyInputs.GetPrimaryButtonDown(1);
			if (flag11)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				foreach (Player player2 in PhotonNetwork.PlayerList)
				{
					PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new Object[]
					{
						player2
					});
				}
			}
			bool vibrateCon = Plugin.vibrateCon;
			if (vibrateCon)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				Vector3 position = Player.Instance.transform.position;
				Player[] array2 = PhotonNetwork.PlayerList;
				Player localPlayer = PhotonNetwork.LocalPlayer;
				GorillaGameManager instance = GorillaGameManager.instance;
				foreach (Player player3 in array2)
				{
					PhotonView photonView2 = instance.FindVRRigForPlayer(player3);
					bool flag12 = photonView2 != null;
					if (flag12)
					{
						photonView2.RPC("SetJoinTaggedTime", 1, null);
					}
				}
			}
			bool flag13 = Plugin.tagself && EasyInputs.GetPrimaryButtonDown(1);
			if (flag13)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				foreach (GorillaTagManager gorillaTagManager2 in Object.FindObjectsOfType<GorillaTagManager>())
				{
					gorillaTagManager2.AddInfectedPlayer(PhotonNetwork.LocalPlayer);
				}
			}
			bool esp = Plugin.esp && EasyInputs.GetTRiggerButtonDown(1);
			if (esp)
			Rigidbody rig;
            bool LeftTrigger = false;
            bool LeftGrip = false;
            InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out LeftTrigger);
            InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.gripButton, out LeftGrip);
            if (LeftTrigger)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 60;
            }

            if (LeftGrip)
            {
                rig = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
                rig.AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
            }
			bool flag14 = Plugin.lagall && EasyInputs.GetTriggerButtonDown(1);
			if (flag14)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
				bool flag15 = !mods.antiRepeat;
				if (flag15)
				{
					mods.antiRepeat = true;
					try
					{
						PhotonNetwork.Destroy(GorillaTagger.Instance.myVRRig.gameObject);
						GorillaGameManager.instance.NewVRRig(PhotonNetwork.LocalPlayer, GorillaTagger.Instance.myVRRig.photonView.ViewID, false);
						PhotonNetwork.Destroy(GorillaTagger.Instance.myVRRig.gameObject);
						return;
					}
					catch (NullReferenceException)
					{
						return;
					}
				}
				mods.antiRepeat = false;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002CFC File Offset: 0x00000EFC
		public static VRRig FindVRRigForPlayer(Player player)
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = !vrrig.isOfflineVRRig && vrrig.GetComponent<PhotonView>().Owner == player;
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					return vrrig;
				}
			}
			return null;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002D60 File Offset: 0x00000F60
		private static VRRig[] GetAllVRRigs()
		{
			return Object.FindObjectsOfType<VRRig>();
		}

		// Token: 0x04000001 RID: 1
		public static GameObject pointer;

		// Token: 0x04000002 RID: 2
		public static GameObject pointer1;

		// Token: 0x04000003 RID: 3
		public static int RockMaterial;

		// Token: 0x04000004 RID: 4
		public static GameObject pointer3;

		// Token: 0x04000005 RID: 5
		public static bool antiRepeat;

		// Token: 0x04000006 RID: 6
		public static int RedTransparent;
	}
}
