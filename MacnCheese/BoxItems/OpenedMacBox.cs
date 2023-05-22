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
    public class OpenedMacBox : CustomItem
    {
        public override string UniqueNameID => "OpenedBox";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Box_Mac_Item");
        public override Item SplitSubItem => GetCastedGDO<Item, Cheese_Pouch>();
        public override int SplitCount => 1;
        public override float SplitSpeed => 2.5f;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            item.SplitDepletedItems.Add(GetCastedGDO<Item, GarbageBox>());
        }

    }
}
