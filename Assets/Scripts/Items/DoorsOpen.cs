using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class DoorsOpen : MonoBehaviour
{
    private bool openedByKey;

 

    private void OnTriggerEnter(Collider other)
    {
        if (!openedByKey) 
        {
            if (other.TryGetComponent<Key>(out Key c))
            {
                c.UseOnDoors();
                GetComponent<Animator>().SetBool("Open",true);
            }
        }
    }


}
