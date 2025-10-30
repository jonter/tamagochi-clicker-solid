using System;

[Serializable]
public class GameData 
{
    public static GameData Instance;

    public float Coins = 0;
    public int CoinsPerClick = 1;

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




    
}

