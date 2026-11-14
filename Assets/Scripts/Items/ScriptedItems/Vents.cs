using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Vents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Screwdriver>(out Screwdriver s))
        {
            GetComponent<Animator>().SetTrigger("Open");
            s.Used();
        }
    }
}
