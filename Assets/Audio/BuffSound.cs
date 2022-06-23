using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSound : MonoBehaviour
{
    public AudioSource buffSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuffingSound()
    {
        buffSound.Play();
    }
}
