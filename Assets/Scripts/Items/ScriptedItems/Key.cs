using UnityEngine;

public class Key : ItemGrab
{
    public void UseOnDoors()
    {
        Destroy(gameObject);
    }
}
