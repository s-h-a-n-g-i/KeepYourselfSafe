using UnityEngine;

public class Toster : MonoBehaviour
{
    public void UseIt()
    {
        FindFirstObjectByType<Death>().Kys();
        Destroy(gameObject);
    }
}
