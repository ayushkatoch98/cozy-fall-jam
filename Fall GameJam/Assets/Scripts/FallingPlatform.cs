using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    [Space]
    [SerializeField] private float fallAfter;
    [SerializeField] private float destroyAfter;
    [SerializeField] private float respawnAfter;
    [Space]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;
    
    private bool startShaking;
    private float timer;

    private Vector3 tempPos;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;
        tempPos = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 gravity = Vector3.down * fallSpeed;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(fallAfter);
        rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(destroyAfter);
        gameObject.SetActive(false);
        //yield return new WaitForSeconds(respawnAfter);
        //Respawn()
    }

    private void Respawn()
    {
        //gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartFalling());
        }
    }
}
