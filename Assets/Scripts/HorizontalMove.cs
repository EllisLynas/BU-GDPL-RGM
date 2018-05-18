using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

  private Vector3 m_positionA;
  private Vector3 m_positionB;
  private Vector3 m_nextPosition;

  [SerializeField]
  private Transform m_moveObject;

  [SerializeField]
  private float m_speed;

  [SerializeField]
  private float m_horizontalMovement;

  private bool m_Move;

  void Start()
  {
    m_Move = false;
    // GET START POSITION (A)
    m_positionA = m_moveObject.localPosition;

    // CALCULATE POSITION B
    m_positionB = m_positionA + new Vector3(m_horizontalMovement, 0, 0);

    m_nextPosition = m_positionB;
  }

  // Update is called once per frame
  void Update()
  {
    if(m_Move)
    {
      Move();
      //ChangeMovement();
    }
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Ball" || col.gameObject.tag == "RiskBall")
    {
      Debug.Log("PIPE-BALL CONTACT");
      StartCoroutine(TimeDelay());
    }
  }

  IEnumerator TimeDelay()
  {
    yield return new WaitForSeconds(1);
    m_Move = true;
  }


  private void Move()
  {
    m_moveObject.localPosition = Vector3.MoveTowards(m_moveObject.localPosition, m_nextPosition, m_speed * Time.deltaTime);
  }

  private void ChangeMovement()
  {
    if (m_moveObject.localPosition == m_positionA)
    {
      m_nextPosition = m_positionB;
    }
    else if (m_moveObject.localPosition == m_positionB)
    {
      m_nextPosition = m_positionA;
    }
  }
}