using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElevatorDeath : MonoBehaviour
{
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
