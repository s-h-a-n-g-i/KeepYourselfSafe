using UnityEngine;

public class Crewbur : ItemGrab
{
    public void UseOnDoors() 
    {
        Destroy(gameObject);
    }
}
