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
using ULTRAKIT.Data;

namespace HatLoader
{
    //[UKDependency("petersone1.ultrakitreloaded", "1.3.2")]
    [UKPlugin("petersone1.hatloader", "Hat Loader", "1.1.1", "Loads custom hat bundles using ULTRAKIT Reloaded", false, false)]
    public class Plugin : UKMod
    {
        public override void OnModLoaded()
        {
            GameConsole.Console.Instance.RegisterCommand(new SetHatState());
            GameConsole.Console.Instance.RegisterCommand(new GetHatIDs());
            GameConsole.Console.Instance.RegisterCommand(new PersistentHats());

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
                ULTRAKIT.Loader.Loaders.HatLoader.LoadHats(bundle);
            }
        }
    }
}
