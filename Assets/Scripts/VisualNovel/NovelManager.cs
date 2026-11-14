using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NovelManager : MonoBehaviour
{
    [Header("Novel Settings")]
    [SerializeField] private NovelMessage[] messages;
    [Header("jak ktorys czarnuch to dotknie to lamie rece ~maciek")]
    [SerializeField] private int messCounter = 0;
    [SerializeField] private NovelButton[] guziki;
    [SerializeField] private TMP_Text babeczkaText;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Death death;

    [SerializeField] private bool buttonsReset = true;
    [SerializeField] private bool firstTime = true;
    [SerializeField] private Image girlImage; 
    [SerializeField] private Sprite normalFaceGirl;
    [SerializeField] private Sprite sadFaceGirl;
    [SerializeField] private Sprite glockGirl;
    private void Update()
    {
        if (messages[messCounter].isItKillable) 
        {
            CheckForLastButton();
        }
    }
    private void OnEnable()
    {
        girlImage.sprite = normalFaceGirl;
        firstTime = true;
        StartCoroutine(JustEnabled());
    }
    IEnumerator JustEnabled()
    {
        babeczkaText.text = "";
        HideButtons();
        if(buttonsReset)
            NewMessageReset();

        if(firstTime)
            yield return FadeStart();


        yield return new WaitForSeconds(0.5f);

        yield return E_WriteText(messages[messCounter].wiadomosc);

        ShowButtons();

    }
    private IEnumerator FadeStart()
    {
        firstTime = false;
        fadeImage.color = new Color(0, 0, 0, 1);
        for (int i = 160; i >= 0; i--)
        {
            fadeImage.color = new Color(0, 0, 0, (float)i / 100f);
            yield return new WaitForSeconds(0.02f);
        }
    }


    private void ShowButtons()
    {
        foreach (NovelButton btn in guziki)
        {
            btn.gameObject.SetActive(!btn.alreadyChosen);
        }
    }
    private void HideButtons()
    {
        foreach (NovelButton btn in guziki)
        {
            btn.gameObject.SetActive(false);
        }
    } 


    public void NewMessageReset() 
    {
        int i = 0;
        foreach (NovelButton btn in guziki)
        {
            btn.SetupText(messages[messCounter].odpowiedzi[i]);i++;
            btn.alreadyChosen = false;
            btn.thisButtonSafe = !messages[messCounter].isItKillable;
        }
        buttonsReset = false;
    }

    private void CheckForLastButton() 
    {
        int j = 0;
        foreach (NovelButton btn in guziki) 
        {
            if (!btn.alreadyChosen)
                j++;
        }
        if (j == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                guziki[i].thisButtonSafe = true;
            }
        }
    }


    IEnumerator E_WriteText(string text)
    {
        babeczkaText.text = "IMIE: ";
        for (int i = 0; i < text.Length; i++)
        {
            babeczkaText.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    

    public void GoodChoice()
    {
        HideButtons();
        StartCoroutine(GoodEnum());
    }
    IEnumerator GoodEnum()
    {
        yield return E_WriteText(messages[messCounter].dobryWybor);
        messCounter++;
        buttonsReset = true;
        yield return JustEnabled();
    }


    public void WrongChoice()
    {
        GameObject.FindFirstObjectByType<Death>().fadeoutRed.gameObject.SetActive(true);
        HideButtons();
        StartCoroutine(WrongEnum());
    }
    IEnumerator WrongEnum()
    {
        girlImage.sprite = sadFaceGirl;
        yield return E_WriteText(messages[messCounter].zlyWybor);
        yield return new WaitForSeconds(2f);

        girlImage.sprite = glockGirl;
        yield return new WaitForSeconds(0.5f);
        
        yield return death.FadeOut();
    }

}
