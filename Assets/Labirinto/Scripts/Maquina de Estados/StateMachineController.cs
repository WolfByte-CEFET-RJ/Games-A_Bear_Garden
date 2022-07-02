using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachineController : MonoBehaviour
{
    public static StateMachineController instance;
    State _current;
    bool busy;
    public State current{get{return _current;}}
    public Transform selector;

    [Header("ChooseActionState")]
    public List<Image> chooseActionButtons;
    public Image chooseActionState;
    
    void Awake(){
        instance = this;
    }
    void Start()
    {
        ChangeTo<LoadState>();
    }
    public void ChangeTo<T>() where T:State
    {
        State state = GetState<T>();
        if(_current != state)
            ChangeState(state);
    }
    public virtual T GetState<T>() where T: State
    { // Procura o estado na lista de estados, se não encontrar, cria um novo e retorna esse valor.
        T target = GetComponent<T>();
        if(target==null)
            target = gameObject.AddComponent<T>();
        return target;
    }
    
    protected void ChangeState(State value){
        if(busy)
            return;
        busy = true;

        if(_current!=null){
            _current.Exit();
        }

        _current = value;
        if(_current != null)
            _current.Enter();

        busy = false;
    }

}