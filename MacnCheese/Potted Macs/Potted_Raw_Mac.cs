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
    public class Potted_Raw_Mac : CustomItemGroup<Potted_Raw_Mac.ItemGroupViewAccessed>
    {
        public override string UniqueNameID => "SamsThing3";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("potted_mac");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Pot);
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetComponent<ItemGroupViewAccessed>().Setup();
        }
        public override List<ItemSet> Sets => new List<ItemSet>
        {
            new ItemSet()
            {
                IsMandatory = false,
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    (Item)GetExistingGDO(ItemReferences.Water)
                }
            },
            new ItemSet()
            {
                IsMandatory = false,
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    GetCastedGDO<Item, Raw_Mac>(),
                }
            },
             new ItemSet()
            {
                IsMandatory = true,
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    (Item)GetExistingGDO(ItemReferences.Pot)
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess()
            {
                Duration = 4.5f,
                Result = GetCastedGDO<Item, Cooked_Mac>(),
                Process = (Process)GetExistingGDO(ProcessReferences.Cook),
            }
        };

        public class ItemGroupViewAccessed : ItemGroupView
        {
            internal void Setup()
            {
                var noodles = gameObject.transform.Find("Noodles").gameObject;
                ComponentGroups = new List<ComponentGroup>
                {
                    new ComponentGroup()
                    {
                        GameObject = gameObject.transform.Find("Water").gameObject,
                        Item = (Item)GetExistingGDO(ItemReferences.Water)
                    },
                    new ComponentGroup()
                    {
                        GameObject = noodles.transform.Find("uncooked noodles").gameObject,
                        Item = GetCastedGDO<Item, Raw_Mac>(),
                    },
                    new ComponentGroup()
                    {
                        GameObject = noodles.transform.Find("cooked noodles").gameObject,
                        Item = GetCastedGDO<Item, Cooked_Mac>(),
                    },
                    new ComponentGroup()
                    {
                        GameObject = gameObject.transform.Find("cheesepack").gameObject,
                        Item = GetCastedGDO<Item, Cheese_Pouch>(),
                    },
                     new ComponentGroup()
                    {
                        GameObject = gameObject.transform.Find("HotDogSlices").gameObject,
                        Item = GetCastedGDO<Item, Chopped_Hotdog>(),
                    },
                     new ComponentGroup()
                    {
                        GameObject = gameObject.transform.Find("Egg").gameObject,
                        Item = (Item)GetExistingGDO(ItemReferences.EggCracked)
                    },
                };
            }
        }
    }
}
