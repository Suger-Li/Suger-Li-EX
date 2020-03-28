using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXDir : MonoBehaviour
{
    public float length = 2.0f;
    public float speed = 5.0f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y, startPos.z);
    }
}
