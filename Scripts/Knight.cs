using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private int life = 100;
    [SerializeField] private int damage = 10;
    private bool IsKnigthOn;
    [SerializeField] private Timer timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsKnigthOn && timer.RestTime <= 0)
        {
            IsKnigthOn = true;
            Debug.Log("Knigth Mode On " + damage);
            damage *= 2;
        }
    }
}
