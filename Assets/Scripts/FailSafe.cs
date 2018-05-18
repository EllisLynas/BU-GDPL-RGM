using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSafe : MonoBehaviour
{
  Vector3 m_NewObjPosition;
  private bool m_CupBall;

  [SerializeField]
  private Transform m_SelfObject;

  [SerializeField]
  private Transform m_DetectionObj;

  [SerializeField]
  private Transform m_NewPosition;

  void Start()
  {
    m_NewObjPosition = m_NewPosition.localPosition;
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.name == m_DetectionObj.name)
    {
      Debug.Log("COLLISION BETWEEN BALL AND FLOOR!");
      m_SelfObject.transform.position = m_NewObjPosition;
    }
  }
}
