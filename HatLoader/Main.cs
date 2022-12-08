using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMM;
using ULTRAKIT;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using ULTRAKIT.Extensions;

namespace HatLoader
{
    [UKPlugin("Hat Loader", "1.0.0", "Loads custom hat bundles using ULTRAKIT Reloaded", false, false)]
    public class Plugin : UKMod
    {
        public override void OnModLoaded()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            List<AssetBundle> bundles = new List<AssetBundle>();

            string dir = $@"{modFolder}\HatBundles";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            foreach(string file in Directory.EnumerateFiles(dir))
            {
                try
                {
                    bundles.Add(AssetBundle.LoadFromFile(file));
                }
                catch
                {
                    Debug.LogWarning($"Failed to load: {file}");
                }
            }

            foreach (AssetBundle bundle in bundles)
            {
                ULTRAKIT.Loader.HatLoader.LoadHats(bundle);
            }
        }

        public override void OnModUnload()
        {
            PlayerPrefs.SetInt("CurSlo", 1);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            GameConsole.Console.Instance.RegisterCommand(new SetHatState());
            GameConsole.Console.Instance.RegisterCommand(new GetHatIDs());
        }
    }
}
