using UnityEngine;

public class Screwdriver : ItemGrab
{
    public void Used() 
    {
        Destroy(gameObject);
    }
}
