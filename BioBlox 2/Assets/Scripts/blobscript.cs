using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blobscript : MonoBehaviour {

   private bool isBall = true;
    //private bool isBrick;

    //private GameObject s = GameObject.Find("springs");
  

    void OnMouseDrag() {
        // calculate the mouse position in world space.
        float camera_distance = 10;
        Vector2 mp = Input.mousePosition;
        Camera cam = GameObject.FindObjectOfType<Camera>();
        Vector3 mouse_pos = cam.ScreenToWorldPoint(new Vector3(mp.x, mp.y, camera_distance));
        Vector3 delta = mouse_pos - transform.position;
        //isBall = (this.tag == "ball");
        //isBrick = (this.tag == "brick");

        // move the blob towards the mouse.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float spring_constant = 50;
        rb.AddForce(new Vector2(delta.x * spring_constant, delta.y * spring_constant));
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        this.gameObject.tag = "ball";
        //if (isBall)
        //{
        //    //Debug.Log("BALL COLLISION DETECTED");
        //}

        //if (isBrick)
        //{
        //    Debug.Log("BRICK COLLISION DETECTED");
        //}

        if (coll.gameObject.tag == "ball" && isBall)
        {
            isBall = false;
            Debug.Log("Docking Collision Detected");
            //makes clones children of Docks object
            GameObject.FindGameObjectWithTag("ball").transform.parent = GameObject.Find("Docks").transform;
            this.transform.parent = GameObject.Find("Docks").transform;
            GameObject.Find("Docks").GetComponent<Docks>().CountChildren();    
        }

        //if (coll.gameObject.tag == "brick")
        //{
        //    Debug.Log("Docking Collision Detected");
        //    //makes clones children of Docks object
        //    GameObject.FindGameObjectWithTag("ball").transform.parent = GameObject.Find("Docks").transform;
        //    GameObject.Find("Docks").GetComponent<Docks>().CountChildren();
        //}
        
    }
    
}