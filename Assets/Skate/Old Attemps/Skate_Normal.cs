using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skate_Normal : MonoBehaviour
{
    [SerializeField] private float spurtSpeed = 20f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float focusHeight = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpurtsKeyDown();
        MoveSpurtsKeyUp();
        transform.up = new Vector3(0, focusHeight, 0) - transform.position;
        return;
        float xDirection = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * speed, 0f) * Time.deltaTime, ForceMode2D.Impulse);
    }

    void MoveSpurtsKeyDown()
    {
        float xDirection = 0f;
        if (Input.GetKeyDown(KeyCode.A))
        {
            xDirection = -1f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            xDirection = 1f;
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * spurtSpeed, 0f) * Time.deltaTime, ForceMode2D.Impulse);
    }

    void MoveSpurtsKeyUp()
    {
        float xDirection = 0f;
        if (Input.GetKeyUp(KeyCode.A))
        {
            xDirection = -1f;
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            xDirection = 1f;
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * speed, 0f) * Time.deltaTime, ForceMode2D.Impulse);

    }
}
