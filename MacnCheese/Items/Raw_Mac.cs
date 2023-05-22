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
using  KitchenLib.References;

namespace KitchenMacAndCheese
{
    public class Raw_Mac : CustomItem
    {
        public override string UniqueNameID => "RawMac";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("raw_noodle");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Uncooked_Mac"]
            });
        }
    }
}
