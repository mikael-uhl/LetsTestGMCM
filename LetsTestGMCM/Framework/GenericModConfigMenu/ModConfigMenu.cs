using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace LetsTestGmcm.Framework.GenericModConfigMenu
{
    public class ModConfigMenu
    {
        private readonly IModHelper _helper;
        private readonly IManifest _modManifest;
        private  ModConfig _config;

        public ModConfigMenu(IModHelper helper, ModConfig config, IManifest modManifest)
        {
            this._helper = helper;
            this._config = config;
            this._modManifest = modManifest;
            this._helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            var configMenuApi =
                this._helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenuApi is null)
            {
                return;
            }

            configMenuApi.Register(
                mod: this._modManifest,
                reset: () => this._config = new ModConfig(),
                save: () => this._helper.WriteConfig(_config),
                titleScreenOnly: false
            );
            
            configMenuApi.AddBoolOption(
                mod: this._modManifest,
                name: () => "GMCM Test",
                tooltip: () => "Replaces Haley portrait",
                getValue: () => this._config.ChangesToggle,
                setValue: value => this._config.ChangesToggle = value
            );
        }
    }
}