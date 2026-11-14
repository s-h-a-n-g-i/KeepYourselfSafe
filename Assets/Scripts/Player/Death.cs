using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class Death : MonoBehaviour
{
    public bool died = false;
    [SerializeField] private GameObject canvasVisualNovel;
    public Image fadeoutRed;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(fadeoutRed.IsActive())
            StartCoroutine(FadeOut());
    }


    private IEnumerator FadeOut()
    {
        fadeoutRed.color = new Color(1, 0, 0, 1);
        for (int i = 160; i >= 0; i--)
        {
            fadeoutRed.color = new Color(1, 0, 0, (float)i / 100f);
            yield return new WaitForSeconds(0.02f);
        }
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
