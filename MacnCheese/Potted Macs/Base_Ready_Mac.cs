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
    public class Base_Ready_Mac : CustomItemGroup<Base_Ready_Mac.ItemGroupViewAccessed>
    {
        public override string UniqueNameID => "TestItem229";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("mixed_mac_pot");
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Pot);
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item SplitSubItem => GetCastedGDO<Item, Split_Mac>();
        public override int SplitCount => 4;
        public override float SplitSpeed => 1f;
        public override string ColourBlindTag => "";
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var p1 = "Portions/Portion1/";
            var p2 = "Portions/Portion2/";
            var p3 = "Portions/Portion3/";
            var p4 = "Portions/Portion4/";
            Item item = (Item)gameDataObject;
            //pot meshes
            MaterialUtils.ApplyMaterial(item.Prefab, "Pot/Pot", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "Pot/Handles", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal Dark")
            });
            //portion 1 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "Noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "Cheese.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "EggNoodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "EggCheese.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egg_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "HotdogSlice1", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 2 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "Noodles.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "Cheese.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "EggNoodles.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "EggCheese.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egg_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "HotdogSlice2", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 3 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p3 + "Noodles.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p3 + "EggNoodles.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p3 + "HotdogSlice3", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 4 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p4 + "Noodles.003", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p4 + "EggNoodles.003", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p4 + "HotdogSlice4", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //bottom cheese
            MaterialUtils.ApplyMaterial(item.Prefab, "Cheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, "EggCheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egg_Sauce"]
            });
            //splittable portions
            Prefab.GetComponent<ItemGroupViewAccessed>().Setup();
            var splittable = Prefab.AddComponent<ObjectsSplittableView>();
            var items = new List<GameObject>();
            for (int i = 0; i < Prefab.transform.Find("Portions").childCount; i++)
                items.Add(Prefab.transform.Find("Portions").GetChild(i).gameObject);
            ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(splittable, items);
            //empties to pot
            item.SplitDepletedItems.Add((Item)GetExistingGDO(ItemReferences.Pot));
        }
        public class ItemGroupViewAccessed : ItemGroupView
        {
            internal void Setup()
            {
                var portions = gameObject.transform.Find("Portions").gameObject;
                var portion1 = portions.transform.Find("Portion1").gameObject;
                var portion2 = portions.transform.Find("Portion2").gameObject;
                var portion3 = portions.transform.Find("Portion3").gameObject;
                var portion4 = portions.transform.Find("Portion4").gameObject;
                ComponentGroups = new List<ComponentGroup>
                {
                    new ComponentGroup()
                    {
                        Objects = new List<GameObject>
                        {
                            gameObject.transform.Find("Portions")
                            .gameObject.transform.Find("Portion1")
                            .gameObject.transform.Find("Cheese.002").gameObject,
                            portion1.transform.Find("Noodles").gameObject,
                            portion2.transform.Find("Cheese.001").gameObject,
                            portion2.transform.Find("Noodles.001").gameObject,
                            portion3.transform.Find("Noodles.002").gameObject,
                            portion4.transform.Find("Noodles.003").gameObject,
                            gameObject.transform.Find("Cheese").gameObject
                        },
                        DrawAll = true,
                        Item = GetCastedGDO<Item, Base_Ready_Mac>()
                    },
                    new ComponentGroup()
                    {
                        Objects = new List<GameObject>
                        {
                            portion1.transform.Find("EggCheese.002").gameObject,
                            portion1.transform.Find("EggNoodles").gameObject,
                            portion2.transform.Find("EggCheese.001").gameObject,
                            portion2.transform.Find("EggNoodles.001").gameObject,
                            portion3.transform.Find("EggNoodles.002").gameObject,
                            portion4.transform.Find("EggNoodles.003").gameObject,
                            gameObject.transform.Find("EggCheese").gameObject
                        },
                        DrawAll = true,
                        Item = GetCastedGDO<Item, Egged_Ready_Mac>()
                    },
                };
                ComponentLabels = new List<ColourBlindLabel>()
                {
                    new ColourBlindLabel()
                    {
                        Text = "MC",
                        Item = GetCastedGDO<Item, Base_Ready_Mac>()
                    },
                    new ColourBlindLabel()
                    {
                        Text = "MCe",
                        Item = GetCastedGDO<Item, Egged_Ready_Mac>()
                    },
                };
            }
        }
    }
}
