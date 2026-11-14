using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElevatorDeath : MonoBehaviour
{
    [SerializeField] private Vector3 sizeKiller = new Vector3(1, 0.5f, 1);
    [SerializeField] private Vector3 directionKiller = new Vector3(0f, 0.1f, 0f);
    [SerializeField] private Vector3 playerSave = new Vector3(2, 1, 2);
    private Transform player;

  
    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position,player.position)<5)
            player.GetComponent<Death>().Kys(playerSave);
        

    }
}
