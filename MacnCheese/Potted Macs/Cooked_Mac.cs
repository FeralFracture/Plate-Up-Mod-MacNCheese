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
    public class Cooked_Mac : CustomItem
    {
        public override string UniqueNameID => "TestItem5";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("potted_mac");
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Pot);
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Noodles/uncooked noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Uncooked_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Pot/Pot", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Pot/Handles", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal Dark")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Water", new Material[] {
                MaterialUtils.GetExistingMaterial("Water")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Noodles/cooked noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cooked_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "cheesepack", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal Dark")
             });
            //egg
            MaterialUtils.ApplyMaterial(item.Prefab, "Egg/Egg.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Egg - Yolk")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Egg/Egg", new Material[] {
                MaterialUtils.GetExistingMaterial("Egg - White")
             });
            //hotdog bits
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.002", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.003", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.004", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.005", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "HotDogSlices/HotdogSlice.006", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
        }
    }
}
