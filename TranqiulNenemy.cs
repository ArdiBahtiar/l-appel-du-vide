using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranqiulNenemy : MonoBehaviour
{
    public void musuhNambah()
    {
        LevelGenerator.enemyAmount = LevelGenerator.enemyAmount + 2;
    }

    public void musuhKurang()
    {
        LevelGenerator.enemyAmount--;
    }

    public void tranquilNambah()
    {
        //if(GameManager.gameHasEnded == true)
        

            //   INI YANG BENER GES       
            //EndTrigger.goodWill++;
        

        LevelGenerator.enemyAmount--;
        TImer.startSecond = TImer.startSecond - 5;
       
    }

    public void tranquilKurang()
    {
        //if(GameManager.gameHasEnded == true)
        
            //      INI YANG BENER GES     
            //EndTrigger.goodWill--;
        
        
        LevelGenerator.enemyAmount = LevelGenerator.enemyAmount + 5;
        TImer.startSecond = TImer.startSecond + 15;

    }
}
