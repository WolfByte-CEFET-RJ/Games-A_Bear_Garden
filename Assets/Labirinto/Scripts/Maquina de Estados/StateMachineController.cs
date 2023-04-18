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
    public TileLogic selectedTile;
    public List<Unit> units; // lista de unidades que podem ser selecionadas

    [Header("ChooseActionState")]
    public List<Image> chooseActionButtons; // lista de botoes no painel para selecionar: Andar, atacar, trap e Passar a vez
    public Image chooseActionSelection; // acao selecionada no painel
    public LugarPainel chooseActionPainel;
    
    [Header("SeleçãoHabilidadeState")]
    public List<Image> SeleçaoHabilidadesButtons;
    public Image SeleçaoHabilidadesSelection;
    public LugarPainel SeleçaoHabilidadesPainel;
    public Sprite SeleçaoHabilidadesBloqueada;

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
        if(_current !=null)
            _current.Enter();

        busy = false;
    }
}