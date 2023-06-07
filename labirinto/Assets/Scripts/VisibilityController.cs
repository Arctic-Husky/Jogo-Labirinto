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
            return;
        }
            
        
        bool achou = false;

        foreach (var objeto in GameObjects)
        {
            if (objeto == gameObject)
            {
                achou = true;
                break;
            }
        }

        if (!achou)
        {
            return;
        }
            
            
        
        foreach (var meshRenderer in Renderers)
        {
            meshRenderer.enabled = true;
            ativado = true;
        }
    }
}
