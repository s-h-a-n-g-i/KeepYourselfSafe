using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, I_InteractiveJustPress
{

    [SerializeField] private bool opened = false;
    private bool doorUsedOnce = true;
    InputAction interact;
    private void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }
    public void Interacted()
    {
        if (doorUsedOnce && interact.ReadValue<float>() > 0)
        {
            doorUsedOnce = false;
            opened = !opened;
            GetComponent<Animator>().SetBool("Open", opened);
        }
    }
    private void Update()
    {

        if (!doorUsedOnce && interact.ReadValue<float>() <= 0)
            doorUsedOnce = true;
    }


}
