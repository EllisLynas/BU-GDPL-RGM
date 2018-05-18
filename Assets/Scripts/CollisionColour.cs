using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColour : MonoBehaviour
{
  public Material[] material;
  Renderer rend;
  AudioSource Audio_Source;
  AudioClip Buzzer;

  void Start()
  {
    rend = GetComponent<Renderer>();
    rend.enabled = true;
    rend.sharedMaterial = material[0];

    Audio_Source = GetComponent<AudioSource>();
    Buzzer = GetComponent<AudioClip>();
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Domino" || col.gameObject.tag == "Ball")
    {
      //Debug.Log("CONTACT");
      rend.sharedMaterial = material[1];
      //Audio_Source.Play();  // AUDIO
      //Debug.Log("AUDIO");
      //GetComponent<AudioSource>().Play();  // AUDIO
      StartCoroutine(TimeDelay());
      //rend.sharedMaterial = material[0];
      //col.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }
  }
  
  IEnumerator TimeDelay()
  {
    yield return new WaitForSeconds(1);
    rend.sharedMaterial = material[0];
  }
  
  // Update is called once per frame
  void Update ()
  {
  }
}
