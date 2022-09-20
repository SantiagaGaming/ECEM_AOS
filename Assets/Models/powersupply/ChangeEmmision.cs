using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmmision : MonoBehaviour
{
    private float MaxF = 100;
    private float EmI;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
      //  Color color = new Color(100, 50, 100, 150);

        EmI = 500;
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("HDRenderPipeline/Lit");
        rend.material.SetFloat("_EmissiveIntensity", EmI);
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("_EmissiveIntensity", EmI);

        if (EmI >= 500)
        {
            EmI -= MaxF *  (Time.deltaTime);
        }
        if (EmI <= 0)
        {
            EmI += MaxF * (Time.deltaTime);
        }

    }
}
