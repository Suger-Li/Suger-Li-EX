using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posx = player.transform.position.x;
        float posy = player.transform.position.y;
        float posz = player.transform.position.z;

        transform.position = new Vector3(posx, posy + 10, posz - 10);
    }
}
