using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelPrefab : MonoBehaviour
{
    public static ModelPrefab cuboModel;
    public static int countWin;
    public static int s;

    public GameObject firstSelection { get; set; }
    public GameObject secondSelection { get; set; }
    public bool play;
    public Transform camara;
    [Header("Prefab")]
    public GameObject cubo;
    [Header("Materials")]
    public Material[] mat;
    [Header("Parcticles")]
    public GameObject[] particulas;
    [Header("Cubes")]
    public static int numerCubos;
    public List<GameObject> cubes;

    private List<int> indices;
    private int indice1;
    private int indice2;
    private int randomMaterial;
    private int cube1;
    private int cube2;

    void Start()
    {
        InstanceCubes();
        AddComponents();
        AddIndex();
        CoupleMaterials();  
    }

    private void Awake()
    {
       //Si el nombre de la escena coincide, toma el número de cubos
       countWin = 0;
       Scene escena = SceneManager.GetActiveScene();
        if (escena.name == "FirstScene")
        {
            numerCubos = 3;
        }
        else if (escena.name == "SecondScene")
        {
            numerCubos = 5;
        }
        else if (escena.name == "FinalScene")
        {
            numerCubos = 7;
        }

    }

    public void InstanceCubes()
    {
        cubes = new List<GameObject>();
        indices = new List<int>();
        //Inicialización
        cuboModel = this;
        //Estado de juego
        play = true;
        //Posicion de la cámara
        camara.position = new Vector3(numerCubos / 2, numerCubos / 2.2f, 8);

        //Instancia los cubos y el número de cubos en el inspector
        for (int i = 1; i < numerCubos; i++)
        {
            for (int j = 0; j < numerCubos; j++)
            {
                cubes.Add(Instantiate(cubo, new Vector3(j, i, 0), Quaternion.identity));
            }
        }
    }

    void CoupleMaterials()
    {
        numerCubos = 0;
        //Escoge un material al azar para los cubos
        for (int i = 0; i<cubes.Count / 2; i++)
        {
            randomMaterial = Random.Range(0, mat.Length);
            cube1 = Random.Range(0, indices.Count);
            DeleteIndex(cube1, ref indice1);
            cube2 = Random.Range(0, indices.Count);
            DeleteIndex(cube2, ref indice2);
            cubes[indice1].GetComponentInChildren<MeshRenderer>().material = mat[randomMaterial];
            cubes[indice2].GetComponentInChildren<MeshRenderer>().material = mat[randomMaterial];
            numerCubos++;
        }
    }

    private void DeleteIndex(int num, ref int numCubo)
    {
        numCubo = indices[num];
        indices.Remove(indices[num]);
    }

    void AddIndex()
    {
        //A cada cubo se le agrega el indice para obtener su par
        for(int i = 0; i < cubes.Count; i++)
        {
            indices.Add(i);
        }
    }

    private void AddComponents()
    {
        //A cada cubo instanciado se le agrega el script Cube
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].AddComponent<Cube>();
        }

    }


    public void SelectionCubes()
    {
        if (firstSelection.GetComponentInChildren<MeshRenderer>().material.name == secondSelection.GetComponentInChildren<MeshRenderer>().material.name)
        {
            //Si los materiales son iguales se desactivan las selecciones y se instancian las particulas
            Destroy(firstSelection, 1f);
            Destroy(secondSelection, 1f);
            GameObject parti = Instantiate(particulas[Random.Range(0, particulas.Length)], firstSelection.transform.position, Quaternion.Euler(0, 180, 0));
            GameObject parti2 = Instantiate(particulas[Random.Range(0, particulas.Length)], secondSelection.transform.position, Quaternion.Euler(0, 180, 0));
            StartCoroutine(Verify());
            countWin++;
        }

        else if(firstSelection.GetComponentInChildren<MeshRenderer>().material.name != secondSelection.GetComponentInChildren<MeshRenderer>().material.name)
        {

            //Si son distintos no se activa la animacion
            firstSelection.GetComponentInChildren<Animator>().SetBool("giro", false);
            secondSelection.GetComponentInChildren<Animator>().SetBool("giro", false);
            firstSelection = null;
            secondSelection = null;
            StartCoroutine(Verify());
        }
    }

    IEnumerator Verify()
    {
        //Tiempo que demora en volver a hacer una seleccion
        yield return new WaitForSeconds(0.5f);
        play = true;
    }
}
