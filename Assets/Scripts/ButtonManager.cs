using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
  public void GoButton(string _level)
  {
    //Debug.Log("BUTTON PRESS");
    SceneManager.LoadScene("Main-Scene");
  }
  public void ExitButton()
  {
    Application.Quit();
  }
}
