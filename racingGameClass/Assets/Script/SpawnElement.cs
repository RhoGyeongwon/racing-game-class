using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class SpawnElement : MonoBehaviour
{
    public GameObject[] itemPrefab = new GameObject[3];
    public List<GameObject> itemObjects = new List<GameObject>(3);
    List<Vector2> posList = new List<Vector2>(3);
    int[] randomNumList = new int[3];
    
    float delayTime = 0f;
    public static float speed { get; private set; } = -10f;
    
    Vector2 leftpos;
    Vector2 middlepos;
    Vector2 rightpos;

    private int RandomNum = 0;
    void Start()
    {
        delayTime = Random.Range(0f, 2f);

        leftpos = new Vector2(-1.5f, 0);
        middlepos = new Vector2(0f, 0);
        rightpos = new Vector2(1.5f, 0);

        posList.Add(leftpos);
        posList.Add(middlepos);
        posList.Add(rightpos);

        for (int i = 0; i < posList.Count; i++)
        {
            randomNumList[i] = Random.Range(0, 2);
            
            if (randomNumList[i] == 1)
            {
                itemObjects[i].SetActive(true);
                RandomNum = Random.Range(0, itemPrefab.Length);
                itemObjects[i] = itemPrefab[RandomNum];
            }
            else
            {
                itemObjects[i].SetActive(false);
            }
        }
        
        transform.position = new Vector2(transform.position.x, 6); //이거 맨윗줄에 적으면 자식 오브젝트 로컬 포지션값 바뀜..
    }
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            for (int i = 0; i < posList.Count; i++)
            {
                randomNumList[i] = Random.Range(0, 2);
            
                if (randomNumList[i] == 1)
                {
                    itemObjects[i].SetActive(true);
                    RandomNum = Random.Range(0, itemPrefab.Length);
                    itemObjects[i] = itemPrefab[RandomNum];
                    Debug.Log(itemObjects[i].name);
                }
                else
                {
                    itemObjects[i].SetActive(false);
                }
            }
            
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
