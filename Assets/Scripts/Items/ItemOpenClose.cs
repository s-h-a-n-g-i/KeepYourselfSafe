using UnityEngine;

public enum OpenerType 
{
    shelf,
    door
}

public class ItemOpenClose : MonoBehaviour, I_InteractiveOpenClose
{
    [SerializeField] private OpenerType typ;
    [Header("Shelf Settings")]
    [SerializeField] private Vector3 openPosition;
    [Header("Door Settings")]
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private bool needKey;
    [SerializeField] private GameObject keyObject;
    [Header("Default Settings")]
    [SerializeField] private float timeToOpen;

    private Vector3 startPos;
    private Vector3 startRot;

    void Start()
    {
        startPos = transform.position;
        //startRot = transform.rotation;
    }

    void Update()
    {

    }

    public void Interacted()
    {

    }
}
