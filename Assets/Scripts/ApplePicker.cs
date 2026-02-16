using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public GameObject restartButton;
    static public bool isGameOver;

    // Start is called before the first frame update
    void Start(){
        isGameOver = false;

        // Find the restart button and deactivate it
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);

        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        // Update the round number display
        UpdateRoundInfo(false);
    }

    public void AppleMissed(){

        // Destroy one of the Baskets

        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;

        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if(basketList.Count == 0){
            GameOver();
        }
        else{
            DestroyAllFallingObjects();
            UpdateRoundInfo(false);
        }
    }

    public void GameOver(){
        // Destroy all apples and branches
        DestroyAllFallingObjects();

        // Notify other GameObjects that the game ended
        isGameOver = true;

        // Update the round to 0 (game over)
        UpdateRoundInfo(true);

        // Display the restart button
        restartButton.SetActive(true);
    }

    private void UpdateRoundInfo(bool isGameOver){
        // Update round number (0 = game over)
        if(isGameOver){
            RoundInfo.roundNum = 0;
        }
        else{
            RoundInfo.roundNum = numBaskets - basketList.Count + 1;
        }
    }

    private void DestroyAllFallingObjects(){
        // Destroy all of the falling Apples and Branches
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");

        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }

        foreach(GameObject tempGO in branchArray){
            Destroy(tempGO);
        }
    }
}
