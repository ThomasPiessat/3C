using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    void PickUp();
    void Drop();
    void Select(int _index);
}
