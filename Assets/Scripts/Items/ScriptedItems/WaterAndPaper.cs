using UnityEngine;

enum typeOfBoom 
{
    water,
    paper
}

public class WaterAndPaper : MonoBehaviour
{
    [SerializeField] private typeOfBoom typWybuchu;
    [SerializeField] private GameObject spawnToBlockDoors;
    [SerializeField] private Vector3 PlayerPosPapr;
    private void OnTriggerEnter(Collider other)
    {
        if (typeOfBoom.paper == typWybuchu)
        {
            if (other.TryGetComponent<Fire>(out Fire f))
            {
                spawnToBlockDoors.SetActive(true);
                f.UseIt();
                GameObject.FindFirstObjectByType<Death>().transform.position = PlayerPosPapr;
            }
        }
        else 
        {
            if (other.TryGetComponent<Toster>(out Toster f))
            {
                spawnToBlockDoors.SetActive(true);
                f.UseIt();
            }
        }
    }
}
