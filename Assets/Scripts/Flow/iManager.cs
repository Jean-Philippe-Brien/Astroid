using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    // Start is called before the first frame update
    void FirstInitialization();
    //like start func
    void SecondInitialization();
    void Refresh();
    void PhysicsRefresh();
}
