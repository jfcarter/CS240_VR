using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToFollow : MonoBehaviour {

    public Transform[] path = new Transform[3];
    public float speed = 1.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    bool check = false;

	// Use this for initialization
	void Start () {
        //check = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
            Vector3 direction;
            direction = path[currentPoint].position - transform.position;

            transform.position += direction * Time.deltaTime * speed;

            if (direction.magnitude <= reachDist)
            {
                if (currentPoint < 2)
                    currentPoint++;
            }

            if (currentPoint >= path.Length)
            {
                check = false;
            }    
        */  
    }

    public void MoveChacter()
    {
        print("click");
        check = true;
    }
}
