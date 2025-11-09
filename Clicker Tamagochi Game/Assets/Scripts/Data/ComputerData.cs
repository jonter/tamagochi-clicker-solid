using System;

[Serializable]
public class ComputerData 
{
    //Уровень прокачки всего компа. 0 - бюждетный ноут, 1 - средний ноут,
    // 2 - игровой ПК, 3 - Дорогой игровой ПК, 4 - суперкомпьютер
    public int SetupLevel = 0;
    public int CPULevel = 1;
    public int RAMLevel = 1;
    public int VCLevel = 1;
    
    [NonSerialized]
    public float[] SetupPrices = {1500, 100000, 5000000, 1000000000};
    
    [NonSerialized]
    public int[] MaxLevels = {3, 7, 12, 20, 10000};

    public float CPUPrice = 40;
    public float RAMPrice = 200;
    public float VCPrice = 500;

    public event Action<int> OnSetupUpgrade;
    public event Action<int> OnCPUUpgrade;
    public event Action<int> OnRAMUpgrade;
    public event Action<int> OnVCUpgrade;

    public bool UpgradeSetup()
    {
        if (SetupLevel == 4) return false;
        float price = SetupPrices[SetupLevel];
        bool success = GameData.Instance.SpendCoins(price);
        if (success == false) return false;
        SetupLevel += 1;
        if(OnSetupUpgrade != null) OnSetupUpgrade(SetupLevel);
        return true;
    }

    public bool UpgradeCPU()
    {
        int max = MaxLevels[SetupLevel];
        if (CPULevel >= max) return false;
        bool success = GameData.Instance.SpendCoins(CPUPrice);
        if (success == false) return false;
        CPULevel += 1;
        CPUPrice *= 1.7f;
        if (OnCPUUpgrade != null) OnCPUUpgrade(CPULevel);
        return true;
    }

    // дописать, плиииз

    

}
