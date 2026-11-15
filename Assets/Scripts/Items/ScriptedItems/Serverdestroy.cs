using UnityEngine;

public class Serverdestroy : MonoBehaviour, I_InteractiveJustPress
{
    [SerializeField] private Vector3 playerSave = new Vector3(2, 1, 2);
    private Transform player;
    [SerializeField] private GameObject hiddenObjectsToAppear;
    public void Interacted()
    {
        player.GetComponent<Death>().Kys(playerSave);
        hiddenObjectsToAppear.SetActive(true);
    }
}
