using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Life : MonoBehaviour
{
    int life = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeLife(100);
        print("Vida Actual: " + life);
    }

    void ChangeLife(int a)
    {
        life += a;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
