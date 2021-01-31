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

    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Get the value of the Horizontal input axis.
        float horizontalInput = 0;
        float verticalInput = 0;
        float moving = 0;
        //Get the value of the Vertical input axis.
        if (Input.GetKey(up))
        {
            verticalInput = 1.0f;
        }
        else if (Input.GetKey(down))
        {
            verticalInput = -1.0f;
        }
        //Get the value of the Horizontal input axis.
        if (Input.GetKey(left))
        {
            horizontalInput = -1.0f;
        }
        else if (Input.GetKey(right))
        {
            horizontalInput = 1.0f;
        }

        moving = Mathf.Abs(-verticalInput) * moveSpeed * Time.deltaTime;
        time += Time.deltaTime;
        transform.Translate(new Vector3(0, -verticalInput, 0) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -horizontalInput) * rotateSpeed * Time.deltaTime);
        animator.SetFloat("Moving", moving);
        Debug.Log(moving + "--:--" + time);
        if (moving > 0 && time > sound_timing)
        {
            walk_sound.Play();
            time = 0;
        }
    }
}
