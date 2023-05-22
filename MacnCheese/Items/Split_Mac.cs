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
    public class Split_Mac : CustomItem
    {
        public override string UniqueNameID => "Mac Cup";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("split_mac");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "MC";
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Cup", new Material[] {
                 MaterialUtils.GetExistingMaterial("Metal"),
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Cheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
             });
        }
    }
}
