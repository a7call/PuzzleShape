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

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public Shapes currentShape;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
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

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 9)
            winTextObject.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            //GetComponent<MeshCollider>().sharedMesh = other.GetComponent<MeshFilter>().mesh;
            
        }
           
    }
}
