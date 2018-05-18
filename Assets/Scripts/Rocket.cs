using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
  private float _transitionTimer;

  private bool m_RocketLaunch;
  private Vector3 m_positionRocket;
  private Vector3 m_Destination;

  private AudioSource m_AudioSource;
  private AudioClip m_AudioClip;

  [SerializeField]
  private Transform m_Rocket;

  [SerializeField]
  private GameObject m_RocketObj;

  [SerializeField]
  private Transform m_Button;

  [SerializeField]
  private float m_flightHeight;

  [SerializeField]
  private float m_speed;

  // Use this for initialization
  void Start ()
  {
    m_AudioSource = GetComponent<AudioSource>();
    m_AudioClip = GetComponent<AudioClip>();

    m_RocketLaunch = false;
    m_positionRocket = m_Rocket.localPosition;

    m_Destination = m_positionRocket + new Vector3(0, m_flightHeight, 0);
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "RiskBall")
    {
      m_AudioSource.Play();
      Debug.Log(other.gameObject.name + ". BALL COLLIDE WITH ROCKET");
      m_RocketLaunch = true;
    }

  }

  IEnumerator TimeDelay()
  {
    yield return new WaitForSeconds(3.5f);
    Move();
  }

  IEnumerator TimeDelayMenu()
  {
    yield return new WaitForSeconds(20);
   SceneManager.LoadScene("Menu-Scene");
  }

  void Update ()
  {
		if(m_RocketLaunch)
    {
      StartCoroutine(TimeDelay());
      StartCoroutine(TimeDelayMenu());
    }
	}

  private void Move()
  {
    m_Rocket.localPosition = Vector3.MoveTowards(m_Rocket.localPosition, m_Destination, m_speed * Time.deltaTime);    
  }
}
