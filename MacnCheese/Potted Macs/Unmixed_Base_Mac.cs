using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using KitchenLib.References;
using KitchenData;
using static KitchenData.ItemGroup;
using Kitchen;

namespace KitchenMacAndCheese
{
    public class Unmixed_Base_Mac : CustomItemGroup
    {
        public override string UniqueNameID => "SamsThing7";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("potted_mac");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Pot);
        public override List<ItemSet> Sets => new List<ItemSet>
        {
            new ItemSet()
            {
                IsMandatory = false,
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    GetCastedGDO<Item, Cheese_Pouch>(),
                }
            },
             new ItemSet()
            {
                IsMandatory = true,
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    GetCastedGDO<Item, Cooked_Mac>(),
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess()
            {
                Duration = 2.5f,
                Result = GetCastedGDO<Item, Base_Ready_Mac>(),
                Process = (Process)GetExistingGDO(ProcessReferences.Knead),
            }
        };
      
    }
}
