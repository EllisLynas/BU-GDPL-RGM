using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAudio : MonoBehaviour {

  private AudioSource m_AudioSource;
  private AudioClip m_AudioClip;
  private int randomNum;

  // Use this for initialization
  void Start ()
  {
    m_AudioSource = GetComponent<AudioSource>();
    m_AudioClip = GetComponent<AudioClip>();
    //RandomDominoAudio();
    //string fileName = m_AudioClip.name.ToString();
    //Debug.Log("LOAD CLIP STATE: " + fileName);
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Domino" && gameObject.tag == "Domino")
    {
      //PlayAudio();

      //Debug.Log("DOMINO COLLISION");

      //m_AudioSource.PlayOneShot(m_AudioClip);
      m_AudioSource.Play();
    }
  }


  void PlayAudio()
  {
    
    
  }

  //void RandomDominoAudio()
  //{
   // randomNum = Random.Range(1, 5);
   // m_AudioClip = Resources.Load<AudioClip>("Audio/Dominos/Domino" + randomNum.ToString());
  //}

  // Update is called once per frame
  void Update ()
  {
		
	}
}
