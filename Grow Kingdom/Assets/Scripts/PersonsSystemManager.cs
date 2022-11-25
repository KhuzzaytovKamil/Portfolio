using UnityEngine;
using System;

public class PersonsSystemManager : MonoBehaviour
{
    public int LastTakenPersonNumber;
    public GameObject[] PersonsPositionPoint;
    public static event Action UpdatePersonsSystem;

    public void UpdatePersonsPositions() => UpdatePersonsSystem.Invoke();
}
