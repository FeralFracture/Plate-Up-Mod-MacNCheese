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
    public class GarbageBox : CustomItem
    {
        public override string UniqueNameID => "its trash";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Box_Mac_Item");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}
