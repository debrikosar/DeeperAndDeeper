using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInfo
{
    private string upgradeName;
    private int upgradeLevel;

    public UpgradeInfo(string upgradeName, int upgradeLevel)
    {
        this.upgradeName = upgradeName;
        this.upgradeLevel = upgradeLevel;
    }

    public UpgradeInfo(string upgradeName)
    {
        this.upgradeName = upgradeName;
        this.upgradeLevel = 0;
    }

    public string UpgradeName
    {
        get => upgradeName;
    }

    public int UpgradeLevel
    {
        get => upgradeLevel;
        set => upgradeLevel = value;
    }

    public void AddLevelToUpgrade() =>
        upgradeLevel++;
}
