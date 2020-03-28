using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minTime = 2f;
    public float maxTime = 5f;
    public float xMinPosition = -10f;
    public float xMaxPosition = 10f;
    public float yMinPosition = 0f;
    public float yMaxPosition = 10f;
    public float zMinPosition = 10f;
    public float zMaxPosition = 20f;
    private float interval;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetRandomPosition();
            time = 0f;
            interval = GetRandomTime();
        }
    }

    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        return new Vector3(x, y, z);
    }
}