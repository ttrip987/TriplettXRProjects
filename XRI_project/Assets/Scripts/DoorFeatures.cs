using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DoorFeatures : CoreFeatures
{
    [Header("Door Configurations")]
    [SerializeField]
    private Transform doorPivot;

    [SerializeField]
    private float maxAngle = 90.0f;

    [SerializeField]
    private float doorSpeed = 1.0f;

    [SerializeField]
    private bool reverseAngleDirection = false;

    [SerializeField]
    private bool doorOpen = false;

    [SerializeField]
    private bool MakeKinnematicOnOpen = false;

    [Header("Interactions")]

    [SerializeField]
    private XRSocketInteractor socketInteractor;

    [SerializeField]
    private XRSimpleInteractable simpleInteract;

    private void Start()
    {
        socketInteractor?.selectEntered.AddListener((s) =>
        {
            OpenDoor();
            PlayOnStart();
        });

        socketInteractor?.selectExited.AddListener((s) =>
        {
            PlayOnEnd();
            socketInteractor.socketActive = featureUsage == FeatureUsage.Once ? false : true;
        });

        simpleInteract?.selectEntered.AddListener((s) =>
        {
            OpenDoor();
        });

       

    }

    public void OpenDoor()
    {
        if (!doorOpen)
        {
            PlayOnStart();
            doorOpen = true;
            StartCoroutine(ProcessMotion());

        }
    }

    private IEnumerator ProcessMotion()
    {
        while(doorOpen)
        {
            var angle = doorPivot.localEulerAngles.y < 180 ? doorPivot.localEulerAngles.y : doorPivot.localEulerAngles.y - 360;
            angle = reverseAngleDirection ? Mathf.Abs(angle) : angle;

            if(angle <= maxAngle)
            {
                doorPivot?.Rotate(Vector3.up, doorSpeed * Time.deltaTime * (reverseAngleDirection ? -1 : 1));
            }

            else
            {
                doorOpen = false;
                var featureRigidBody = GetComponent<Rigidbody>();
                if (featureRigidBody != null && MakeKinnematicOnOpen) featureRigidBody.isKinematic = true;
            }

            yield return null;
        }
    }
}
