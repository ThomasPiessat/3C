using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUp
{
    void PickUp();
    void Drop();
    void Select(int _index);
}
