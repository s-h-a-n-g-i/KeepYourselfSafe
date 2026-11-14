using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Death : MonoBehaviour
{
    public bool died = false;
    [SerializeField] private GameObject canvasVisualNovel;

    void Start()
    {
        
    }

    void Update()
    {
        canvasVisualNovel.SetActive(died);
    }

    public void BackToLife()
    {
        GetComponent<PlayerMovement>().isCutScene = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        died = false;
    }
    public void Kys()
    {
        GetComponent<PlayerMovement>().isCutScene = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        died = true;
    }

    public void Kys(Vector3 posToSave)
    {
        GetComponent<PlayerMovement>().isCutScene = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        died = true;

        transform.position = posToSave;
    }

}
