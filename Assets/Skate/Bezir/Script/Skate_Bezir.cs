using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using PathCreation;
using Unity.Profiling;

public class Skate_Bezir: MonoBehaviour
{
    //[SerializeField] private float spurtSpeed = 20f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float kindOfGravity = 0.1f;
    [SerializeField] private float kindOfMomentum = 0.1f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private float leftEdge = 0.1f;
    [SerializeField] private float rightEdge = 0.9f;
    private float positionAlongPath = 0.5f;
    private float momentum = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionChange = 0f;
        if (positionAlongPath >= leftEdge && positionAlongPath <= rightEdge)
        {
            positionChange = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }

        momentum += positionChange;
        momentum = Mathf.Lerp(momentum, 0f, kindOfMomentum);
        momentum = Mathf.Clamp(momentum, -maxSpeed, maxSpeed);
        
        positionChange = positionAlongPath - Mathf.Lerp(positionAlongPath, 0.5f, kindOfGravity);
        positionAlongPath -= positionChange;
        
        positionAlongPath += momentum;
        
        positionAlongPath = Mathf.Clamp(positionAlongPath, leftEdge, rightEdge);

        //transform.position = pathCreator.path.GetPointAtTime(positionAlongPath);
        transform.DOMove(pathCreator.path.GetPointAtTime(positionAlongPath, EndOfPathInstruction.Stop), 0.1f);

        Vector3 rotation = pathCreator.path.GetRotation(positionAlongPath).eulerAngles;
        rotation.y = 0;
        rotation.z = -rotation.x;
        transform.rotation = Quaternion.Euler(rotation);
    }

    //void OldMoveWithoutMomentum()
    //{
    //    float positionChange = 0f;
    //    if (positionAlongPath >= leftEdge && positionAlongPath <= rightEdge)
    //    {
    //        positionChange = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //    }


    //    if (positionChange == 0)
    //    {
    //        positionChange = positionAlongPath - Mathf.Lerp(positionAlongPath, 0.5f, kindOfGravity);
    //        positionAlongPath -= positionChange;
    //    }
    //    else
    //    {
    //        positionAlongPath += positionChange;
    //    }

    //    //transform.position = pathCreator.path.GetPointAtTime(positionAlongPath);
    //    transform.DOMove(pathCreator.path.GetPointAtTime(positionAlongPath, EndOfPathInstruction.Stop), 0.1f);

    //    Vector3 rotation = pathCreator.path.GetRotation(positionAlongPath).eulerAngles;
    //    rotation.y = 0;
    //    rotation.z = -rotation.x;
    //    transform.rotation = Quaternion.Euler(rotation);
    //}

    //void MoveSpurtsKeyDown()
    //{
    //    float xDirection = 0f;
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        xDirection = -1f;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        xDirection = 1f;
    //    }

    //    GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * spurtSpeed, 0f) * Time.deltaTime, ForceMode2D.Impulse);
    //}

    //void MoveSpurtsKeyUp()
    //{
    //    float xDirection = 0f;
    //    if (Input.GetKeyUp(KeyCode.A))
    //    {
    //        xDirection = -1f;
    //    } else if (Input.GetKeyUp(KeyCode.D))
    //    {
    //        xDirection = 1f;
    //    }

    //    GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * speed, 0f) * Time.deltaTime, ForceMode2D.Impulse);

    //}
}
