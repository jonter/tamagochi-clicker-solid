using System;

[Serializable]
public class GameData 
{
    public static GameData Instance;
    public PlayerData player = new PlayerData();
    public ComputerData computer = new ComputerData();
    public TamagochiData[] tamagochies = new TamagochiData[0];

    public float Coins = 0;
    private float multiplier = 1;

    public event Action<float> OnCoinsAdd;
    public event Action<float, bool> OnCoinsSpend;
    public event Action OnTamagochiBuy;
        
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

    ////////////// логика покупки тамагочи

    float[] tamagochiPrices = { 500, 20000, 100000, 1500000, 500000000, 10000000000 };
    public float GetTamagochiPrice()
    {
        int lenght = tamagochies.Length;
        if (lenght >= 6) return -1;

        return tamagochiPrices[lenght];
    }

    public bool BuyTamagochi()
    {
        float price = GetTamagochiPrice();
        if (Coins >= price)
        {
            SpendCoins(price);
            return true;
        }
        return false;
    }

    public void AddTamagochi(string name, int skinID)
    {
        TamagochiData td = new TamagochiData();
        td.SkinType = skinID;
        td.Nick = name;
        // добавить тамагочи в массив
        TamagochiData[] newarray = new TamagochiData[tamagochies.Length + 1];
        for(int i = 0; i < tamagochies.Length; i++)
        {
            newarray[i] = tamagochies[i];
        }
        newarray[tamagochies.Length] = td;
        tamagochies = newarray;
        if (OnTamagochiBuy != null) OnTamagochiBuy();
    }

    //////////////
    
}

