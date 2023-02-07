using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    int roomSize = 2;
    const float moveTime = 0.175f;

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
        switch (key)
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
        Vector3 newPositon = this.transform.position + (mvmt * roomSize);
        StartCoroutine(MovementSmoothing(transform.position, newPositon));
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    IEnumerator MovementSmoothing(Vector3 curPos, Vector3 newPos)
    {
        float elapsedTime = 0f;
        while(elapsedTime < moveTime)
        {
            this.transform.position = Vector3.Lerp(curPos, newPos, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
