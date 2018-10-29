using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour {
    
    bool isDestroyed = false;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.position.y < 50f && !isDestroyed)
        {
            //Debug.Log(ScoreManager.score);
            ScoreManager.score = ScoreManager.score + 1;
            Destroy(gameObject, 5);
            isDestroyed = true;
        }

    }
}
