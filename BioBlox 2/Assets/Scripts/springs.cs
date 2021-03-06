﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class springs : MonoBehaviour {
    public List<GameObject> balls;
    public List<float> natural_length;
    public float spring_constant;
    public float damping_constant;

    void Start() {
        //establishing relationship between one ball and all the others
        for (int i = 0; i < balls.Count; ++i) {
            for (int j = i+1; j < balls.Count; ++j) {
                Rigidbody2D rb1 = balls[i].GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = balls[j].GetComponent<Rigidbody2D>();
                float d = (rb1.transform.position - rb2.transform.position).magnitude;
                natural_length.Add(d);
            }
        }
    }

    //good link to brush up on vector operations
    //http://www.3dgep.com/3d-math-primer-for-game-programmers-vector-operations


    void FixedUpdate() {
        int nli = 0;
        for (int i = 0; i < balls.Count; ++i) {
            for (int j = i+1; j < balls.Count; ++j) {
                Rigidbody2D rb1 = balls[i].GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = balls[j].GetComponent<Rigidbody2D>();
                //float deltav = (rb1.velocity - rb2.velocity).magnitude;
                Vector3 delta = rb1.transform.position - rb2.transform.position; //getting the distance bt two points
                Vector3 dir = delta.normalized; //getting the direction of the vector
                float d = delta.magnitude; //getting the length (or norm) or the vector 
                float f = (d - natural_length[nli++]) * spring_constant;
                rb1.AddForce(new Vector2(-f * dir.x, -f * dir.y));
                rb2.AddForce(new Vector2(f * dir.x, f * dir.y));
            }
        }
    }
}
