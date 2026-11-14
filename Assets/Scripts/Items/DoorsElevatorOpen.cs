using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum TypDrzwi 
{
    doors,
    elevator
}

[RequireComponent(typeof(Animator))]
public class DoorsElevatorOpen : MonoBehaviour
{
    [SerializeField] private TypDrzwi typeOfDoors;
    private bool openedByKey;
    [SerializeField] private GameObject key;
 

    private void OnTriggerEnter(Collider other)
    {
        if (typeOfDoors == TypDrzwi.doors)
        {
            if (!openedByKey)
            {
                if (other.TryGetComponent<Key>(out Key c) && c.gameObject == key )
                {
                    c.UseOnDoors();
                    GetComponent<Animator>().SetBool("Open", true);
                }
            }

        }
        else
        {
            if (other.TryGetComponent<Crewbur>(out Crewbur c))
            {
                c.UseOnDoors();
                GetComponent<Animator>().SetBool("Open", true);
            }
        }
    }

}
