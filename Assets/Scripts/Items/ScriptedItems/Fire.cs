using UnityEngine;

public class Fire : MonoBehaviour
{
    public void UseIt()
    {
        Destroy(gameObject);
        FindFirstObjectByType<Death>().Kys();
    }
}
