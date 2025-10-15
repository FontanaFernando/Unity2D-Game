using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour
{
    [SerializeField] private float n1 = 5;
    public float n2 = 3;
    // Start is called before the first frame update
    void Start()
    {
        n2 += n1;
        print("Hola");
        Debug.Log("Resultado: " + n2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
