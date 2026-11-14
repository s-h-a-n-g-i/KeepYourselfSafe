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
                    StartCoroutine(Open());
                else
                    StartCoroutine(Close());
        }
        else
            if (!opened)
            StartCoroutine(Open());
        else
            StartCoroutine(Close());

    }

    private IEnumerator Open()
    {
        opened = true;
        for (int i = 0; i <= 120; i++)
        {
            float x = (transform.localPosition.x / openPosition.x / 120);
            float y = (transform.localPosition.y / openPosition.y / 120);
            float z = (transform.localPosition.z / openPosition.z / 120);

            Vector3 moveTracking = new Vector3(x,y,z);
            transform.localPosition += moveTracking;
            yield return new WaitForSeconds(1/120);
        }

    }
    private IEnumerator Close()
    {
        opened = false;
        yield return new WaitForSeconds(1 / 120);

    }


}
