using System;
using System.Linq;
using easyInputs;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Menu
{
	// Token: 0x02000005 RID: 5
	public class Menu
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public static void LoadOnce()
		{
			Menu.MainCamera = GameObject.Find("Main Camera");
			Menu.HUDObj = new GameObject();
			Menu.HUDObj2 = new GameObject();
			Menu.HUDObj2.name = "CLIENT_HUB";
			Menu.HUDObj.name = "CLIENT_HUB";
			Menu.HUDObj.AddComponent<Canvas>();
			Menu.HUDObj.AddComponent<CanvasScaler>();
			Menu.HUDObj.AddComponent<GraphicRaycaster>();
			Menu.HUDObj.GetComponent<Canvas>().enabled = true;
			Menu.HUDObj.GetComponent<Canvas>().renderMode = 2;
			Menu.HUDObj.GetComponent<Canvas>().worldCamera = Menu.MainCamera.GetComponent<Camera>();
			Menu.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
			Menu.HUDObj.GetComponent<RectTransform>().position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
			Menu.HUDObj2.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z - 4.6f);
			Menu.HUDObj.transform.parent = Menu.HUDObj2.transform;
			Menu.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
			Vector3 eulerAngles = Menu.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
			eulerAngles.y = -270f;
			Menu.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
			Menu.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
			Menu.Testtext = new GameObject
			{
				transform = 
				{
					parent = Menu.HUDObj.transform
				}
			}.AddComponent<Text>();
			Menu.Testtext.text = "";
			Menu.Testtext.fontSize = 10;
			Menu.Testtext.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			Menu.Testtext.rectTransform.sizeDelta = new Vector2(260f, 160f);
			Menu.Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
			Menu.Testtext.rectTransform.localPosition = new Vector3(-1.5f, 1f, 2f);
			Menu.Testtext.material = Menu.AlertText;
			Menu.NotifiText = Menu.Testtext;
			Menu.Testtext.alignment = 0;
			Menu.HUDObj2.transform.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
			Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;
			Menu.MainMenu = new MenuOption[5];
			Menu.MainMenu[0] = new MenuOption
			{
				DisplayName = "Player Mods",
				_type = "submenu",
				AssociatedString = "Movement"
			};
			Menu.MainMenu[1] = new MenuOption
			{
				DisplayName = "Main Mods",
				_type = "submenu",
				AssociatedString = "MainStuff"
			};
			Menu.MainMenu[2] = new MenuOption
			{
				DisplayName = "Visuals",
				_type = "submenu",
				AssociatedString = "Visual"
			};
			Menu.MainMenu[4] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.Movement = new MenuOption[10];
			Menu.Movement[0] = new MenuOption
			{
				DisplayName = "Excel Fly",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[1] = new MenuOption
			{
				DisplayName = "Long Arms",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[2] = new MenuOption
			{
				DisplayName = "Fly",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[3] = new MenuOption
			{
				DisplayName = "Noclip",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[4] = new MenuOption
			{
				DisplayName = "No Speed Cap",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[5] = new MenuOption
			{
				DisplayName = "Speed Boost",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[6] = new MenuOption
			{
				DisplayName = "Slow Fly",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[7] = new MenuOption
			{
				DisplayName = "Noclip Fly",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[8] = new MenuOption
			{
				DisplayName = "Teleport Gun",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[9] = new MenuOption
			{
				DisplayName = "Back",
				_type = "submenu",
				AssociatedString = "Back"
			};
			Menu.MainStuff = new MenuOption[11];
			Menu.MainStuff[0] = new MenuOption
			{
				DisplayName = "Destroy All",
				_type = "button",
				AssociatedString = "Destroy All"
			};
			Menu.MainStuff[1] = new MenuOption
			{
				DisplayName = "Lag All",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[2] = new MenuOption
			{
				DisplayName = "Vibrate All",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[3] = new MenuOption
			{
				DisplayName = "Slow All",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[4] = new MenuOption
			{
				DisplayName = "Tag Self",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[5] = new MenuOption
			{
				DisplayName = "Tag All",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[6] = new MenuOption
			{
				DisplayName = "Material Spam",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[7] = new MenuOption
			{
				DisplayName = "Tag Gun",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[8] = new MenuOption
			{
				DisplayName = "Destroy Gun",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.MainStuff[9] = new MenuOption
			{
				DisplayName = "Report All",
				_type = "button",
				AssociatedString = "break"
			};
			Menu.MainStuff[10] = new MenuOption
			{
				DisplayName = "Back",
				_type = "submenu",
				AssociatedString = "Back"
			};
			Menu.Visual = new MenuOption[3];
			Menu.Visual[0] = new MenuOption
			{
				DisplayName = "Esp",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Visual[1] = new MenuOption
			{
				DisplayName = "Low Qualty",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Visual[2] = new MenuOption
			{
				DisplayName = "Back",
				_type = "submenu",
				AssociatedString = "Back"
			};
			Menu.info = new MenuOption[8];
			Menu.info[0] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[1] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[2] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[3] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[4] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[5] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[6] = new MenuOption
			{
				DisplayName = " ",
				_type = "button",
				AssociatedString = ""
			};
			Menu.info[7] = new MenuOption
			{
				DisplayName = "Back",
				_type = "submenu",
				AssociatedString = "Back"
			};
			Menu.MenuState = "Main";
			Menu.CurrentViewingMenu = Menu.MainMenu;
			Menu.UpdateMenuState(new MenuOption(), null, null);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000037EC File Offset: 0x000019EC
		public static void Load()
		{
			bool flag = EasyInputs.GetThumbStickButtonDown(0) && EasyInputs.GetThumbStickButtonDown(1) && !Menu.menutogglecooldown;
			if (flag)
			{
				Menu.menutogglecooldown = true;
				Menu.HUDObj2.SetActive(!Menu.HUDObj2.activeSelf);
				Menu.GUIToggled = !Menu.GUIToggled;
			}
			bool flag2 = !EasyInputs.GetThumbStickButtonDown(0) && !EasyInputs.GetThumbStickButtonDown(1) && Menu.menutogglecooldown;
			if (flag2)
			{
				Menu.menutogglecooldown = false;
			}
			bool guitoggled = Menu.GUIToggled;
			if (guitoggled)
			{
				Menu.HUDObj2.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
				Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;
				bool thumbStickButtonDown = EasyInputs.GetThumbStickButtonDown(0);
				if (thumbStickButtonDown)
				{
					bool flag3 = EasyInputs.GetTriggerButtonDown(1) && !Menu.inputcooldown;
					if (flag3)
					{
						Menu.inputcooldown = true;
						bool flag4 = Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count<MenuOption>();
						if (flag4)
						{
							Menu.SelectedOptionIndex = 0;
						}
						else
						{
							Menu.SelectedOptionIndex++;
						}
						Menu.UpdateMenuState(new MenuOption(), null, null);
					}
					bool flag5 = EasyInputs.GetGripButtonDown(1) && !Menu.inputcooldown;
					if (flag5)
					{
						Menu.inputcooldown = true;
						Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
					}
					bool flag6 = !EasyInputs.GetTriggerButtonDown(1) && !EasyInputs.GetGripButtonDown(1) && Menu.inputcooldown;
					if (flag6)
					{
						Menu.inputcooldown = false;
					}
				}
			}
			Plugin.lagall = Menu.MainStuff[1].AssociatedBool;
			Plugin.vibrateCon = Menu.MainStuff[2].AssociatedBool;
			Plugin.slowAll = Menu.MainStuff[3].AssociatedBool;
			Plugin.longArms = Menu.Movement[1].AssociatedBool;
			Plugin.fly = Menu.Movement[2].AssociatedBool;
			Plugin.slowFly = Menu.Movement[6].AssociatedBool;
			Plugin.noclip = Menu.Movement[3].AssociatedBool;
			Plugin.excelfly = Menu.Movement[0].AssociatedBool;
			Plugin.TagAll = Menu.MainStuff[5].AssociatedBool;
			Plugin.noSpeedCap = Menu.Movement[4].AssociatedBool;
			Plugin.tagself = Menu.MainStuff[4].AssociatedBool;
			Plugin.noclipFly = Menu.Movement[7].AssociatedBool;
			Plugin.matall = Menu.MainStuff[6].AssociatedBool;
			Plugin.speedBoost = Menu.Movement[5].AssociatedBool;
			Plugin.invisGun = Menu.MainStuff[8].AssociatedBool;
			Plugin.teleportGun = Menu.Movement[8].AssociatedBool;
			Plugin.TagGun = Menu.MainStuff[7].AssociatedBool;
			string text = string.Concat(new string[]
			{
				"<color=",
				Menu.MenuColour,
				">Universal Client: ",
				Menu.MenuState,
				"</color>\n"
			});
			int num = 0;
			bool flag7 = Menu.CurrentViewingMenu != null;
			if (flag7)
			{
				foreach (MenuOption menuOption in Menu.CurrentViewingMenu)
				{
					bool flag8 = Menu.SelectedOptionIndex == num;
					if (flag8)
					{
						text += ">";
					}
					text += menuOption.DisplayName;
					bool flag9 = menuOption._type == "toggle";
					if (flag9)
					{
						bool associatedBool = menuOption.AssociatedBool;
						if (associatedBool)
						{
							text = text + " <color=" + Menu.MenuColour + ">[ON]</color>";
						}
						else
						{
							text += " <color=blue>[OFF]</color>";
						}
					}
					text += "\n";
					num++;
				}
				Menu.Testtext.text = text;
			}
			else
			{
				Debug.Log("Null for some reason");
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003BF4 File Offset: 0x00001DF4
		private static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType)
		{
			try
			{
				bool flag = OperationType == "optionhit";
				if (flag)
				{
					bool flag2 = option._type == "submenu";
					if (flag2)
					{
						bool flag3 = option.AssociatedString == "Movement";
						if (flag3)
						{
							Menu.CurrentViewingMenu = Menu.Movement;
						}
						bool flag4 = option.AssociatedString == "Visual";
						if (flag4)
						{
							Menu.CurrentViewingMenu = Menu.Visual;
						}
						bool flag5 = option.AssociatedString == "MainStuff";
						if (flag5)
						{
							Menu.CurrentViewingMenu = Menu.MainStuff;
						}
						bool flag6 = option.AssociatedString == "basicColors";
						if (flag6)
						{
							Menu.CurrentViewingMenu = Menu.BasicColors;
						}
						bool flag7 = option.AssociatedString == "info";
						if (flag7)
						{
							Menu.CurrentViewingMenu = Menu.info;
						}
						bool flag8 = option.AssociatedString == "Back";
						if (flag8)
						{
							Menu.CurrentViewingMenu = Menu.MainMenu;
						}
						Menu.MenuState = option.AssociatedString;
						Menu.SelectedOptionIndex = 0;
					}
					bool flag9 = option._type == "toggle";
					if (flag9)
					{
						bool flag10 = !option.AssociatedBool;
						if (flag10)
						{
							option.AssociatedBool = true;
							Debug.Log(string.Format("<color=black>Toggled {0} : {1}</color>", option.DisplayName, option.AssociatedBool));
						}
						else
						{
							option.AssociatedBool = false;
						}
					}
					bool flag11 = option._type == "button";
					if (flag11)
					{
						bool flag12 = option.AssociatedString == "destroyAll";
						if (flag12)
						{
							PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
							foreach (Player player in PhotonNetwork.PlayerListOthers)
							{
								PhotonNetwork.DestroyPlayerObjects(player);
							}
						}
						bool flag13 = option.AssociatedString == "Rpcthing";
						if (flag13)
						{
							foreach (PhotonView photonView in PhotonNetwork.PhotonViews)
							{
								photonView.RPC("Fire", 0, null);
							}
						}
						bool flag14 = option.AssociatedString == "break";
						if (flag14)
						{
							PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
							foreach (Player player2 in PhotonNetwork.PlayerList)
							{
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
								GorillaNot.instance.SendReport("Cheating", player2.UserId, player2.NickName);
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400001E RID: 30
		public static bool GUIToggled = true;

		// Token: 0x0400001F RID: 31
		private static GameObject HUDObj;

		// Token: 0x04000020 RID: 32
		private static GameObject HUDObj2;

		// Token: 0x04000021 RID: 33
		private static GameObject MainCamera;

		// Token: 0x04000022 RID: 34
		private static Text Testtext;

		// Token: 0x04000023 RID: 35
		private static TextAnchor textAnchor = 2;

		// Token: 0x04000024 RID: 36
		private static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));

		// Token: 0x04000025 RID: 37
		private static Text NotifiText;

		// Token: 0x04000026 RID: 38
		public static string MenuState = "Main";

		// Token: 0x04000027 RID: 39
		public static string MenuColour = "red";

		// Token: 0x04000028 RID: 40
		public static bool MenuRGB = false;

		// Token: 0x04000029 RID: 41
		public static float menurgb = 0f;

		// Token: 0x0400002A RID: 42
		public static int SelectedOptionIndex = 0;

		// Token: 0x0400002B RID: 43
		public static MenuOption[] CurrentViewingMenu = null;

		// Token: 0x0400002C RID: 44
		public static MenuOption[] MainMenu;

		// Token: 0x0400002D RID: 45
		public static MenuOption[] Movement;

		// Token: 0x0400002E RID: 46
		public static MenuOption[] Visual;

		// Token: 0x0400002F RID: 47
		public static MenuOption[] MainStuff;

		// Token: 0x04000030 RID: 48
		public static MenuOption[] BasicColors;

		// Token: 0x04000031 RID: 49
		public static MenuOption[] info;

		// Token: 0x04000032 RID: 50
		public static bool inputcooldown = false;

		// Token: 0x04000033 RID: 51
		public static bool menutogglecooldown = false;

		// Token: 0x04000034 RID: 52
		public static bool driftmode = false;
	}
}
