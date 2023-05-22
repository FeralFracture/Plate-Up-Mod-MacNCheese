using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace  KitchenMacAndCheese
{
    public class BoxMacProvider : CustomAppliance
    {
        public override string UniqueNameID => "SamsThing";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BoxMacProvider");
        public override string Name => "Boxed Mac and Cheese Rack";
        public override string Description => "Who doesn't love a Mac and Cheese? \'Cheese now included!\'";
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<BoxOfMac>().GameDataObject.ID)
		};
        //public override ShopRequirementFilter ShopRequirementFilter => ShopRequirementFilter.RefreshableProvider;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Appliance appliance = (Appliance)gameDataObject;
            MaterialUtils.ApplyMaterial(appliance.Prefab, "Frame", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal Dark")
            });
            MaterialUtils.ApplyMaterial(appliance.Prefab, "Boxes", new Material[] { 
                CustomMaterials.CustomMaterialsIndex["Box_Blue"],
                CustomMaterials.CustomMaterialsIndex["Cheesed_Mac"],
                MaterialUtils.GetExistingMaterial("Plate"),
            });
        }
    }
}
