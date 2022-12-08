using GameConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Data;

namespace HatLoader
{
    public class SetHatState : ICommand
    {
        public string Name => "Set Hat State";
        public string Description => "Sets the state of a custom hat.";
        public string Command => "hatstate";

        public void Execute(GameConsole.Console con, string[] args)
        {
            if (args.Length < 2)
            {
                con.PrintLine("Usage: hatstate <hatID> <active [true/false]>");
                return;
            }
            bool active = bool.Parse(args[1]);
            ULTRAKIT.Loader.HatLoader.SetAllActive(args[0], active);
        }
    }

    public class GetHatIDs : ICommand
    {
        public string Name => "Get Hats";
        public string Description => "Lists all hat IDs.";
        public string Command => "gethats";

        public void Execute(GameConsole.Console con, string[] args)
        {
            con.PrintLine("christmas");
            con.PrintLine("halloween");
            con.PrintLine("easter");

            foreach (HatRegistry hat in ULTRAKIT.Loader.HatLoader.registries)
            {
                con.PrintLine(hat.hatID);
            }
        }
    }

    public class PersistentHats : ICommand
    {
        public string Name => "Persistent Hats";
        public string Description => "Toggles hats persistent between loads.";
        public string Command => "keephats";

        public void Execute(GameConsole.Console con, string[] args)
        {
            if (args.Length < 1)
            {
                con.PrintLine("Usage: keephats <true/false>");
                return;
            }
            ULTRAKIT.Loader.HatLoader.Persistent = bool.Parse(args[0]);
        }
    }
}
