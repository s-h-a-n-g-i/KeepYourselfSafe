using UnityEngine;

public class Ink : ItemGrab
{
    public override void UseItem()
    {
        GameObject.FindFirstObjectByType<Death>().Kys();
        Destroy(gameObject);
    }
}
