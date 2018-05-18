using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
		
	}

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Ball")
    {
      Destroy(other.gameObject);
    }
  }

  // Update is called once per frame
  void Update ()
  {
		
	}
}
