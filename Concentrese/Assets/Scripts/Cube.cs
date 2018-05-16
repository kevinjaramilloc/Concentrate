using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{ 
    [Header("Animator")]
    public Animator animacion;
    
    private void OnMouseDown()
    {
        if(ModelPrefab.cuboModel.play)
        {
            //Gira el cubo y activa la animación
            if (!ModelPrefab.cuboModel.firstSelection)
            {
                ModelPrefab.cuboModel.firstSelection = gameObject;
                GetComponentInChildren<Animator>().SetBool("giro", true);
            }

            else if (!ModelPrefab.cuboModel.secondSelection)
            {
                //Compara las dos selecciones. Si la segunda opción es falsa, se voltea la primera selección y vuelve a jugar
                ModelPrefab.cuboModel.secondSelection = gameObject;
                GetComponentInChildren<Animator>().SetBool("giro",true);
                ModelPrefab.cuboModel.play = false;
                ModelPrefab.cuboModel.SelectionCubes();
            }
        }
    }
}
