using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public delegate void RayTouch(GameObject gameObject);
    public static event RayTouch OnRayTouch;
    
    public float maxRaycastDistance = 5f;
    public float shrinkFactor = 0.5f;
    public LayerMask wallLayerMask;

    void Update()
    {
        for (int i = 0; i < 360; i += 10)
        {
            Vector3 rayDirection = Quaternion.Euler(0, i, 0) * transform.forward;
            float raycastDistance = maxRaycastDistance;
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance, wallLayerMask))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    // Raio atingiu parede, diminui tamanho;
                    raycastDistance = hit.distance * shrinkFactor;
                    
                    if (OnRayTouch != null) OnRayTouch.Invoke(hit.collider.gameObject);
                }
            }
            
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, Color.green);
        }
    }
}
