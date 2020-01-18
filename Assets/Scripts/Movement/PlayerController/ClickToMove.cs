using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public GameObject mouseMarker;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private GameObject currentMouseMarker;

    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // Handles setting location and moving character
    void MoveCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.destination = hit.point;
                isMoving = true;
                SetMoveSpeed(1);
                DestroyMouseMarker();
                GenerateMouseMarker(hit.point);
            }
        }

        if (isMoving && navMeshAgent.destination == navMeshAgent.transform.position)
        {
            DestroyMouseMarker();
            isMoving = false;
            SetMoveSpeed(0);
        }
    }

    // sets the model's movement speed. Used to animate character
    void SetMoveSpeed(float speed)
    {
        animator.SetFloat("MoveSpeed", speed);
    }

    // Generates the destination marker on click
    void GenerateMouseMarker(Vector3 location)
    {
        location.y = location.y + 1f;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(90f, 0f, 0f);
        currentMouseMarker = Instantiate(mouseMarker, location, rotation) as GameObject;
    }

    void DestroyMouseMarker()
    {
        if (currentMouseMarker) Destroy(currentMouseMarker, 0f);
    }
}
