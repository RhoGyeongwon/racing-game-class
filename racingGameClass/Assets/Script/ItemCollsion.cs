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
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(CollisionCouroutine(2f));
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            PlayerInfo.DecreseHp();
        }
        
        if (other.gameObject.CompareTag("CanFood"))
        {
            PlayerInfo.IncreseHp();
        }
        
        if (other.gameObject.CompareTag("Booster"))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(CollisionCouroutine(2f));
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            ObstacleMove.SpeedUp();
            StartCoroutine(CollisionCouroutine(2f));
            ObstacleMove.SpeedInitilaize();
        }
        
        Destroy(other.gameObject);
    }
    
    IEnumerator CollisionCouroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
