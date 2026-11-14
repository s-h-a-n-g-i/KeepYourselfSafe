using TMPro;
using UnityEngine;

public class NovelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text answerText;
    [SerializeField] private NovelManager manager;
    public bool alreadyChosen = false;
    public bool thisButtonSafe = true;
    public void ButtonPressed() 
    {
        if (thisButtonSafe)
            DontKill();
        else
            Kill();
    }

    private void Kill()
    {
        alreadyChosen = true;
        manager.WrongChoice();
        gameObject.SetActive(false);
    }
    private void DontKill()
    {
        manager.GoodChoice();
    }

    public void SetupText(string text) 
    {
        answerText.text = text;
    }
}
