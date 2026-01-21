using System;

[Serializable]
public class GameData 
{
    public static GameData Instance;
    public PlayerData player = new PlayerData();
    public ComputerData computer = new ComputerData();
    public TamagochiData[] tamagochies;

    public float Coins = 0;
    private float multiplier = 1;

    public event Action<float> OnCoinsAdd;
    public event Action<float, bool> OnCoinsSpend;
        
    public void AddCoins(float add)
    {
        Coins += add;
        if (OnCoinsAdd != null) OnCoinsAdd(Coins);
    }

    public bool SpendCoins(float price)
    {
        if(Coins >= price)
        {
            Coins -= price;
            if (OnCoinsSpend != null) OnCoinsSpend(Coins, true);
            return true;
        }
        else
        {
            if (OnCoinsSpend != null) OnCoinsSpend(Coins, false);
            return false;
        }
    }


    public void EarnCoinsForClick()
    {
        float earn = computer.CPULevel;
        earn += (computer.RAMLevel - 1) * 10;
        earn += (computer.VCLevel - 1) * 50;
        // возможно сделать так, чтобы в зависимости от прокачки игрока
        // у нас также рос заработок
        earn *= multiplier;
        AddCoins(earn);
    }



    
}

