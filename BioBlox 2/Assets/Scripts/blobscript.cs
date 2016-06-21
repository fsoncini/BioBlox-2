using UnityEngine;
using System.Collections;

public class blobscript : MonoBehaviour {

    public GameObject springsObject;
    public springs springScript;
    blobscript OtherBlob;

    public bool collided;

    GameObject thisItem;

    void Start() {

        collided = false;

        thisItem = this.gameObject;
        springsObject = GameObject.FindGameObjectWithTag("spring");
        springScript = springsObject.GetComponent<springs>();

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
        transform.rotation = Quaternion.identity;
    }

    void OnMouseDown() {

        //transform.Rotate(0,0,45);
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.name != "BottomWall" && coll.gameObject.name != "LeftWall" && !collided)
        {
            
            springScript.balls.Add(thisItem);
            collided = true;

            OtherBlob = coll.gameObject.GetComponent<blobscript>();
            if (!OtherBlob.collided)
            {
                springScript.balls.Add(coll.gameObject);
                OtherBlob.collided = true;

            }

            
        }
    }
}
