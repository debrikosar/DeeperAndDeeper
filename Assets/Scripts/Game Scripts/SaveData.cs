using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public int goldAmount;

    //formated like "upgrade type" (key)/"upgrade level" (value)
    public Dictionary<string, int> upgradesStages;

    public SaveData(int goldAmount)
    {
        this.goldAmount = goldAmount;
        upgradesStages = new Dictionary<string, int>();
    }

    public void SaveUpgrades(List<UpgradeInfo> upgradesInfo)
    {
        upgradesStages.Clear();

        foreach (UpgradeInfo upgradeInfo in upgradesInfo)
            upgradesStages.Add(upgradeInfo.UpgradeName, upgradeInfo.UpgradeLevel);
    }
}
