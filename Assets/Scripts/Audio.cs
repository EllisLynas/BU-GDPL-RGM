using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
  private AudioSource m_AudioSource;
  private AudioClip m_AudioClip;

  void Start ()
  {
    m_AudioSource = GetComponent<AudioSource>();
    m_AudioClip = GetComponent<AudioClip>();
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Ball")
    {
      m_AudioSource.Play();
    }
  }

  // Update is called once per frame
  void Update () {
		
	}
}
