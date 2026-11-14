using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ElevatorDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crewbur>(out Crewbur c))
        {
            c.UseOnDoors();
            GetComponent<Animator>().SetBool("Open",true);
        }
    }
}
