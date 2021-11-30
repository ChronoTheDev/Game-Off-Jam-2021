using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiSensor : MonoBehaviour
{
    public UnityEvent OnPlayerSeen;
    [field: SerializeField]
    public bool playerDetected {get; private set;}


    [Header("Overlap parameters")]
    [SerializeField]
    public float detectionRad;

    public float detectionDelay = 0.3f;
    public LayerMask detectorLayerMask;

    [Header("Gizmo Parameters")]
    public Color gizmoIdleColour = Color.green;
    public Color gizmoDetectedColour = Color.red;
    public bool showGizmos = true;

    private GameObject target;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            playerDetected = target != null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, detectionRad, detectorLayerMask);
        playerDetected = collider != null;
        if(playerDetected)
        {
            OnPlayerSeen?.Invoke();
        }
    }

   

    void OnDrawGizmos() 
    {
        if(showGizmos )
        {
            Gizmos.color = gizmoIdleColour;
            if(playerDetected)
            {
                Gizmos.color = gizmoDetectedColour;
            }
            Gizmos.DrawWireSphere(transform.position, detectionRad);
        }
    }
}
