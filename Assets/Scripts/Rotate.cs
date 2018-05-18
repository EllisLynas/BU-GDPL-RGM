using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

  [SerializeField]
  private float m_speed;

  [SerializeField]
  private bool m_Clockwise;

  // Use this for initialization
  void Start ()
  {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
    if (m_Clockwise)
    {
      transform.Rotate(Vector3.up * Time.deltaTime * m_speed);
    }
    else
    {
      transform.Rotate(Vector3.down * Time.deltaTime * m_speed);
    }
  }
}
