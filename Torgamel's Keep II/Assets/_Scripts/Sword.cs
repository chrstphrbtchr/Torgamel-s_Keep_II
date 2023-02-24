using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    PlayerControls controls;
    public enum SwordState
    {
        None,
        Attacking,
        Parrying,
        Disabled
    }

    public SwordState state = SwordState.None;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.SwordMechanics.performed += ctx => SwordUsed(ctx.control.name);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    SwordState GetSwordState() => this.state;
    void SetSwordState(SwordState newState) => this.state = newState;

    void SwordUsed(string keyUsed)
    {
        switch(keyUsed)
        {
            case "leftButton":
                Attack();
                break;
            case "rightButton":
                Parry();
                break;
            default:
                Debug.LogError("Unknown key used in SwordUsed in Sword.cs");
                break;
        }
    }

    void Attack()
    {
        SetSwordState(SwordState.Attacking);
        // raycast 
    }

    void Parry()
    {
        SetSwordState(SwordState.Parrying);
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
