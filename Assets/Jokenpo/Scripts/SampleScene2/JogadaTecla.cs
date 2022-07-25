using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadaTecla : MonoBehaviour
{
    public TempoJokenpo tempJkp;
    private int j = 0;

    void Start(){
        Debug.Log("inicializando...");
    }

    void loop(){
        if(Input.GetKey(KeyCode.UpArrow)){
            Debug.Log("\n...");
        }

        Jogada_Player_01();
        Jogada_Player_02();
    }

    void Jogada_Player_01(){
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("P1 - Pedra");
        } else if(Input.GetKey(KeyCode.S)){
            Debug.Log("P1 - Tesoura");
        } else if(Input.GetKey(KeyCode.D)){
            Debug.Log("P1 - Papel");
        }
    }

    void Jogada_Player_02(){
        if(Input.GetKey(KeyCode.J)){
            Debug.Log("P2 - Pedra");
        } else if(Input.GetKey(KeyCode.K)){
            Debug.Log("P2 - Tesoura");
        } else if(Input.GetKey(KeyCode.L)){
            Debug.Log("P2 - Papel");
        }
    }
}
