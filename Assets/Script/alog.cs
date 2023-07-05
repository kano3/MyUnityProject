using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("function Start()");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("function Update()");
    }

    void FixedUpdate()
    {
        Debug.Log("function FixedUpdate()");
        Update();
    }
}
