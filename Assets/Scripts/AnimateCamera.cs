// THIS CODE IS BASED ON THE WORK PROVIDED AS AN EXAMPLE BY A BOURNEMOUTH UNIVERSITY LECTURER

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CameraPositionTarget
{
  public Transform m_CamPosition;
  public Transform m_CamFocus;

  public Vector3 m_MoveDirection()
  {
    return (m_CamFocus.position - m_CamPosition.position).normalized;
  }
}

public class AnimateCamera : MonoBehaviour
{
  // CAMERA POSITIONS AND FOCUS POINTS
  public List<CameraPositionTarget> CameraPlaces;

  // MOVEMENT TIME BETWEEN CAMERA POSITIONS
  public float MovementDuration = 1.0f;

  // MOVEMENT TIMER
  private float m_MoveTimer;

  // IS CAMERA MOVING?
  private bool m_isMoving = false;

  // CAMERA POSITIONS FROM INDEX
  private int m_CurrentIndex = 0;
  private int m_PreviousIndex = 0;

  void Start()
  {
    //Debug.Assert(CameraPlaces.Count > 0);

    // SET CAMERA POSITION AND FOCUS TO INDEX 0 (FIRST POSITION)
    transform.position = CameraPlaces[0].m_CamPosition.position;
    transform.LookAt(CameraPlaces[0].m_CamFocus.position);

    // SET MOVEMENT TIMER
    m_MoveTimer = MovementDuration;
  }

  void Update()
  {
    //Debug.Assert(CameraPlaces.Count > 0);

    // IF THE CAMERA 'US MOVING'
    if (m_isMoving)
    {
      // COUNTDOWN MOVEMENT TIMER
      m_MoveTimer -= Time.deltaTime;

      var curr = getPrevTarget();
      var next = getCurrentTarget();

      float t = 1.0f - (m_MoveTimer / MovementDuration);

      // SMOOTH TRANSITION FROM CURRENT POSITION TO NEXT POSITION
      transform.position = smoothstepVec3(curr.m_CamPosition.position, next.m_CamPosition.position, t);
      transform.rotation = Quaternion.LookRotation(smoothstepVec3(curr.m_MoveDirection(), next.m_MoveDirection(), t));

      // STOP MOVING CAMERA, RESET TIMER ATTRIBUTES
      if (m_MoveTimer < 0.0f)
      {
        m_isMoving = false;
        m_MoveTimer = MovementDuration;
      }
    }
    else
    {
      var focus = getCurrentTarget();
      transform.position = focus.m_CamPosition.position;
      transform.LookAt(focus.m_CamFocus);
    }
  }

  CameraPositionTarget getCurrentTarget()
  {
    return CameraPlaces[m_CurrentIndex];
  }

  CameraPositionTarget getPrevTarget()
  {
    return CameraPlaces[m_PreviousIndex];
  }

  // INTERPOLATE BETWEEN TWO VECTORS (USING SMOOTHSTEP CURVE)
  Vector3 smoothstepVec3(Vector3 a, Vector3 b, float t)
  {
    t = Mathf.Clamp01(t);
    return new Vector3(Mathf.SmoothStep(a.x, b.x, t), Mathf.SmoothStep(a.y, b.y, t), Mathf.SmoothStep(a.z, b.z, t));
  }

  public void goToNextTarget()
  {
    m_PreviousIndex = m_CurrentIndex;
    m_CurrentIndex = (m_CurrentIndex + 1) % CameraPlaces.Count;
    m_isMoving = true;
    m_MoveTimer = MovementDuration;
  }
}
