using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class spawnOnPlanes : MonoBehaviour
{
    [SerializeField] 
    GameObject placedPrefab;

    GameObject spawnObject;

    // list to store all hits from phone to trackables
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    ARRaycastManager m_raycastmanager;

void Awake()
    {
        m_raycastmanager = GetComponent<ARRaycastManager>();
    }
    
bool GetTouch(out Vector2 touch_pos)
    {
        if (Input.touchCount > 0)
        {
            touch_pos = Input.GetTouch(0).position;
            return true;
        }
        touch_pos = default;
        return false;
    }
void Update()
    {
    if (GetTouch(out Vector2 touch_pos) == false){
            return;
        }  
    // run this part if there has been a touch on the screen, send a raycast
    if (m_raycastmanager.Raycast(touch_pos, hits, TrackableType.Planes)){
            // get the first/closest hit
            var hitPose = hits[0].pose;

            // if we do not have a spawned object, lets spawn one
            if (spawnObject == null)
            {
                spawnObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }

            // if we do have an already spawned object, lets reposition it
            else
            {
                spawnObject.transform.position = hitPose.position;
            }
            
        }
    }
}
