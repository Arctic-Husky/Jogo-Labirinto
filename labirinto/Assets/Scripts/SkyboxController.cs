using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public float rotationSpeed = 0.01f;
    public Material skyboxMaterial;

    public float rotation = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        skyboxMaterial.SetFloat("_Rotation", rotation);
        //skyboxMaterial = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        skyboxMaterial.SetFloat("_Rotation", rotation);
        if (rotation >= 360f)
            rotation = 0;
    }
}
