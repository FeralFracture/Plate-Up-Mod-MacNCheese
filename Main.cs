using UnityEngine;
using System.Linq;
using System.Reflection;
using KitchenData;
using KitchenMods;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.References;

using static KitchenLib.Utils.GDOUtils;
using static KitchenMacAndCheese.Plated_Egged_Mac;
using static KitchenMacAndCheese.Plated_Egged_Dogged_Mac;

// Namespace should have "Kitchen" in the beginning
namespace KitchenMacAndCheese
{
    public class Main : BaseMod
    {
        // guid must be unique and is recommended to be in reverse domain name notation
        // mod name that is displayed to the player and listed in the mods menu
        // mod version must follow semver e.g. "1.2.3"
        public const string MOD_GUID = "SamsonRules2020.PlateUp.Mac_and_Cheese";
        public const string MOD_NAME = "Mac and Cheese";
        public const string MOD_VERSION = "0.3.4";
        public const string MOD_AUTHOR = "SamsonRules2020";
        public const string MOD_GAMEVERSION = ">=1.1.1";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.1" current and all future
        // e.g. ">=1.1.1 <=1.2.3" for all from/until

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }
        
        public static AssetBundle bundle;

        public static CustomDish plated_Mac_Dish;
        public static CustomDish plated_Dogged_Mac_Dish;
        public static CustomDish plated_Egged_Mac_Dish;
        public static CustomDish plated_Egged_Dogged_Mac_Dish;
        public static CustomDish mac_Ketchup_Upgrade;
        
        private void AddMaterials()
        {
            Material uncooked_Mac = new Material(Shader.Find("Simple Flat"));
            uncooked_Mac.name = "Uncooked_Mac";
            uncooked_Mac.SetColor("_Color0", ColorFromHex(0xFFFDED));
            uncooked_Mac.SetFloat("_Shininess", 0);
            uncooked_Mac.SetFloat("_OverlayScale", 10);

            Material cooked_Mac = new Material(Shader.Find("Simple Flat"));
            cooked_Mac.name = "Cooked_Mac";
            cooked_Mac.SetColor("_Color0", ColorFromHex(0xFFF8B6));
            cooked_Mac.SetFloat("_Shininess", 0);
            cooked_Mac.SetFloat("_OverlayScale", 10);

            Material cheesed_Mac = new Material(Shader.Find("Simple Flat"));
            cheesed_Mac.name = "Cheesed_Mac";
            cheesed_Mac.SetColor("_Color0", ColorFromHex(0xE9D21D));
            cheesed_Mac.SetFloat("_Shininess", 0);
            cheesed_Mac.SetFloat("_OverlayScale", 10);

            Material cheese_Sauce = new Material(Shader.Find("Simple Flat"));
            cheese_Sauce.name = "Cheese_Sauce";
            cheese_Sauce.SetColor("_Color0", ColorFromHex(0xD2A600));
            cheese_Sauce.SetFloat("_Shininess", 0);
            cheese_Sauce.SetFloat("_OverlayScale", 10);

            Material egged_Mac = new Material(Shader.Find("Simple Flat"));
            egged_Mac.name = "Egged_Mac"; 
            egged_Mac.SetColor("_Color0", ColorFromHex(0xFFF380));
            egged_Mac.SetFloat("_Shininess", 0);
            egged_Mac.SetFloat("OverlayScale", 10);

            Material egg_Sauce = new Material(Shader.Find("Simple Flat"));
            egg_Sauce.name = "Egg_Sauce";
            egg_Sauce.SetColor("_Color0", ColorFromHex(0xE8DC8B));
            egg_Sauce.SetFloat("_Shininess", 0);
            egg_Sauce.SetFloat("OverlayScale", 10);

            Material boxBlue = new Material(Shader.Find("Simple Flat"));
            boxBlue.name = "Box_Blue";
            boxBlue.SetColor("_Color0", ColorFromHex(0x1D34D6));
            boxBlue.SetFloat("_Shininess", 0);
            boxBlue.SetFloat("_OverlayScale", 10);



            AddMaterial(uncooked_Mac);
            AddMaterial(cooked_Mac);
            AddMaterial(cheesed_Mac);
            AddMaterial(boxBlue);
            AddMaterial(cheese_Sauce);
            AddMaterial(egged_Mac);
            AddMaterial(egg_Sauce);
        }

        private void AddGDOs()
        {
            //box items
            AddGameDataObject<BoxMacProvider>();
            AddGameDataObject<BoxOfMac>();
            AddGameDataObject<OpenedMacBox>();
            AddGameDataObject<GarbageBox>();
            //base mac items
            AddGameDataObject<Raw_Mac>();
            AddGameDataObject<Cheese_Pouch>();
            AddGameDataObject<Potted_Raw_Mac>();
            AddGameDataObject<Cooked_Mac>();
            AddGameDataObject<Unmixed_Base_Mac>();
            AddGameDataObject<Base_Ready_Mac>();
            AddGameDataObject<Split_Mac>();
            AddGameDataObject<Plated_Mac>();
            //hot dog mac items
            AddGameDataObject<Chopped_Hotdog>();
            AddGameDataObject<Unmixed_Dogged_Mac>();
            AddGameDataObject<Dogged_Ready_Mac>();
            AddGameDataObject<Split_Dogged_Mac>();
            AddGameDataObject<Plated_Dogged_Mac>();
            //egg mac items
            AddGameDataObject<Unmixed_Egg_Mac>();
            AddGameDataObject<Egged_Ready_Mac>();
            AddGameDataObject<Split_Egged_Mac>();
            AddGameDataObject<Plated_Egged_Mac>();
            //egg dog mac items
            AddGameDataObject<Unmixed_Egg_Dogged_Mac>();
            AddGameDataObject<Egged_Dogged_Ready_Mac>();
            AddGameDataObject<Split_Egged_Dogged_Mac>();
            AddGameDataObject<Plated_Egged_Dogged_Mac>();
        }

        public override void PostActivate(Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            AddMaterials();

            AddGDOs();

            plated_Mac_Dish = AddGameDataObject<Plated_Mac_Dish>();
            plated_Dogged_Mac_Dish = AddGameDataObject<Plated_Dogged_Mac_Dish>();
            plated_Egged_Mac_Dish = AddGameDataObject<Plated_Egged_Mac_Dish>();
            plated_Egged_Dogged_Mac_Dish = AddGameDataObject<Plated_Egged_Dogged_Mac_Dish>();
            mac_Ketchup_Upgrade = AddGameDataObject<Mac_Ketchup_Upgrade>();

            Events.BuildGameDataEvent += (s, args) =>
            {

                var hotdog = (Item)GetExistingGDO(ItemReferences.HotdogCooked);
                hotdog.DerivedProcesses.Add(
                    new Item.ItemProcess()
                    {
                        Duration = 1.2f,
                        Process = (Process)GetExistingGDO(ProcessReferences.Chop),
                        Result = GetCastedGDO<Item, Chopped_Hotdog>()
                    });

                args.gamedata.ProcessesView.Initialise(args.gamedata);
            };
        }

        protected override void OnUpdate()
        {
            ((Dish)plated_Dogged_Mac_Dish.GameDataObject).BlockedBy = plated_Dogged_Mac_Dish.HardcodedBlockers;
            ((Dish)plated_Egged_Mac_Dish.GameDataObject).BlockedBy = plated_Egged_Mac_Dish.HardcodedBlockers;
            ((Dish)plated_Egged_Dogged_Mac_Dish.GameDataObject).BlockedBy = plated_Egged_Dogged_Mac_Dish.HardcodedBlockers;
            ((Dish)mac_Ketchup_Upgrade.GameDataObject).BlockedBy = mac_Ketchup_Upgrade.HardcodedBlockers;
        }

        public static Color ColorFromHex(int hex)
        {
            return new Color(((hex & 0xFF0000) >> 16) / 255.0f, ((hex & 0xFF00) >> 8) / 255.0f, (hex & 0xFF) / 255.0f);
        }
    }

}
