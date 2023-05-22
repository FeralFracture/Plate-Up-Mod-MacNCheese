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
    public class Split_Egged_Mac : CustomItem
    {
        public override string UniqueNameID => "Mac Egg Cup";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("split_egged_mac");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "MCe";
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Cup", new Material[] {
                 MaterialUtils.GetExistingMaterial("Metal"),
                 MaterialUtils.GetExistingMaterial("AppleGreen")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Cheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egg_Sauce"]
             });
        }
    }
}
