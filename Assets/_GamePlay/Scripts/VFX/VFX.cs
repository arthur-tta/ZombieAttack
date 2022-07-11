using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    private const float TIME_LIVE = 1f;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= TIME_LIVE)
        {
            Destroy(gameObject);
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
