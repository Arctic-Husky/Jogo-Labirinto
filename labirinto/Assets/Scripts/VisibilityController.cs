using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class VisibilityController : MonoBehaviour
{
    public List<GameObject> GameObjects;
    
    public MeshRenderer[] Renderers;

    private bool ativado = true;

    private bool chamado = false;

    private Coroutine _coroutine;

    void Start()
    {
        foreach (var renderer in Renderers)
        {
            renderer.enabled = false;
            ativado = false;
        }
        
        LineOfSight.OnRayTouch += HandleRayTouch;
    }

    private void HandleRayTouch(GameObject gameObject)
    {
        
        
        if (ativado)
        {
            //Debug.Log("ja ta ativado");
            
            return;
        }
            
        
        bool achou = false;

        foreach (var objeto in GameObjects)
        {
            if (objeto == gameObject)
            {
                achou = true;
                //Debug.Log("EXISTE");
                break;
            }
        }

        if (!achou)
        {
            //Debug.Log("Nao achou");
            return;
        }
            
            
        
        foreach (var meshRenderer in Renderers)
        {
            meshRenderer.enabled = true;
            ativado = true;
        }
        _coroutine = StartCoroutine(VanishTimer());
    }
    
    private IEnumerator VanishTimer()
    {
        // yield return new WaitForSeconds(3f);
        // Debug.Log("VANISH TIMER");
        
        //float startTime = Time.time;

        
        
        // float elapsedTime = 0f;
        //
        // while (elapsedTime < 3f)
        // {
        //     elapsedTime += Time.deltaTime;
        //     
        //     Debug.Log($"{elapsedTime}");
        //     if (!chamado)
        //     {
        //         Debug.Log("CHAMADO");
        //         yield break; // Exit the coroutine immediately
        //     }
        //
        //     
        //     yield return null;
        // }
        // Debug.Log("VANISH TIMER");
        //
        // foreach (var meshRenderer in Renderers)
        // {
        //     meshRenderer.enabled = false;
        //     ativado = false;
        // }
        
        
        float elapsedTime = 0f;

        while (elapsedTime < 3f)
        {
            // Check if the condition has been met
            if (chamado)
            {
                // Condition met, stop the coroutine
                StopCoroutine(_coroutine);
                Debug.Log("Condition met! Coroutine stopped.");
                yield break;
            }

            // Wait for the next frame
            yield return null;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Coroutine completed without the condition being met
        Debug.Log("Coroutine finished without meeting the condition.");
    }
}
