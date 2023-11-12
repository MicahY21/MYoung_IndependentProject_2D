using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource FinishLine;

    private bool levelCompleted = false;

    private void Start()
    {
        FinishLine = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CoryGorrillaPlayer"  && !levelCompleted)
        {
            FinishLine.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
            
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
