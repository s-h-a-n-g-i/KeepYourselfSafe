using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crewbur>(out Crewbur c))
        {
            
        }
    }
}
