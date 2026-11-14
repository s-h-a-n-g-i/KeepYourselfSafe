using UnityEngine;

enum typeOfBoom 
{
    water,
    paper
}

public class WaterAndPaper : MonoBehaviour
{
    [SerializeField] private typeOfBoom typWybuchu;


    private void OnTriggerEnter(Collider other)
    {
        if (typeOfBoom.paper == typWybuchu)
        {
            if (other.TryGetComponent<Fire>(out Fire f))
            {
                f.UseIt();
            }
        }
        else 
        {
            if (other.TryGetComponent<Toster>(out Toster f))
            {
                f.UseIt();
            }
        }
    }
}
