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
        if (Physics.BoxCast(transform.position, sizeKiller, directionKiller, out RaycastHit hit))
            if (hit.transform.TryGetComponent<Death>(out Death death))
                death.Kys(playerSave);
        

    }
}
