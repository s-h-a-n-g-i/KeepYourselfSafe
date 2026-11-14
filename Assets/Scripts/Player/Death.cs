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
        
        
    }

    public void dontSkipFadePls() 
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        died = false;
        fadeoutRed.color = new Color(1, 0, 0, 1);
        for (int i = 130; i >= 0; i--)
        {
            fadeoutRed.color = new Color(1, 0, 0, (float)i / 100f);
            yield return new WaitForSeconds(0.02f);
        }
        BackToLife();
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
