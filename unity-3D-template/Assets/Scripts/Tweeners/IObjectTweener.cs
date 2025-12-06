using System;
using UnityEngine;

public interface IObjectTweener 
{
    internal void MoveTo(Transform transform, Vector3 targetPosition);  
}
