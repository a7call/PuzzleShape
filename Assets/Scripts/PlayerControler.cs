using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public bool isIsometric = false;
    public Shapes currentShape;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        if (isIsometric)
        {
            Vector3 toConvert = new Vector3(movementVector.x, 0, movementVector.y);
            Vector3 direction = IsoVectorConvert(toConvert);
            movementX = direction.x;
            movementY = direction.z;
        }
        else
        {
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
      

      
    }
    private Vector3 IsoVectorConvert(Vector3 vector)
    {
        Quaternion rotation = Quaternion.Euler(0, -45, 0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
        Vector3 result = isoMatrix.MultiplyPoint3x4(vector);
        return result;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementY);
        rb.AddForce(movement *speed* Time.fixedDeltaTime);
    }

}
