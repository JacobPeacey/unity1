using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlaySoundOnCollison : MonoBehaviour

{
    //VARIABLE TO STORE AUDIO SOURCE

void OnCollisionEnter(Collision collision)
{
 GetComponent<AudioSource>().Play();
}

}