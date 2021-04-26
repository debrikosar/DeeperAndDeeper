using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public int goldAmount;
    public int pearlAmount;
    public TimeSpan playTime;

    //formated like "upgrade type" (key)/"upgrade level" (value)
    public Dictionary<string, float> upgradesStages;
    public int airUpgradePrice;
    public int speedUpgradePrice;

    /*public SaveData(int goldAmount, int pearlAmount, TimeSpan playTime)
    {
        this.goldAmount = goldAmount;
        this.pearlAmount = pearlAmount;
        this.playTime = playTime;
        upgradesStages = new Dictionary<string, float>();
    }*/

    public SaveData(int goldAmount, int pearlAmount, TimeSpan playTime, Dictionary<string, float> upgradesStages, int airUpgradePrice, int speedUpgradePrice)
    {
        this.goldAmount = goldAmount;
        this.pearlAmount = pearlAmount;
        this.playTime = playTime;
        this.upgradesStages = upgradesStages;
        this.airUpgradePrice = airUpgradePrice;
        this.speedUpgradePrice = speedUpgradePrice;
    }

    public void SaveUpgrades(List<UpgradeInfo> upgradesInfo)
    {
        upgradesStages.Clear();

        foreach (UpgradeInfo upgradeInfo in upgradesInfo)
            upgradesStages.Add(upgradeInfo.UpgradeName, upgradeInfo.UpgradeLevel);
    }
}
