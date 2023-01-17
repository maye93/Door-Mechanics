using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    // Timer Countdown
    [SerializeField] public TextMeshProUGUI uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    // Door Interaction
    private Animator anim;
    private bool doorOpen = false;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount= false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            LoseGame();
        }
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            anim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;

            // Reset Timer
            timer = mainTimer;
            canCount = true;
            doOnce = false;
        }
        else
        {
            anim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }

    void LoseGame()
    {
        SceneManager.LoadScene("LoseScene");
    }

    void WinGame()
    {
        SceneManager.LoadScene("LoseScene");
    }

    void OnT()
    {

    }
}
