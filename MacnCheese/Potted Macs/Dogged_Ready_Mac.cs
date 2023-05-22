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
    public class Dogged_Ready_Mac : CustomItem
    {
        public override string UniqueNameID => "TestItem2291";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("ready_dogged_mac");
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Pot);
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item SplitSubItem => GetCastedGDO<Item, Split_Dogged_Mac>();
        public override string ColourBlindTag => "MCh";
        public override int SplitCount => 4;
        public override float SplitSpeed => 1f;
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
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "cooked noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "Cheese.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "HotdogSlice1", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "HotdogSlice1.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p1 + "HotdogSlice1.002", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 2 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "cooked noodles.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "Cheese.001", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "HotdogSlice2", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p2 + "HotdogSlice2.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 3 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p3 + "cooked noodles.002", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p3 + "HotdogSlice3", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //portion 4 materials
            MaterialUtils.ApplyMaterial(item.Prefab, p4 + "cooked noodles.003", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"]
            });
            MaterialUtils.ApplyMaterial(item.Prefab, p4 + "HotdogSlice4", new Material[] {
                MaterialUtils.GetExistingMaterial("Soup - Meat"),
                MaterialUtils.GetExistingMaterial("Soil")
            });
            //bottom cheese
            MaterialUtils.ApplyMaterial(item.Prefab, "Cheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Cheese_Sauce"]
            });
            //splittable portions
            var splittable = Prefab.AddComponent<ObjectsSplittableView>();
            var items = new List<GameObject>();
            for (int i = 0; i < Prefab.transform.Find("Portions").childCount; i++)
                items.Add(Prefab.transform.Find("Portions").GetChild(i).gameObject);
            ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(splittable, items);
            //empties to pot
            item.SplitDepletedItems.Add((Item)GetExistingGDO(ItemReferences.Pot));
        }
    }
}
