using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticlePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem jumpStart;
    public ParticleSystem jumpEnd;
    public ParticleSystem run;

    public AudioClip jumpLandSound;
    public AudioClip runningSound;

    private FirstPersonController controller;

    bool previousState;
    bool isGrounded;

    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;

    void Start()
    {

        controller = GetComponent<FirstPersonController>();
        previousState = controller.getIsGrounded();
        isGrounded = controller.getIsGrounded();

        cameraAudioSource = Camera.main.GetComponent<AudioSource>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadScene();
        previousState = isGrounded;
        isGrounded = controller.getIsGrounded();

        if (controller.getIsSpriting() && isGrounded)
        {
            run.Play();
            playerAudioSource.Play();
        }
        else
        {
            run.Stop();
            playerAudioSource.Stop();
        }


        if (previousState == isGrounded) return;

        // state have changed

        if (isGrounded)
        {
            jumpEnd.Play();
            playerAudioSource.PlayOneShot(jumpLandSound);
        }

        else if (isGrounded == false)
        {
            jumpStart.Play();
            playerAudioSource.PlayOneShot(jumpLandSound);
        }

        

    }


    private void reloadScene()
    {
        if (transform.position.y <= -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        }
    }
}
