using System.Collections;
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
    [Header("Default Settings")]
    [SerializeField] private float timeToOpen;
    [SerializeField] private bool needKey;
    [SerializeField] private GameObject keyObject;

    private bool openedByKey;

    private bool opened;
    private Vector3 startPos;
    private Vector3 startRot;

    void Start()
    {
        startPos = transform.position;
        startRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    void Update()
    {
        //Helloworld("print");
    }

    public void Interacted()
    {
        StopAllCoroutines();
        if (needKey)
        {
            if (openedByKey)
                if (!opened)
                    Open();
                else
                    Close();
        }
        else
            if (!opened)
            Open();
        else
            Close();

    }

    private void Open()
    {
        opened = true;

    }
    private void Close()
    {
        opened = false;

    }


}
