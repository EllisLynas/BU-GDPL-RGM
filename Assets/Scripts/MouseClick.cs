using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
  // OBJECT OF ANIMATECAMERA CLASS
  public AnimateCamera m_AnimateCamera;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      // CAMERA TO NEXT POSITION ON CLICK
      m_AnimateCamera.goToNextTarget();
    }
  }
}
