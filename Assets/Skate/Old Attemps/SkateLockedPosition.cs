using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SkateLockedPosition : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // graph factor
    float a = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        // GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * xDirection, 0f));
        // v = (pf - pi) / t
        // f = m a
        // f = m v / t
        // f = m ((pf-pi) / t) / t
        // f = m (pf - pi) / t^2
        
        // do kind of the same but based on velocity or better yet  force
        //  then player  can accelerate up the thing
        //  and also.. player can push like they do with their foot, but yeah that's it really

        Vector3 position = transform.position;
        position.x += xDirection * speed * Time.deltaTime;
        position.y = YOnShape(position.x);
        transform.DOMove(position, 2);
        //transform.position = position;


        transform.up = new Vector3(0, 10, 0) - transform.position;
    }


    float YOnShape(float x) {
        return a * Mathf.Pow(x, 2);
    }

    Vector3 Focus() {
        return new Vector3(0, 1f / (4f * a), 0);
    }
}
