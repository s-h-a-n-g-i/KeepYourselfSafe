using UnityEngine;

public class ItemsNew : MonoBehaviour, I_Interactive
{
    //helloworld("print")
    private Transform player;
    private Rigidbody rb;
    private void Start()
    {
        player = GameObject.FindFirstObjectByType<Camera>().transform;
        rb = GetComponent<Rigidbody>();
    }
    public void Interacted()
    {
        Interaction();
    }

    public bool usable()
    {
        
        return true;
    }

    private void Interaction() 
    {
        transform.SetParent(player);
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void EndInteraction()
    {
        transform.SetParent(null);
    }
}
