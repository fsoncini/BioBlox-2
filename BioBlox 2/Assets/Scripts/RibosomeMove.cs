using UnityEngine;
using System.Collections;

public class RibosomeMove : MonoBehaviour {

    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

	// Use this for initialization
	void Start () {

        transform.position = points[0].position;
        currentPoint = 0;

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= points.Length)
        {
            currentPoint = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

       

	}
}
