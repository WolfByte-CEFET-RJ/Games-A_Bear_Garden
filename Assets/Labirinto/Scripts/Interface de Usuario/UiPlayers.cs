using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UiPlayers : MonoBehaviour
{
    [Header("List Of UI Player")]
    
    [SerializeField] private List<GameObject> lifeBars;     // 0: Vilao  /   1: Player 1   /   2: Player 2    /   3: Player 3

    [SerializeField] private List<GameObject> manaBars;     // 0: Vilao  /   1: Player 1   /   2: Player 2    /   3: Player 3

    private List<Unit> players;    // 0: Vilao  /   1: Player 1   /   2: Player 2    /   3: Player 3

    [Space(4)]

    [Header("Attributes Of UI Player")]

    public static Unit target; // esse alvo auxilia em qual barra haverá alguma modificacao

    private float[] lentghsOfLifeBars = new float[4]; // tamanhos da barra de acordo com o Scale X

    private bool valueDefaultManaBarUi; // valor padrao inicial das mana bars

    private void Start()
    {
        #region LenghtLifeBars
        lentghsOfLifeBars[0] = lifeBars[0].transform.localScale.x;
        lentghsOfLifeBars[1] = lifeBars[1].transform.localScale.x;
        lentghsOfLifeBars[2] = lifeBars[2].transform.localScale.x;
        lentghsOfLifeBars[3] = lifeBars[3].transform.localScale.x;
        #endregion
        
        
        players = StateMachineController.instance.units;
    }
    void Update()
    {
        
            ManageLifeBarUI();
            ManageManaBarUI();
        
        
    }

    public void ManageLifeBarUI()
    {
        if(target != null)  
        {
            Debug.Log("Target Escolhido: "+ target.name);
            switch(target.name)
            {
                case "Vilao":
                    
                    if(lentghsOfLifeBars[0] - 0.4f >= 0)
                    {
                        lifeBars[0].transform.DOScaleX(lentghsOfLifeBars[0] - 0.4f,2);
                        lentghsOfLifeBars[0] = lentghsOfLifeBars[0] - 0.4f;
                        Debug.Log(lentghsOfLifeBars[0]);
                        
                    }
                    else
                    {
                        lifeBars[0].transform.DOScaleX(0,2);
                    }

                        target = null;

                    break;

                case "Jogador 1":
                    
                    if(lentghsOfLifeBars[1] - (Turnos.unit.atk*0.5f) >= 0)
                    {
                        lifeBars[1].transform.DOScaleX(lentghsOfLifeBars[1] - (Turnos.unit.atk*0.5f),2);
                        lentghsOfLifeBars[1] = lentghsOfLifeBars[1] - (Turnos.unit.atk*0.5f);
                        Debug.Log("Comprimento da barra de vida heroi: "+lentghsOfLifeBars[1]);
                        
                    }
                    else
                    {
                        lifeBars[1].transform.DOScaleX(0,2);
                    }
                        target = null;
                    break;

                case "Jogador 2":
                    
                    if(lentghsOfLifeBars[2] - (Turnos.unit.atk*0.5f) >= 0)
                    {
                        lifeBars[2].transform.DOScaleX(lentghsOfLifeBars[2] - (Turnos.unit.atk*0.5f),2);
                        lentghsOfLifeBars[2] = lentghsOfLifeBars[2] - (Turnos.unit.atk*0.5f);
                        Debug.Log("Comprimento da barra de vida heroi: "+lentghsOfLifeBars[2]);
                        
                    }
                    else
                    {
                        lifeBars[2].transform.DOScaleX(0,2);
                    }

                        target = null;
                    break;

                case "Jogador 3":
                    
                    if(lentghsOfLifeBars[3] - (Turnos.unit.atk*0.5f) >= 0)
                    {
                        lifeBars[3].transform.DOScaleX(lentghsOfLifeBars[3] - (Turnos.unit.atk*0.5f),2);
                        lentghsOfLifeBars[3] = lentghsOfLifeBars[3] - (Turnos.unit.atk*0.5f);
                        Debug.Log("Comprimento da barra de vida heroi: "+lentghsOfLifeBars[3]);
                        
                    }
                    else
                    {
                        lifeBars[3].transform.DOScaleX(0,2);
                    }

                        target = null;
                    break;

                
            }
        }
        
        
    }

    public void ManageManaBarUI()
    {
        if(Turnos.unit != null)  
        {
            if(valueDefaultManaBarUi == false)
            {
                manaBars[0].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                manaBars[1].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                manaBars[2].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                manaBars[3].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                valueDefaultManaBarUi = true;
            }

            switch(Turnos.unit.name)
            {
                case "Vilao":
                    manaBars[0].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                    target = null;
                    break;

                case "Jogador 1":
                    manaBars[1].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                    target = null;
                    break;

                case "Jogador 2":
                    manaBars[2].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                    target = null;
                    break;

                case "Jogador 3":
                    manaBars[3].transform.DOScaleX(Turnos.unit.mana * 0.1f,2);
                    target = null;
                    break;
                
                
            }
        }
        
    }
}
