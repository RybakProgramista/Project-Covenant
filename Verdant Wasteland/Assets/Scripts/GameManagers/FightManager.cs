using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    //UI
    private Image[] playerCharactersDisplay, enemyCharactersDisplay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartFight();
        }
    }

    private List<Character> _turnOrder = new List<Character>();
    private Dictionary<Character, int> _positions = new Dictionary<Character, int>();

    public void StartFight()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("FightScene");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "FightScene")
        {
            return;
        }
        //loading UI
        playerCharactersDisplay = GameObject.Find("PlayerCharactersDisplay")
            .GetComponentsInChildren<Image>(true)
            .Where(img => img.gameObject != GameObject.Find("PlayerCharactersDisplay"))
            .ToArray();
        enemyCharactersDisplay = GameObject.Find("EnemyCharactersDisplay")
            .GetComponentsInChildren<Image>(true)
            .Where(img => img.gameObject != GameObject.Find("EnemyCharactersDisplay"))
            .ToArray();
        for (int i = 0; i < playerCharactersDisplay.Length; i++)
        {
            playerCharactersDisplay[i].enabled = false;
            enemyCharactersDisplay[i].enabled = false;
        }

        //setting up for the mechanics
        Setup(
        new List<Character>() {
                new MeleeEnemy("Adolfo", 20, 5, 4, loadSprite("Kotomiler")),
                new MeleeEnemy("Filip", 15, 2, 2, loadSprite("Kotomiler")),
                new MeleeEnemy("Filip2", 15, 2, 3, loadSprite("Kotomiler")),
                new MeleeEnemy("Adolfo Jr", 20, 5, 6, loadSprite("Kotomiler")),
        }, new List<Character>
        {
                new PlayerCharater("Kamil", 100, 100, 100, loadSprite("Kamilek"))
        }
        );
    }

    private void Setup(List<Character> playerCh, List<Character> enemyCh)
    {
        _turnOrder = playerCh.Concat(enemyCh).OrderByDescending(c => c.getInitiative()).ToList();
        bool[] enemyPosPool = new bool[] { true, true, true, true }, playerPosPool = new bool[] { true, true, true, true };
        foreach (Character ch in _turnOrder)
        {
            setCharacterAtPos(ch, getRandomPosition(ch.getIsPlayable() ? playerPosPool : enemyPosPool));
        }
    }
    private Sprite loadSprite(string name)
    {
        return Resources.Load<Sprite>("CharacterSprites/" + name);
    }

    private void setCharacterAtPos(Character character, int pos) {
        Image newImg = (character.getIsPlayable() ? playerCharactersDisplay : enemyCharactersDisplay)[pos];
        newImg.enabled = true;
        newImg.sprite = character.getSprite();


        if (_positions.ContainsValue(pos))
        {
            //zabezpieczenie aby dwie postacie nie wyl�dowa�y na tej samej pozycji
        }
        else if (_positions.ContainsKey(character))
        {
            (character.getIsPlayable() ? playerCharactersDisplay : enemyCharactersDisplay)[_positions[character]].enabled = false;
        }
        _positions[character] = pos;
    }

    private int getRandomPosition(bool[] pool)
    {
        if (!pool.Contains(true))
        {
            throw new System.Exception("No valid positions available.");
        }

        int currPos;
        do
        {
            currPos = Random.Range(0, pool.Length);
        }
        while (!pool[currPos]);
        return currPos;
    }
}
