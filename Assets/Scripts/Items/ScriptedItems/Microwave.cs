using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Microwave : MonoBehaviour, I_InteractiveJustPress
{

    [SerializeField] private bool opened = false;
    public void Interacted()
    {
        opened = !opened;
        GetComponent<Animator>().SetBool("Open",opened);
    }

    

}
