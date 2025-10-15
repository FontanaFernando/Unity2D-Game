using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private int xMov;
    private int yMov;
    private Vector2 mov;
    Animator animator;
    [SerializeField] private float speed;
    private float orgSpeed;
    private float multSpeed;
    [SerializeField] private float valMultSpeed = 1.75f;

    private Rigidbody2D rb;
    public int coinsObtained = 0;

    //* Attack Funtion ========
    private int comboCount = 0; //* variable para la funcion Attack
    [SerializeField] private float comboWindow = 0.5f; //* Tiempo en segundos para el siguiente ataque
    private Coroutine comboResetCoroutine; //* Para guardar la referencia a la coroutine


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        orgSpeed = speed;
        multSpeed = speed * valMultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Flip(moveInput);
        Sprint(multSpeed);
        XMov(1);
        YMov(1);
        SetFloat();
        Attack();
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void XMov(int a)
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xMov = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            xMov = -1;
        }
        else
        {
            xMov = 0;
        }
    }
    private void YMov(int a)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yMov = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            yMov = -1;
        }
        else
        {
            yMov = 0;
        }
    }

    private void FixedUpdate()
    {
        mov = new Vector2(xMov, yMov);
        mov = mov.normalized;
        rb.velocity = mov * speed;
    }

    private void Sprint(float multSpeed)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = multSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = orgSpeed;
        }
    }

    private void SetFloat()
    {
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0)
        {
            animator.SetFloat("xVelocity", 1);
        }
        else
        {
            animator.SetFloat("xVelocity", 0);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (comboCount == 1)
            {
                if (comboResetCoroutine != null)
                {
                    StopCoroutine(comboResetCoroutine);
                    comboResetCoroutine = null;
                }
                animator.SetTrigger("attack2");
                comboCount = 0;
            }
            else if (comboCount == 0)
            {
                animator.SetTrigger("attack1");
                comboCount++;
                comboResetCoroutine = StartCoroutine(ComboResetTimer());

                Debug.Log("Primer ataque lanzado. Combo timer iniciado.");
            }
        }
    }

    private IEnumerator ComboResetTimer()
    {
        yield return new WaitForSeconds(comboWindow);
        comboCount = 0;
        comboResetCoroutine = null;
        Debug.Log("Combo Reset");
    }

}
