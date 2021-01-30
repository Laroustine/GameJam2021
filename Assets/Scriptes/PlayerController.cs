using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 150;
    public float rotateSpeed = 100;
    public Animator animator;
    public AudioSource walk_sound;
    private float time = 0.0f;
    public float sound_timing = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Get the value of the Horizontal input axis.
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Vertical input axis.
        float verticalInput = Input.GetAxis("Vertical");
        float moving = Mathf.Abs(-verticalInput) * moveSpeed * Time.deltaTime;

        time += Time.deltaTime;
        transform.Translate(new Vector3(0, -verticalInput, 0) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -horizontalInput) * rotateSpeed * Time.deltaTime);
        animator.SetFloat("Moving", moving);
        if (moving > 0 && time > sound_timing) {
            walk_sound.Play();
            time = 0;
        }
    }
}
