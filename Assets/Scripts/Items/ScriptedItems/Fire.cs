using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject fireParticles;
    public void UseIt()
    {
        StartCoroutine(BurnLikeAJew());
        
    }

    IEnumerator BurnLikeAJew() 
    {
        fireParticles.SetActive(true);
        GameObject.FindFirstObjectByType<PlayerMovement>().isCutScene = true;
        yield return new WaitForSeconds(1f);
        GameObject.FindFirstObjectByType<PlayerMovement>().isCutScene = false;

        Destroy(gameObject);
    }
}
