# HatLoader
Loads custom hat bundles into ULTRAKILL and provides a means to activate/deactivate them.

# Installation
1. Download and install [UMM](https://github.com/Temperz87/ultra-mod-manager) using the provided instructions.
2. Download and install [ULTRAKIT Reloaded](https://github.com/PetersonE1/UltrakitReloaded) (minimum version 1.3.2) using the provided instructions.
3. Go to the releases page and download HatLoader.zip
4. Extract the contents of HatLoader.zip into [Your ULTRAKILL Directory]\BepInEx\UMM Mods\

# Use
Place any Hat bundles into HatBundles folder to load them into the game.

Currently, the only way to enable hats is using console commands. Press F8 to access the in-game console.

`gethats` displays a list of all Hat IDs currently loaded.

`hatstate <hatID> <true/false>` activates/deactivates the specified hat.

`keephats <true/false>` keeps the current hat setup between level loads/restarts.
