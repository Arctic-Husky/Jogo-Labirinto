using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObject;

    public float speed = 5f;

    public Vector3 originalPosition = new Vector3(0,0,0);

    private CharacterController characterController;

    private int layerMask;

    private Vector3 left = new Vector3(0,0,1);
    private Vector3 right = new Vector3(0,0,-1);
    private Vector3 forward = new Vector3(1, 0, 0);
    private Vector3 back = new Vector3(-1, 0, 0);
    private Vector3 forward_left = new Vector3(1, 0, 1);
    private Vector3 forward_right = new Vector3(1, 0, -1);
    private Vector3 back_left = new Vector3(-1, 0, 1);
    private Vector3 back_right = new Vector3(-1, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        layerMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement.Normalize();

        characterController.Move(movement * speed * Time.deltaTime);

        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        Debug.Log(rayDirection);
        Debug.Log(transform.right);
        float rayDistance = 2f;

        bool hit = Physics.Raycast(rayOrigin, forward, rayDistance, layerMask);
        bool hit2 = Physics.Raycast(rayOrigin, right, rayDistance, layerMask);
        bool hit3 = Physics.Raycast(rayOrigin, left, rayDistance, layerMask);
        bool hit4 = Physics.Raycast(rayOrigin, back, rayDistance, layerMask);
        bool hit5 = Physics.Raycast(rayOrigin, forward_left, rayDistance, layerMask);
        bool hit6 = Physics.Raycast(rayOrigin, forward_right, rayDistance, layerMask);
        bool hit7 = Physics.Raycast(rayOrigin, back_left, rayDistance, layerMask);
        bool hit8 = Physics.Raycast(rayOrigin, back_right, rayDistance, layerMask);

        Debug.DrawRay(rayOrigin, forward * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, right * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, left * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, back * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, forward_left * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, forward_right * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, back_left * rayDistance, Color.red);
        Debug.DrawRay(rayOrigin, back_right * rayDistance, Color.red);

        /*Debug.Log(hit);
        Debug.Log(hit2);
        Debug.Log(hit3);
        Debug.Log(hit4);
        Debug.Log(hit5);
        Debug.Log(hit6);
        Debug.Log(hit7);
        Debug.Log(hit8);*/

        if (hit || hit2 || hit3 || hit4 || hit5 || hit6 || hit7 || hit8)
        {
            Debug.Log("ENTROU NO IF");
            transform.position = Vector3.zero;
        }

        
    }
}
