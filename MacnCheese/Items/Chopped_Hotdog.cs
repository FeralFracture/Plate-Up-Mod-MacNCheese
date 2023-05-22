using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using KitchenLib.References;

namespace KitchenMacAndCheese
{
    public class Chopped_Hotdog : CustomItem
    {
        public override string UniqueNameID => "Hotdog slices";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("hotdog_slices");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.002", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.003", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.004", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.005", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotdogSlice.006", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
        }
    }
}
