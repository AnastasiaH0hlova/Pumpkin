using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PumpkinController : MonoBehaviour
{

    public float speed = 3f;

    public bool isHavePhone = false;

    Rigidbody2D rigidbody2d;

    //Animator animator;

    public static bool LockMovement = false;
    
    public Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!LockMovement)
        {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //����������� ��������
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animator.SetFloat("Move X", lookDirection.x);
        //animator.SetFloat("Move Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        //��������
        rigidbody2d.velocity = new Vector2(horizontal * 10f, vertical * 10f);

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                if(hit.transform.GetComponent<InstantiateDialogue>())
                {
                    hit.transform.GetComponent<InstantiateDialogue>().ShowDialogue = true;
                    LockMovement = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Door"));
            if (hit.collider != null && isHavePhone)
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Phone"));
            if (hit.collider != null)
            {
            
                 Destroy(hit.transform.gameObject);
                 isHavePhone = true;
            }
        }



        }
    }
}
