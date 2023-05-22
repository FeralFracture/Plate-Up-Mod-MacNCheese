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
using System.Reflection;

namespace KitchenMacAndCheese
{
    public class Plated_Egged_Mac : CustomItemGroup
    {

        public override string UniqueNameID => "plate of cheesy dogs";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("plated_egged_mac");
        public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
        public override Item DisposesTo => (Item)GetExistingGDO(ItemReferences.Plate);
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override bool CanContainSide => true;
        public override string ColourBlindTag => "MCe";
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {

                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<Split_Egged_Mac>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
                },
                OrderingOnly = false,
                IsMandatory = true,
            }
        };
        public override ItemValue ItemValue => ItemValue.Medium;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            ItemGroup item = (ItemGroup)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Plate", new Material[] {
                MaterialUtils.GetExistingMaterial("Plate"),
                MaterialUtils.GetExistingMaterial("Plate - Ring")
                });
            MaterialUtils.ApplyMaterial(item.Prefab, "Noodles", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egged_Mac"]
                });
            MaterialUtils.ApplyMaterial(item.Prefab, "Cheese", new Material[] {
                CustomMaterials.CustomMaterialsIndex["Egg_Sauce"]
            });
        }
        public class Plated_Egged_Mac_Dish : CustomDish
        {
            //CustomGameDataObject
            public override string UniqueNameID => "Plated_Egged_Mac_Dish";

            //CustomUnlock
            public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
            public override bool IsUnlockable => true;
            public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
            public override CardType CardType => CardType.Default;
            public override int MinimumFranchiseTier => 0;
            public override bool IsSpecificFranchiseTier => false;
            public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
            public override float SelectionBias => 0;
            public override List<Unlock> HardcodedRequirements => new List<Unlock> { 
                (Unlock)GDOUtils.GetCustomGameDataObject<Plated_Mac_Dish>().GameDataObject
            };
            public override List<Unlock> HardcodedBlockers => new List<Unlock> { };

            //CustomDish
            public override DishType Type => DishType.Extra;
            public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GetExistingGDO(ItemReferences.Pot),
            (Item)GetCustomGameDataObject<BoxOfMac>().GameDataObject,
            (Item)GetExistingGDO(ItemReferences.Plate),
            (Item)GetExistingGDO(ItemReferences.Egg)
        };

            public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
        };
            public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GetCustomGameDataObject<Plated_Egged_Mac>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            },
        };

            public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Plated_Egged_Mac>().GameDataObject,
                Ingredient = (Item)GetExistingGDO(ItemReferences.Egg),
            },
        };
            public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "When making Mac N Cheese,  when adding the cheese,  add a cracked egg before mixing.  Serves four.  Each serving must be plated." }
        };

            public override void OnRegister(GameDataObject gameDataObject)
            {
                Dish dish = (Dish)gameDataObject;
                LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
                FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
                Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
                dict.Add(Locale.English, new UnlockInfo
                {
                    Name = "Mac N Cheese - Egg",
                    Description = "Adds egg as an ingredient.\n Adds menu Item: \n - Mac N Cheese with egg."
                });
                dictionary.SetValue(info, dict);
                dish.Info = info;
            }
        }
    }
}
