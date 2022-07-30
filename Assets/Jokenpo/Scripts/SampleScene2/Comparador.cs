using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparador : MonoBehaviour
{
    [SerializeField]
    private JogadaTecla jogTc;
    public int j = 0;

    void Update()
    {
        if (jogTc.respostas)    //Rodrigo --> caso ambos os players tenham jogado...
        {
                for(int i = j; i < 1; i++)  //Rodrigo --> for que limita o for a uma vez usando o valor de j
                {
                    Resultado();    //Rodrigo --> ...faz a análise dos resultados
                    j = 1;
                }

        }
        else
            j = 0;
    }

    void Resultado(){
        //Rodrigo --> análise de todos os possíveis outcomes e seus resultados
        if (jogTc.p1 == 1 & jogTc.p2 == 2)
            Debug.Log("Vitória do Vilão!");
        else if (jogTc.p1 == 1 & jogTc.p2 == 3)
            Debug.Log("Vitória do Player!");
        else if (jogTc.p1 == 2 & jogTc.p2 == 1)
            Debug.Log("Vitória do Player!");
        else if (jogTc.p1 == 2 & jogTc.p2 == 3)
            Debug.Log("Vitória do Vilão!");
        else if (jogTc.p1 == 3 & jogTc.p2 == 2)
            Debug.Log("Vitória do Player!");
        else if (jogTc.p1 == 3 & jogTc.p2 == 1)
            Debug.Log("Vitória do Vilão!");
        else //if (jogTc.p1 == jogTc.p2)
            Debug.Log("Empate!");

        jogTc.resp1 = false;    //Rodrigo --> reset da variável resp1
        jogTc.resp2 = false;    //Rodrigo --> reset da variável resp2
    }

    /*  minha cola, ignorem
    1 -> pedra
    2 -> papel
    3 -> tesoura
    */
}
