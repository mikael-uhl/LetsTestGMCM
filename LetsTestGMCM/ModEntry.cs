using StardewModdingAPI;
using LetsTestGmcm.Framework;
using LetsTestGmcm.Framework.GenericModConfigMenu;

namespace LetsTestGMCM
{
    public class ModEntry : Mod
    {
        private ModConfig _config;
        public override void Entry(IModHelper helper)
        {
            this._config = helper.ReadConfig<ModConfig>();
            var configMenu = new ModConfigMenu(helper, this._config, this.ModManifest);
            var letsTestGmcm = new Test(helper);
        }
    }
}