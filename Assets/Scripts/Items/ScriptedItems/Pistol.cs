using UnityEngine;

public class Pistol : ItemGrab
{
    public int ammo = 1;
    [SerializeField] private Transform shootPoint;
    public override void UseItem()
    {
        if (ammo > 0)
        {
            Ray raycastCheckObject = new Ray(shootPoint.position, shootPoint.forward * 1000);
            if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, 1000))
                if (hit.collider.gameObject.TryGetComponent(out PlayerMovement player))
                {
                    GameObject.FindFirstObjectByType<Death>().Kys(); 
                    ammo--;
                }
                else 
                {
                    
                }

        }
    }
}


