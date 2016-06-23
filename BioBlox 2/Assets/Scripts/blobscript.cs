using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blobscript : MonoBehaviour {
    
    public bool collided;


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
  
        if (coll.gameObject.tag == "ball" && !collided) 
        { 
            Debug.Log("Docking Collision Detected");


            //trying to find parent with tag instead of name.
            GameObject.FindGameObjectWithTag("ball").transform.parent = GameObject.FindGameObjectWithTag("dock").transform;
            this.transform.parent = GameObject.FindGameObjectWithTag("dock").transform;
            GameObject.FindGameObjectWithTag("dock").GetComponent<Docks>().CountChildren();


            //makes clones children of Docks object
            //GameObject.Find("Blob(Clone)").transform.parent = GameObject.Find("Docks").transform;
            //this.transform.parent = GameObject.Find("Docks").transform;
            //calls CountChildren() function in Docks script
            //GameObject.Find("Docks").GetComponent<Docks>().CountChildren();

            collided = true;
            //gameObject.layer = 0;
                          
        }

        //if (coll.gameObject.tag == "new" && !collided)
        //{
        //    Debug.Log("Docking Collision Detected");
            
        //    //trying to find parent with tag instead of name.
        //    GameObject.FindGameObjectWithTag("new").transform.parent = GameObject.FindGameObjectWithTag("dock").transform;
        //    this.transform.parent = GameObject.FindGameObjectWithTag("dock").transform;
        //    GameObject.FindGameObjectWithTag("dock").GetComponent<Docks>().CountChildren();
            

        //    collided = true;
        //    //gameObject.layer = 0;

        //}



        //if (coll.gameObject.layer == 2 && !collided)
        //{
        //    Debug.Log("Docking Collision Detected");

        //    //makes clones children of Docks object


        //    GameObject.Find("Brick(Clone)").transform.parent = GameObject.Find("Docks").transform;
        //    this.transform.parent = GameObject.Find("Docks").transform;

        //    //calls CountChildren() function in Docks script
        //    GameObject.Find("Docks").GetComponent<Docks>().CountChildren();

        //    collided = true;
        //    gameObject.layer = 0;

        //}

    }

}