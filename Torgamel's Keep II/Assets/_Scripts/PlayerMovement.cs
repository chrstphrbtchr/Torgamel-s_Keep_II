using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] int roomSize;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.PlayerMovement.performed += ctx => Movement(ctx.control.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(string key)
    {
        Vector3 mvmt = Vector3.zero;
        switch(key)
        {
            case "w":
            case "upArrow":
                mvmt = Vector3.forward;
                break;
            case "s":
            case "downArrow":
                mvmt = Vector3.back;
                break;
            case "a":
            case "leftArrow":
                mvmt = Vector3.left;
                break;
            case "d":
            case "rightArrow":
                mvmt = Vector3.right;
                break;
            default:
                break;
        }
        this.transform.position += (mvmt * roomSize);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
