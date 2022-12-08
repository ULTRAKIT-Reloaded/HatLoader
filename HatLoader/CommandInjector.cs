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
                con.PrintLine("Usage: hatstate <hatID> <active>");
                return;
            }
            ULTRAKIT.Loader.HatLoader.SetAllActive(args[0], bool.Parse(args[1]));
        }
    }

    public class GetHatIDs : ICommand
    {
        public string Name => "Get Hats";
        public string Description => "Lists all hat IDs.";
        public string Command => "gethats";

        public void Execute(GameConsole.Console con, string[] args)
        {
            foreach (HatRegistry hat in ULTRAKIT.Loader.HatLoader.registries)
            {
                con.PrintLine(hat.hatID);
            }
            ULTRAKIT.Loader.HatLoader.SetAllActive(args[0], bool.Parse(args[1]));
        }
    }
}
