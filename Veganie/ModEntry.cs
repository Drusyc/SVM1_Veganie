using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;


namespace Veganie
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod, StardewModdingAPI.IAssetEditor
    {
        /// <summary>Get whether this instance can edit the given asset.</summary>
        /// <param name="asset">Basic metadata about the asset being loaded.</param>
        public bool CanEdit<T>(IAssetInfo asset)
        {
            //this.Monitor.Log($"The is: {asset.AssetName}");
            string[] fields = asset.AssetName.Split('\\');

            if (fields[0].Equals("Data"))
            {
                return true;
            }

            return false;
        }

        /// <summary>Edit a matched asset.</summary>
        /// <param name="asset">A helper which encapsulates metadata about an asset and enables changes to it.</param>
        public void Edit<T>(IAssetData asset)
        {

            // Trying to update Cloth requirement to build
            // Using : https://stardewvalleywiki.com/Modding:Object_data
            // Fields:
            // 0: Name
            // 1: Price (if sold by player)
            // 2: Edibility (The 'Edibility' number determines how much health and energy is restored.)
            // 3: Type and Category
            // 4: display name (specific to language file)
            // 5: description

            // Cloth: "Cloth/470/-300/Basic -26/Cloth/A bolt of fine wool cloth.",
            string[] fields = asset.AssetName.Split('\\');

            if (fields[0].Equals("Data"))
            {
                this.Monitor.Log($"> {asset.AssetName}");

                //IDictionary<string, string> data = asset.AsDictionary<string, string>().Data;
                //foreach (string itemKey in data.Keys)
                //{
                //    string value = data[itemKey];
                //    this.Monitor.Log($"> Found: data[{itemKey}] = {value}");
                //}

                IDictionary<int, string> data2 = asset.AsDictionary<int, string>().Data;
                foreach (int itemKey in data2.Keys)
                {
                    string value = data2[itemKey];
                    this.Monitor.Log($"> Found: data[{itemKey}] = {value}");
                }
            }
        }

        public override void Entry(IModHelper helper)
        {
            this.Monitor.Log("Holà");
        }
    }
}