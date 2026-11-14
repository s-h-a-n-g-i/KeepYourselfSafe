using UnityEngine;

public class Kran : MonoBehaviour, I_InteractiveJustPress
{
    [SerializeField] private GameObject woda;
    [SerializeField] private bool plynieWoda = false;

    public void Interacted()
    {
        plynieWoda = !plynieWoda;
    }

    void Update()
    {
        woda.SetActive(plynieWoda);
    }
}
