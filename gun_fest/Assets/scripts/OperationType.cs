using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type_operation
{
    increase,
    decrease,
    multi,
    div,
    random
}
public class OperationType : MonoBehaviour
{
    public type_operation type;
    public int number;
    public bool active;
    public OperationType other_collider;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

}
