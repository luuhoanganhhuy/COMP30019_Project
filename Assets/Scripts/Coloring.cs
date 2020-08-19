using UnityEngine;

public class Coloring : MonoBehaviour
{
    //Renderer re;
    public Color changeColorTo = Color.white;

    void Start () {
        //re = GetComponent<Renderer>();
        gameObject.GetComponent<Renderer>().material.color = changeColorTo;
    }
    void Update()
    {
        // Find the component 'Renderer', and change the color of the Material accordingly:
        gameObject.GetComponent<Renderer>().material.color = changeColorTo;
        //re.material.SetColor("_Color", changeColorTo);
    }

}
