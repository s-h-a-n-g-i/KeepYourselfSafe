using System;
using UnityEngine;

[Serializable]
public class NovelMessage
{
    [TextArea(3, 20)] public string wiadomosc;
    public string[] odpowiedzi = new string[4];
    public bool isItKillable = false;
    [TextArea(3, 20)] public string zlyWybor;
    [TextArea(3, 20)] public string dobryWybor;


    


}
