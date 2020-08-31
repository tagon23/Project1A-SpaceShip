using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _MoveSpeed = 12f;
    [SerializeField] float _TurnSpeed = 3f;

    Rigidbody _rb = null;
    ParticleSystem _CachedSystem = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    //ship momentum forwards and backwards
    void MoveShip()
    {
        //S/down = -1, W/up = +1, none = 0. Scale by _MoveSpeed
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * -_MoveSpeed;
        //directional inputs
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        //apply movement to the object
        _rb.AddForce(moveDirection);
        
    }

    //turning (key turning likely)
    void TurnShip()
    {
        //A/left = -1, D/right = 1, none = 0
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * -_TurnSpeed;
        //specify axis
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        //spiin
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Kill()
    {
        Debug.Log("Conan has been the murdered");
        this.gameObject.SetActive(false);
    }

    
}

