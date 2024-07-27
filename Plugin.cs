using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace GeraldTheCat
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string assetBundleName = "gerald";
        public static string parentName = "GeraldTheCat";

        void Start()
		{

			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
			assetBundleParent.SetActive(true);
		}

		void OnDisable()
		{
            assetBundleParent.SetActive(false);
        }

		void OnGameInitialized(object sender, EventArgs e)
		{
			instance = this;

			
			bundle = LoadAssetBundle("GeraldTheCat.AssetBundles." + assetBundleName);
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));

            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.57f, -82.611f);
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
