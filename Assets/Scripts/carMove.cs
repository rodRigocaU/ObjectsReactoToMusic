using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 0.0f;
    void Start()
    {
        velocity = 20.0f;       
    }

    // Update is called once per frame
    void Update()
    {
        /*CODIGO INICIAL
      METODO PARA CAMBIAR AL POSICIÓN
      TAMBIEN PODEMOS USAR LA FUNCION PREDEFINIDA
      transform.Translate(Vector3.forward);
      Ecuacion de la fisica para la velocidad por el tiempo:
      S = S0  + v*t*(direccion)

      //COMO HACER PARA EL OBJETO SE VAYA A AL DIAGONAL
      this.transform.position += 20*Time.deltaTime* (Vector3.forward + Vector3.right);

      this.transform.Translate(0,0, 0.001f);
      


      */ 
        //this.transform.Translate(translation: 20 * Time.deltaTime * Vector3.forward);
       //this.transform.position += velocity * Time.deltaTime * (Vector3.right);

    }
}
