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
    public class BoxOfMac : CustomItemGroup<BoxOfMac.ItemGroupViewAccessed>
    {
        public override string UniqueNameID => "BoxOfMac";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Box_Mac_Item");
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<BoxMacProvider>().GameDataObject;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override Item SplitSubItem => GetCastedGDO<Item, Raw_Mac>();
        public override int SplitCount => 1;
        public override float SplitSpeed => 1f;
        public override void OnRegister(GameDataObject gameDataObject)
        {

            ItemGroup item = (ItemGroup)gameDataObject;
            Prefab.GetComponent<ItemGroupViewAccessed>().Setup();
            MaterialUtils.ApplyMaterial(item.Prefab, "Box", new Material[] {
                MaterialUtils.GetExistingMaterial("Plate"),      
                CustomMaterials.CustomMaterialsIndex["Box_Blue"],
                MaterialUtils.GetExistingMaterial("Wood - Corkboard"),  
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"], 
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "ClosedLid", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Box_Blue"],
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"],
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "OpenLid", new Material[] {
                MaterialUtils.GetExistingMaterial("Wood - Corkboard"),
                CustomMaterials.CustomMaterialsIndex["Box_Blue"],
                
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "EmptyBox", new Material[] {
                MaterialUtils.GetExistingMaterial("Plate"),
                CustomMaterials.CustomMaterialsIndex["Box_Blue"],
                MaterialUtils.GetExistingMaterial("Wood - Corkboard"),
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"],
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "cheesepack", new Material[] {
                MaterialUtils.GetExistingMaterial("Plate"),
            });
            item.SplitDepletedItems.Add(GetCastedGDO<Item, OpenedMacBox>());
        }

        public class ItemGroupViewAccessed : ItemGroupView
        {
            internal void Setup()
            {
                ComponentGroups = new List<ComponentGroup>
                {
                    new ComponentGroup()
                    {
                        Objects = new List<GameObject>
                        {
                            gameObject.transform.Find("Box").gameObject,
                            gameObject.transform.Find("ClosedLid").gameObject
                        },
                        DrawAll = true,
                        Item = GetCastedGDO<Item, BoxOfMac>()
                    },
                    new ComponentGroup()
                    {
                        Objects = new List<GameObject>
                        {
                            gameObject.transform.Find("Box").gameObject,
                            gameObject.transform.Find("OpenLid").gameObject,
                            gameObject.transform.Find("cheesepack").gameObject
                        },
                        DrawAll = true,
                        Item = GetCastedGDO<Item, OpenedMacBox>(),
                    },
                    new ComponentGroup()
                    {
                        Objects = new List<GameObject>
                        {
                            gameObject.transform.Find("EmptyBox").gameObject,
                        },
                        DrawAll = true,
                        Item = GetCastedGDO<Item, GarbageBox>(),
                    },
                    //new ComponentGroup()
                    //{
                    //    GameObject = gameObject.transform.Find("cheesepack").gameObject,
                    //    Item = GetCastedGDO<Item, CheesePouch>(),
                    //},
                };
            }
        }
    }
}
