using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_3 : MonoBehaviour
{

    [SerializeField] private float speed = 10;
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    private Vector2 mov = new Vector2(0, 0);

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento Vertical
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movimientoVertical = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movimientoVertical = -1;
        }
        else
        {
            movimientoVertical = 0;
        }

        //Movimiento Horizontal
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimientoHorizontal = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimientoHorizontal = -1;
        }
        else
        {
            movimientoHorizontal = 0;
        }


    }

    private void FixedUpdate()
    {
        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        mov = mov.normalized;
        rb.velocity = mov * speed * Time.fixedDeltaTime;
    }
}
