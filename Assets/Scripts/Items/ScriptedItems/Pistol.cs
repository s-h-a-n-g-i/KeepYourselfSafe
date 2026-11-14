using UnityEngine;
using UnityEngine.UIElements;

public class Pistol : ItemGrab
{
    public int ammo = 1;
    [SerializeField] private Transform shootPoint;
    public override void UseItem()
    {

        if (ammo > 0)
        {
            Ray raycastCheckObject1 = new Ray(shootPoint.position, shootPoint.forward * 1000);
            Ray raycastCheckObject2 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(0.1f, 0, 0)) * 1000);
            Ray raycastCheckObject3 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(0, 0.1f, 0)) * 1000);
            Ray raycastCheckObject4 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(0, 0, 0.1f)) * 1000);
            Ray raycastCheckObject5 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(-0.1f, 0, 0)) * 1000);
            Ray raycastCheckObject6 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(0, -0.1f, 0)) * 1000);
            Ray raycastCheckObject7 = new Ray(shootPoint.position, (shootPoint.forward + new Vector3(0, 0, -0.1f)) * 1000);

            Ray[] rays =
                {
                    raycastCheckObject1,
                    raycastCheckObject2,
                    raycastCheckObject3,
                    raycastCheckObject4,
                    raycastCheckObject5,
                    raycastCheckObject6,
                    raycastCheckObject7
                };
            foreach (Ray ray in rays)
                if (Physics.Raycast(ray, out RaycastHit hit, 1000))
                {
                    if (hit.collider.gameObject.TryGetComponent(out PlayerMovement player))
                    {
                        GameObject.FindFirstObjectByType<Death>().Kys();
                        ammo--;
                        return;
                    }
                }
            Debug.Log("miss");
        }

        
    }
}


