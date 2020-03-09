using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { INACTIVE, START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state; // States of the combat

    // Prefabs to instatiate on the enemy and player battlestation
    public GameObject playerPrefab; 
    public GameObject enemyPrefab;

    // locations for the prefabs to spawn at
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    // HUD managers for the player and enemy
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    // Dialogue text
    public Text dialogueText;

    // Attack and heal buttons
    public GameObject attack;
    public GameObject heal;

    // Reference the EnemyCreator script and PlayerData
    public EnemyCreator enemy;
    PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the enum state to START and calls the coroutine for SetupBattle
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        // Instaties a player object, the player's prefab at the battlestation. It then gets the component PlayerData
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        player = playerGO.GetComponent<PlayerData>();

        // Instaties a enemy object, the enemy's prefab at the battlestation.
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemy.Hp = enemy.maxHp;

        // Sets the HUD of the player and enemy
        playerHUD.SetPlayerHUD(player);
        enemyHUD.SetEnemyHUD(enemy);

        disableButtons(); // Disable player's attack and heal button
        dialogueText.text = "Enemy Approaching";

        yield return new WaitForSeconds(2f);

        // Set the state's to PLAYERTURN
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Your Turn!";
        disableButtons(); // Enable button the attack and heal buttons
    }

    IEnumerator PlayerAttack()
    {
        dialogueText.text = player.namePlayer + " is attacking!";
        disableButtons();

        bool isDead = enemy.TakeDamage(player.damage); // Call the enemy's TakeDamage function
        enemyHUD.SetHP(enemy.Hp); // Sets the Hp
        yield return new WaitForSeconds(2f);

        if (isDead) // Check if the enemy's heal is 0
        {
            dialogueText.text = "You Won!";
            state = BattleState.WON;
            yield return new WaitForSeconds(2f);
            EndBattle(); // Send the battle
        }
        else
        {
            state = BattleState.ENEMYTURN;
            dialogueText.text = enemy.unitName + "'s turn";
            StartCoroutine(EnemyTurn()); // Sets the state to ENEMYTURN
        }
    }

    IEnumerator PlayerHeal()
    {
        dialogueText.text = player.namePlayer + " is healing!";
        player.healing(); // Calls player's heal function
        playerHUD.SetHP(player.hp);
        disableButtons();

        yield return new WaitForSeconds(1f);

        dialogueText.text = enemy.unitName + "'s turn!";
        state = BattleState.ENEMYTURN; // Sets enemy turn after healing
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        int number = Random.Range(0, 10); // Random number generator

        yield return new WaitForSeconds(2f);

        if (number < 8) // If number less than 8
        {
            dialogueText.text = enemy.unitName + " is attacking";
            bool isDead = player.TakeDamage(enemy.damage); // Attack the player
            playerHUD.SetHP(player.hp);
            yield return new WaitForSeconds(2f);

            if (isDead) // Check if player Hp = 0
            {
                state = BattleState.LOST;
                dialogueText.text = "You Lost!"; // Set state to LOST and end the battle
                EndBattle();
            }
            else
            {
                dialogueText.text = "Your Turn!"; // Sets the state to PLAYERTURN and enable player's turn
                state = BattleState.PLAYERTURN;
                PlayerTurn();
                disableButtons();
            }
        }
        else // If number is not lesser than 8, enemy heals
        {
            dialogueText.text = enemy.unitName + " is healing";
            enemy.healing(); // Enemy heals
            enemyHUD.SetHP(enemy.Hp); // Sets the hp of the enemy
            yield return new WaitForSeconds(2f);
            dialogueText.text = "Your Turn!";
            disableButtons();
            state = BattleState.PLAYERTURN; // State to PlAYERTURN
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON) // Check if the state is won
        {
            if (enemy.rewards == null) // Check if the scriptable object of the enemy does not have an reward
            {
                enableScene();
            }
            else // If there is a reward
            {
                bool itemRewarded = Inventory.instance.Add(enemy.rewards); // Add it to the player's inventory
                enableScene();
            }
        }
        else if (state == BattleState.LOST) // If player lost
        {
            enableScene(); 
        }
    }

    public void OnAttackButton() // To be attatched to the player's attack button
    {
        if (state != BattleState.PLAYERTURN) // If state is not player's turn, return nothing
            return;

        StartCoroutine(PlayerAttack()); // If it is player's turn, call player attack coroutine
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN) // If state is not player's turn, return nothing
            return;

        StartCoroutine(PlayerHeal()); // If it is player's turn, call player heal coroutine
    }

    public void disableButtons() // Disables attack and heal button
    {
        attack.SetActive(!attack.activeSelf);
        heal.SetActive(!heal.activeSelf);
    }

    public void enableScene() // Disable combat scene, activate DataManagement and TutorialLevel scene
    {
        SceneManager.UnloadSceneAsync("Combat");
        SceneManager.LoadScene("DataManagement");
        SceneManager.LoadScene("TutorialLevel", LoadSceneMode.Additive);
    }
}
