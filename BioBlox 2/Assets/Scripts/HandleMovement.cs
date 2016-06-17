using UnityEngine;
using System.Collections;

public class HandleMovement : MonoBehaviour {

    public float velocity = 0.1f;

    private GameObject player;
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("brick"); //TODO
        //Destroy(player, 10);
    }


	// Update is called once per frame
	//adding deltatime makes movement independent of frame rate
    void Update () {


        if (Input.GetKey ("up")) {
            player.transform.Translate(0, velocity * Time.deltaTime, 0); 
        }
        if (Input.GetKey ("down"))
        {
            player.transform.Translate(0, -velocity * Time.deltaTime, 0);
        }
        if (Input.GetKey("right"))
        {
            player.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            player.transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }
      
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Instantiate(player);
    //}


}
