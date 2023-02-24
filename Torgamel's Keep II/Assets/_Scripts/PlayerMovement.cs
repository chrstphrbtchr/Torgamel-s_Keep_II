using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    int roomSize = 2;
    private bool moving;
    const float moveTime = 0.175f;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.PlayerMovement.performed += ctx => Movement(ctx.control.name);
        controls.Player.PlayerRotation.performed += ctx => Turning(
            (ctx.control.name == "q") ? true : false);
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
        if (!moving)
        {
            moving = true;
            Vector3 mvmt = Vector3.zero;
            switch (key)
            {
                case "w":
                case "upArrow":
                    mvmt = transform.forward;
                    break;
                case "s":
                case "downArrow":
                    mvmt = transform.forward * -1;
                    break;
                case "a":
                case "leftArrow":
                    mvmt = transform.right * -1;
                    break;
                case "d":
                case "rightArrow":
                    mvmt = transform.right;
                    break;
                default:
                    break;
            }
            Vector3 newPositon = this.transform.position + (mvmt * roomSize);
            StartCoroutine(MovementSmoothing(transform.position, newPositon));
        }
    }

    void Turning(bool left)
    {
        if (!moving)
        {
            moving = true;
            StartCoroutine(TurnSmoothing(left));
        }
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
            elapsedTime += Time.deltaTime;
            this.transform.position = Vector3.Lerp(curPos, newPos, elapsedTime / moveTime);
            yield return null;
        }
        moving = false;
        yield return null;
    }

    IEnumerator TurnSmoothing(bool left)
    {
        float elapsedTime = 0f;
        Quaternion curRot = transform.rotation;
        Quaternion newRot = curRot * Quaternion.Euler(0, (left ? -1 : 1) * 90, 0);
        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            this.transform.rotation = Quaternion.Slerp(curRot, newRot, elapsedTime / moveTime);
            yield return null;
        }
        moving = false;
        yield return null;
    }
}
