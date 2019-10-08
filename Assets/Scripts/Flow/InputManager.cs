using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : IManager
{
    public InputPkg physicsInputPkg = new InputPkg();
    public InputPkg UpdateInputPkg = new InputPkg();
    #region Singleton
    private static InputManager instance;
    private InputManager() { }
    public static InputManager Instance
    {
        get
        {
            return (instance == null) ? instance = new InputManager() : instance;
        }
    }
    #endregion
    public void FirstInitialization()
    {
        
    }
    private void SetInputPkg(InputPkg ip)
    {
        ip.fire = Input.GetButton("Jump");
        ip.dirPressed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
    public void PhysicsRefresh()
    {
        SetInputPkg(physicsInputPkg);
    }

    public void Refresh()
    {
        SetInputPkg(UpdateInputPkg);
    }

    public void SecondInitialization()
    {
        
    }
    public class InputPkg
    {
        public Vector2 dirPressed;
        public bool fire;
    }
    
}
