using System.Collections.Generic;
using UnityEngine;

public class raytracing : MonoBehaviour
{
    public bool Rotation = false;
    public float viewRadius  = 5;
    public float viewAngle  = 5;
    Collider2D[] playerInRadius;
    [SerializeField] LayerMask obstacleMask, playerMask;
    private LayerMask target;
    GameObject objTarget;
    public float speed = 10;
    public List<Transform> visiblePlayer = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Rotation == true) {
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void FixedUpdate() 
    {
       FindVisiblePlayer();
    }
    void FindVisiblePlayer()
    {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        for (int i = 0; i < playerInRadius.Length; i++)
        {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);
                if (!Physics2D.Raycast(transform.position, dirPlayer, distancePlayer, obstacleMask) && player != transform)
                {
                    objTarget = player.gameObject;
                    // take the LayerMask and convert it, in int for compare with layer
                    int layer = (int) Mathf.Log(playerMask.value, 2);
                    if (objTarget.layer == layer) {
                    /*draw the line when contact with other player*/
                        Debug.DrawLine(transform.position, player.position, Color.white, 0);
                        if (!visiblePlayer.Contains(player))
                            visiblePlayer.Add(player);
                    }
                }
            }
        }
    }
}