using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float _jumpMultiplier;

    public float JumpMultiplier => _jumpMultiplier;
}
