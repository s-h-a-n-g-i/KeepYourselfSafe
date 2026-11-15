using UnityEngine;

public class Toster : ItemGrab
{
    public void UseIt()
    {
        FindFirstObjectByType<Death>().Kys();
        Destroy(gameObject);
    }
}
