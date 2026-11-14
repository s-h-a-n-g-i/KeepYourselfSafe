using System.Collections;
using UnityEngine;

public class Mroznia : MonoBehaviour
{
    [SerializeField] private Vector3 playerSave = new Vector3(2, 1, 2);
    [SerializeField] private float czasMrozenia = 5;
    [SerializeField] private Animator animacjaDrzwi;
    private Transform player;
    private bool started = false;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 5 && !started)
        {
            started = true;
            animacjaDrzwi.SetBool("Open", false);
            StartCoroutine(mrozon());
        }

    }


    IEnumerator mrozon() 
    {
        yield return new WaitForSeconds(czasMrozenia);
        player.GetComponent<Death>().Kys(playerSave);
    }
}
