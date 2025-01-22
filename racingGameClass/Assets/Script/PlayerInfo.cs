using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static int hp { get; private set; }
    public const int MaxHp = 5;

    float currentTime = 0f;
    float fullTime = 4f;
    void Start()
    {
        hp = MaxHp;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime > fullTime)
        {
            currentTime = 0f;
            DecreseHp();
        }
    }

    public static void DecreseHp()
    {
        --hp;
        hp = hp < 0 ? 0 : hp;
    }
    
    public  static void IncreseHp()
    {
        ++hp;
        hp = hp > MaxHp ? MaxHp : hp;
    }
}
