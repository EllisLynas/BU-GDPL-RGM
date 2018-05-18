using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
  [SerializeField]
  private float m_MaxSpeed;

  void Start()
  {
    GetComponent<Rigidbody>().maxAngularVelocity = m_MaxSpeed;
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "BallDestroy" && gameObject.tag == "Ball")
    {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void Update()
  {
  }
}