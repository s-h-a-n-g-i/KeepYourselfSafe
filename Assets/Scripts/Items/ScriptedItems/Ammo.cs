using UnityEngine;

public class Ammo : ItemGrab
{
    public override void UseItem() 
    {
        GameObject.FindFirstObjectByType<Pistol>().ammo++;
        Destroy(gameObject);
    }
}
