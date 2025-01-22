using System.Collections;
using UnityEngine;

public class ItemCollsion : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerInfo.DecreseHp();
        }
        
        if (other.gameObject.CompareTag("CanFood"))
        {
            PlayerInfo.IncreseHp();
        }
        
        Destroy(other.gameObject);
    }
}
