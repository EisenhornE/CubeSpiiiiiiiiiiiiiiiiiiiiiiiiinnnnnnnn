using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is just me testing how to use Android Development in Unity. There's nothing noteworthy here.
// The codes here are already self-explanatory.

public class SquareSpin : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _left = true;
    private bool _right = false;
    [SerializeField] static float _rotationSpeed = 60f;
    float baseRotationSpeed = _rotationSpeed;
    float addSpeed = 60f;

    void Start()
    {
        _rb = GameObject.Find("Square").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // For the initial kick for it to rotate
        _rb.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        if (!_left)
        {
            StartCoroutine(Left());
        }
        else
        {
            StartCoroutine(Right());
        }
    }

    // SO it will turn left
    IEnumerator Left()
    {
        yield return new WaitForSeconds(5);
        if (!_left)
        {
            _rotationSpeed = baseRotationSpeed + addSpeed;
            _left = true;
            _right = false;
            baseRotationSpeed = _rotationSpeed;
            Debug.Log(baseRotationSpeed);
            Debug.Log("Left");
        }
    }
    // So it will turn right
    IEnumerator Right()
    {
        yield return new WaitForSeconds(5);
        if (!_right)
        {
            _rotationSpeed = -baseRotationSpeed + -addSpeed;
            _left = false;
            _right = true;
            baseRotationSpeed = Mathf.Abs(_rotationSpeed);
            Debug.Log(_rotationSpeed);
            Debug.Log(baseRotationSpeed);
            Debug.Log("Right");
        }
    }
}
