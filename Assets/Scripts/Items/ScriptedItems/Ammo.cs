using UnityEngine;

public class Ammo : MonoBehaviour, I_InteractiveJustPress
{
    public void Interacted()
    {
        GameObject.FindFirstObjectByType<Pistol>().ammo++;
        Destroy(gameObject);
    }

}
