using UnityEngine;
using System.Collections;

public class blobscript : MonoBehaviour {

    springs springScript;
    blobscript OtherBlob;
    Spawner _Spawner;
    public bool collided;

    //float natLength;

    GameObject thisItem;

    void Start() {

        collided = false;
        //natLength = 0.3f;

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
        //transform.rotation = Quaternion.identity; //Check this
    }

    void OnMouseDown() {

        transform.Rotate(0,0,15); //Improve this
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.name != "BottomWall" && coll.gameObject.name != "LeftWall" && !collided)
        {

            springScript.balls.Add(thisItem);
            collided = true;


            //Calculate the relative distances between objects
            springScript.natural_length.Clear();

            for (int i = 0; i < springScript.balls.Count; ++i)
            {
                for (int j = i + 1; j < springScript.balls.Count; ++j)
                {
                    Rigidbody2D rb1 = springScript.balls[i].GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = springScript.balls[j].GetComponent<Rigidbody2D>();
                    float d = (rb1.transform.position - rb2.transform.position).magnitude;
                    springScript.natural_length.Add(d);
                }
            }

        }
    }
}
