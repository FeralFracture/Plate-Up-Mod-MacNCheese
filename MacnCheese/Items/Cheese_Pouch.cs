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
    public class Cheese_Pouch : CustomItem
    {
        public override string UniqueNameID => "TestItem11";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("cheese_pouch");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "cheesepack", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal Dark")
            });
        }
    }
}
