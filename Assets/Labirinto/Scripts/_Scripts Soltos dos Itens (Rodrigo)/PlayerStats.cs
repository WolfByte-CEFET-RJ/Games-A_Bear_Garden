using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    //Rodrigo --> Script para armazenar e disponibilizar stats de cada jogador
    [HideInInspector]
    public int _vidaVilao = 9, _vidaHeroi = 4;  //Rodrigo --> Vidas diferentes para manter a vantagem do vilão
    [HideInInspector]
    public int _atkVilao = 2, _atkHeroi = 1;  //Rodrigo --> Ataques diferentes para manter a vantagem do vilão
    
    //[HideInInspector] public int _turnos;

    //Rodrigo --> Definindo o valor dos stats dos jogadores...
    
    //Rodrigo --> ...se forem heróis
    public int StatAtkHeroi(int atk)    //Rodrigo --> método para devolver o valor padrão do ataque dos heróis
    {
        atk = _atkHeroi; //Heróis têm 1 de ataque [Rodrigo]
        return atk;
    }

    public int StatHPHeroi(int hp)  //Rodrigo --> método para devolver o valor padrão da vida dos heróis
    {
        hp = _vidaHeroi; //Heróis têm 4 de vida [Rodrigo]
        return hp;
    }


    //Rodrigo --> ...se for o vilão
    public int StatAtkVilao(int atk)    //Rodrigo --> método para devolver o valor padrão do ataque do vilão
    {
        atk = _atkVilao; //Vilão tem 9 de ataque [Rodrigo]
        return atk;
    }

    public int StatHPVilao(int hp)  //Rodrigo --> método para devolver o valor padrão da vida do vilão
    {
        hp = _vidaVilao; //Vilão tem 9 de vida [Rodrigo]
        return hp;
    }

    /*public int TurnoP1(){   //dá a primeira posição ao jogador 1
        _turnos = 1;
        return _turno;
    }

    public int TurnoP2(){   //dá a segunda posição ao jogador 2
        _turnos = 2;
        return _turno;
    }*/

    /*
    public int TurnoP3(){   //dá a segunda posição ao jogador 2
        _turnos = 3;
        return _turno;
    }

    public int TurnoVilao(){   //dá a segunda posição ao jogador 2
        _turnos = 4;
        return _turno;
    }*/
}
