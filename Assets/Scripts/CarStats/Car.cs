public class Car
{
    public string name {private set; get;}
    public CarEnum carEnum {private set; get;}
    public DriveEnum driveEnum {private set; get;}
    public float horsePower {private set; get;}
    public float brakePower {private set; get;}
    public float maxSpeed {private set; get;}
    public float steeringAngle {private set; get;}

    public Car(string name, CarEnum carEnum, DriveEnum driveEnum, float horsepower, float brakepower, float maxspeed, float steeringangle)
    {
        this.name = name;
        this.carEnum = carEnum;
        this.driveEnum = driveEnum;
        this.horsePower = horsepower;
        this.brakePower = brakepower;
        this.maxSpeed = maxspeed;
        this.steeringAngle = steeringangle;
    }
}
