using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audiosource;
        audiosource = GetComponent<AudioSource>();
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
