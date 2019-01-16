using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //vector3 currentposition = this.transform.position;
        //float xpos = currentposition.x + 1 * time.deltatime;
        //float ypos = currentposition.y;
        //this.transform.position = new vector2(xpos, ypos);

        this.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
}
