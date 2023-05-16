using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopLoad : MonoBehaviour
{
    //private AudioSource enterDoorSound; (Add when creating sfx.)
    private Rigidbody2D rb;
    private PlayerMovement movement;

    private bool transitioning = false;
    [SerializeField] private string sceneToLoad = "SampleScene";
    
    // Start is called before the first frame update
    void Start()
    {
        //enterDoorSound = GetComponent<AudioSource>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !transitioning)
        {
            //enterDoorSound.Play();
            transitioning = true;
            rb.bodyType = RigidbodyType2D.Static;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            Invoke("TransitionScene", 1f);
        }
    }

    private void TransitionScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
