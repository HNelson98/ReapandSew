using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveShop : MonoBehaviour
{
    public void TransitionScene()
    {
        SceneManager.LoadScene("TownHub");
    }
}
