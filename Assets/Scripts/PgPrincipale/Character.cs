[System.Serializable]

public class Character
{
    public string name;
    public int price;
    public bool isUnlocked;

    public Character(string name,int price, bool isUnlocked)
    {
        this.name = name;
        this.price = price;
        this.isUnlocked = isUnlocked;
    }

}
