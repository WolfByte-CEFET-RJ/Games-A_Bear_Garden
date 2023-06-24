using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadeTargetSate : State
{

    [SerializeField] Habilidade habilidadeSelected;


    public override void Enter()
   {
      base.Enter();
      inputs.OnMove+=OnMoveTileSelector;
      inputs.OnFire+=OnFire;
      CheckHabilidades();
   }
   public override void Exit()
   {
      base.Exit();
      inputs.OnMove-=OnMoveTileSelector;
      inputs.OnFire-=OnFire;
   }
   void OnFire(object sender, object args)
   {
        int button = (int)args;
        if(button==1)
        {
            if(!(habilidadeSelected.EstaUsando()))  //Rodrigo --> não faz nada caso o player não tenha mana
            {
                Debug.Log("Você não tem mana o suficiente!");   //Rodrigo --> fazer em UI
                AudioController.SelectSound(5);
            }               
            else if(!(Turnos.habilidade.ValidaçaoTarget())) //Rodrigo --> não faz nada caso o player não tenha selecionado um alvo
            {
                Debug.Log("Por favor, selecione um alvo."); //Rodrigo --> fazer em UI
                AudioController.SelectSound(5);
            }
            else if(Turnos.habilidade.ValidaçaoTarget() && habilidadeSelected.EstaUsando())
            {
                Turnos.targets = Turnos.habilidade.GetTargets(); // pego os targets selecionados

                for(int i =0;i<Turnos.targets.Count; i++) // faco uma iteracao entre todos os targets na lista
                {
                    Unit unit = Turnos.targets[i].content.GetComponent<Unit>(); //atacado // pego a unit na qual esta posicionada no target selecionado

                    if(Turnos.unit.equipe /* atacando */ != unit.equipe /* atacado */) // verifico se a unit do target selecionado (a atacada) é de uma equipe diferente da unit do turno (a atacante) e se existe alguma unit sendo atacada
                    {
                        machine.ChangeTo<PerformaceHabilidadeState>(); // mudo para o estado de tirar dano, caso essa condicao n for atendida o jogo continuará no estado HabilidadeTargetSate, até essa condicao for atendida ou for clicado o botao da direita e voltar ao ChooseActionState
                    }
                }
            }
        }
        else if(button==2)
        {
          machine.ChangeTo<ChooseActionState>();
        }
    }

    void CheckHabilidades()
    {
        GameObject habilidadeObject = GameObject.FindGameObjectWithTag("Habilidade Ataque");
        habilidadeSelected = habilidadeObject.GetComponent<Habilidade>();

        if(habilidadeSelected.EstaUsando())
        {
            Debug.Log("Usando "+habilidadeSelected.name);
            Turnos.habilidade = habilidadeSelected;
        }
    }
}


