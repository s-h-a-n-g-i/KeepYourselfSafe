using UnityEngine;

public class Pistol : ItemGrab
{
    [SerializeField] private Transform shootPoint;
    public override void UseItem()
    {
        Debug.DrawRay(shootPoint.position, shootPoint.forward,Color.red,10);
        Ray raycastCheckObject = new Ray(shootPoint.position, shootPoint.forward * 1000);
        if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, 1000))
            if (hit.collider.gameObject.TryGetComponent(out PlayerMovement player))
                GameObject.FindFirstObjectByType<Death>().Kys();
    }
}
