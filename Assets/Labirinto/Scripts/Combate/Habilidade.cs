using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidade : MonoBehaviour
{
    public int damage;
    public int custoMana;
    public Sprite icon;
    public bool EstaUsando()
    {
        if(Turnos.unit.GetStat(StatEnum.MP)>=custoMana) //só usa a habilidade se houver mana para usar
            return true;
        return false;
    }
    public bool ValidaçaoTarget()
    {
        Unit unit = null;
        if(StateMachineController.instance.selectedTile.content!=null)
        {
            unit = StateMachineController.instance.selectedTile.content.GetComponent<Unit>();
        }
        if(unit!=null)
        {
            return true;
        }
        return false;
    }
    public List<TileLogic> GetTargets()
    {
        List<TileLogic> targets = new List<TileLogic>(); //seleciona o alvo

        targets.Add(StateMachineController.instance.selectedTile);
        return targets;
    }
    public void Efeito() //variavel de ataque
    {
        FilterContent();

        for(int i =0;i<Turnos.targets.Count; i++)
        {
            Unit unit = Turnos.targets[i].content.GetComponent<Unit>(); //atacado
            if(unit!=null)
            {
                Debug.LogFormat("{0} estava com {1} HP, foi atingido por {2} e ficou com {3} ", unit, unit.GetStat(StatEnum.HP), -damage, unit.GetStat(StatEnum.HP)-damage);
                unit.SetStat(StatEnum.HP, -damage); //se atacar, da o dano e retorna com o hp tirado
            }
        }
    }
    void FilterContent()
    {
        Turnos.targets.RemoveAll((x)=>x.content == null); //passa o turno
    }
}
