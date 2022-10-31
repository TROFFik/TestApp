using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Vector3 rotateDirection;
    private Vector3 moveDirection;

    public int ChangeSpeed
    {
        set
        {
            _moveSpeed = value;
        }
    }
    private void Update()
    {
        rotateDirection.y = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDirection * _moveSpeed);
        transform.Rotate(rotateDirection * _rotateSpeed);
    }
    public void StartPosition(int SizeX, int SizeZ)
    {
        transform.position = new Vector3(Random.Range(1, SizeX), 0.6f, Random.Range(1, SizeZ));
    }
}
