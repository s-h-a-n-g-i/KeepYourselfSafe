using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElevatorDeath : MonoBehaviour
{
    [SerializeField] private Vector3 playerSave = new Vector3(2, 1, 2);
    private Transform player;
    [SerializeField] private GameObject hiddenObjectsToAppear;
    [SerializeField] private Animator doorsAnimator;
    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 5)
        {
            doorsAnimator.SetBool("Open",false);
            player.GetComponent<Death>().Kys(playerSave);
            hiddenObjectsToAppear.SetActive(true);
        }
        
    }
}
