using System;

public class SaveData
{
    public static string playerName;
    public static string  date;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float timeStamp;

    public SaveData(float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, float timeStamp)
    {
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
        this.rotationX = rotationX;
        this.rotationY = rotationY;
        this.rotationZ = rotationZ;
        this.timeStamp = timeStamp;
    }

    public static void setName(string name)
    {
        playerName = name;
    }

    public static void setDate()
    {
        date = DateTime.Now.ToString("yyyy/MM/dd");
    }
}
