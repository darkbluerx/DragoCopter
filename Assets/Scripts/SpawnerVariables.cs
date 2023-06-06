using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerVariables", menuName = "ScriptableObjects/SpawnerVariables", order = 1)]
public class SpawnerVariables : ScriptableObject
{
    [Header("Timer for walls")]
    public float maxTime;
    [Space]

    public float roofWallHeight;
    public float floorWallHeight;
    [Space]

    [Header("The height of the upper barrier")]
    public float minUpperHeight;
    public float maxUpperHeight;
    [Space]

    [Header("Middle obstacle height")]
    public float midHeight;
    [Space]

    [Header("The height of the lower barrier")]
    public float minLowerHeight;
    public float maxLowerHeight;
    [Space]

    [Header("Timer for obstacles")]
    public float obstaclesTimer;
}
