using UnityEngine;
using System.Collections;

public class blobscript : MonoBehaviour {

    //private bool isBall;
    //private bool isBrick;

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
        float spring_constant = 100;
        rb.AddForce(new Vector2(delta.x * spring_constant, delta.y * spring_constant));
    }


    //void OnCollisionEnter2D()
    //{
    //    if(isBall)
    //    {
    //        Debug.Log("BALL COLLISION DETECTED");
    //    }

    //    if (isBrick)
    //    {
    //        Debug.Log("BRICK COLLISION DETECTED");
    //    }

    //}


    void OnCircleCollisionEnter2D()
    {
   
            Debug.Log("BALL COLLISION DETECTED");
    
    }

    void OnBoxCollisionEnter2D()
    {
        
            Debug.Log("BRICK COLLISION DETECTED");
        
    }

}