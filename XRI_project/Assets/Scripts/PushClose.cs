using UnityEngine;
using Oculus.Interaction;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PushClose : CoreFeatures
{

    [Header("Push")]
    [SerializeField]
    private Transform pushableObject;

    [SerializeField]
    private Grabbable grabbable;

    [SerializeField]
    private float snapDistance = 0.04f;

    private float closedZ;

    private Bounds bounds;

    private PokeInteractor[] fingers;

    private readonly Dictionary<PokeInteractor, bool> wasInFront = new Dictionary<PokeInteractor, bool>(); 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
