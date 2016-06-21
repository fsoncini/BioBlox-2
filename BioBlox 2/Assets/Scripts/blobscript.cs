using UnityEngine;
using System.Collections;

public class blobscript : MonoBehaviour {

    springs springScript;
    blobscript OtherBlob;
    Spawner _Spawner;
    public bool collided;

    float natLength;

    GameObject thisItem;

    void Start() {

        collided = false;
        natLength = 0.3f;

        thisItem = this.gameObject;
        springScript = GameObject.FindGameObjectWithTag("spring").GetComponent<springs>();
        _Spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();

    }

    void OnMouseDrag() {
        // calculate the mouse position in world space.
        float camera_distance = 10;
        Vector2 mp = Input.mousePosition;
        Camera cam = GameObject.FindObjectOfType<Camera>();
        Vector3 mouse_pos = cam.ScreenToWorldPoint(new Vector3(mp.x, mp.y, camera_distance));
        Vector3 delta = mouse_pos - transform.position;

        // move the blob towards the mouse.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
       // float spring_constant = 1;
       // rb.AddForce(new Vector2(delta.x * spring_constant, delta.y * spring_constant));

        transform.position = mouse_pos;
        transform.rotation = Quaternion.identity; //Check this
    }

    void OnMouseDown() {

        //transform.Rotate(0,0,45); //Improve this
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.name != "BottomWall" && coll.gameObject.name != "LeftWall" && !collided)
        {

            natLength = (coll.transform.position - this.transform.position).magnitude;

            springScript.balls.Add(thisItem);
            collided = true;

            for (int i = 0; i < _Spawner.numSpawnItems - 1; ++i)
            {
                springScript.natural_length.Add(natLength); //Modify this (not precise)
            }

            //OtherBlob = coll.gameObject.GetComponent<blobscript>();
            //if (!OtherBlob.collided)
            //{
            //    springScript.balls.Add(coll.gameObject);
            //    springScript.natural_length.Add(natLength); //Modify this (not precise)
            //    OtherBlob.collided = true;

            //} 
        }
    }
}
