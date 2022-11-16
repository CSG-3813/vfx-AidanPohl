/*
 * Author Aidan pohl
 * Created: nOV 16, 2022
 * dESCRIPTION: sIGHTlINE hANDLER FOR npcS
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SightLine : MonoBehaviour
{  
    public Transform eyePoint;
    public string targetTag = "Player";
    public float fieldOfView = 45f;
    [SerializeField] bool isTargetInSight = false;
    public Vector3 lastKnownSighting { get; set; } = Vector3.zero;
    private SphereCollider sightBubble;


    private void Awake()
    {
        sightBubble = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {   
            Debug.Log("Something in Range");
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Player in Range");
            UpdateSight(other.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isTargetInSight = false;
        }
    }

    public void UpdateSight(Transform target)
    {
        isTargetInSight = ClearLineOfSight(target) && TargetInFOV(target) ;
        if (isTargetInSight)
        {
            Debug.Log("PlayerSighted");
            lastKnownSighting = target.position;
        }
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 directionToTarget = target.position - eyePoint.position;
        float angle = Vector3.Angle(eyePoint.forward,directionToTarget);
        if(angle <= fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//end TargetInFOV(Transform)

    private bool ClearLineOfSight(Transform target)
    {
        RaycastHit hit;
        Vector3 dirToTarget = (target.position - eyePoint.position).normalized;
        if (Physics.Raycast(eyePoint.position, dirToTarget, out hit, sightBubble.radius))
        {
            Debug.Log("Hit Something with tag " +hit.transform.tag);
            if (hit.transform.CompareTag(targetTag))
            {
                Debug.Log("TARGET FOUND!!");
                return true;
            }
        }
        return false;
    }
}
