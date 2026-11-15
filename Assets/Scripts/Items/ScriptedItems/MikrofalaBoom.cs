using UnityEngine;

public class MikrofalaBoom : MonoBehaviour, I_InteractiveJustPress
{
    public void Interacted()
    {
        Widelc w = GameObject.FindFirstObjectByType<Widelc>();
        if (Vector3.Distance(transform.position, w.transform.position) < 1)
        {
            GameObject.FindFirstObjectByType<Death>().Kys();
            Destroy(w.gameObject);
            Destroy(gameObject);
        }
    }
}
