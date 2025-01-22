using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public static float speed { get; private set; } = -10f;

    void Start()
    {
        transform.position = new Vector2(transform.position.x, 6);
    }
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector2(transform.position.x, 6);
        }
    }

    public static void SpeedUp()
    {
        speed = -20f;
    }
    
    public static void SpeedInitilaize()
    {
        speed = -10f;
    }
}
