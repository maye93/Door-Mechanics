using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorLose"))
        {
            SceneManager.LoadScene(1);
        }
        else if (other.gameObject.CompareTag("DoorWin"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
