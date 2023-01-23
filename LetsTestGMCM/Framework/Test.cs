using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace LetsTestGmcm.Framework
{
    public class Test
    {
        private readonly IModHelper _helper;
        private ModConfig _config;
        
        public Test(IModHelper helper)
        {
            this._helper = helper;
            this._helper.Events.Content.AssetRequested += this.ChangeAsset;
        }

        private void ChangeAsset(object sender, AssetRequestedEventArgs e)
        {
            this._config = this._helper.ReadConfig<ModConfig>();
            if (_config.ChangesToggle)
            {
                if (e.NameWithoutLocale.IsEquivalentTo("Portraits/Haley"))
                {
                    e.Edit(asset =>
                    {
                        var editor = asset.AsImage();
                        IRawTextureData prettierHaleyTexture =
                            this._helper.ModContent.Load<IRawTextureData>("assets/prettierHaley.png");
                        editor.PatchImage(prettierHaleyTexture, targetArea: new Rectangle(0, 0, 128, 384));
                    });
                }
            }
        }
    }
}