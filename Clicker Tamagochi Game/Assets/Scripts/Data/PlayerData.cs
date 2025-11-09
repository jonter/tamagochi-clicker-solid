using System;

[Serializable]
public class PlayerData 
{
    public int Level = 1;
    public int Exp = 0;
    public int ExpBorder = 100;

    public event Action<int> OnLevelUp;
    public event Action<int, int> OnExpChanged;

    public void AddExp(int add)
    {
        Exp += add;
        if (Exp >= ExpBorder)
        {
            Exp -= ExpBorder;
            Level += 1;
            ExpBorder += 50;
            if (OnLevelUp != null) OnLevelUp(Level);
        }
        if (OnExpChanged != null) OnExpChanged(Exp, ExpBorder);
    }

   

   
}
