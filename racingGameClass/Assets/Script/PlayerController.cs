using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera camera;
    
    float speed = 0f;
    Vector2 leftpos;
    Vector2 middlepos;
    Vector2 rightpos;
    Vector3 targetPos;
    
    float currentTime = 0f;
    List<Vector2> posList = new List<Vector2>(3);
    
    
    private float disappearTime = 0f;
    void Start()
    {
        leftpos = new Vector2(-1.5f, this.gameObject.transform.position.y);
        middlepos = new Vector2(0f, this.gameObject.transform.position.y);
        rightpos = new Vector2(1.5f, this.gameObject.transform.position.y);
        
        posList.Add(leftpos);
        posList.Add(middlepos);
        posList.Add(rightpos);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float mousePos = camera.ScreenToWorldPoint(Input.mousePosition).x;
            float closeDistance = float.MaxValue;
            targetPos = Vector3.zero;
            
            foreach (var dir in posList)
            {
                targetPos = closeDistance > Math.Abs(mousePos - dir.x) ? dir : targetPos;
                closeDistance = Math.Abs(mousePos - dir.x);
            }

            StartCoroutine(PostionCouroutine());
        }
    }
    
    IEnumerator PostionCouroutine()
    {
        float maxTime = 10f;
        float time = currentTime / maxTime;

        while (true)
        {
            currentTime += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, currentTime);
            if (currentTime > maxTime)
            {
                currentTime = 0;
                yield break;
            }
        }
    }
}
