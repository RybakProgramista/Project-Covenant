using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;
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
            Setup(
           new List<Character>() {
                new MeleeEnemy("Adolfo", 20, 5, 4),
                new MeleeEnemy("Filip", 15, 2, 2),
                new MeleeEnemy("Filip2", 15, 2, 3),
                new MeleeEnemy("Adolfo Jr", 20, 5, 6),
           }, new List<Character>
           {
                new PlayerCharater("Kamil", 100, 100, 100)
           }
           );
        }
    }

    private List<Character> _turnOrder = new List<Character>();
    private Dictionary<Character, int> _positions = new Dictionary<Character, int>();

    public void Setup(List<Character> playerCh, List<Character> enemyCh)
    {
        _turnOrder = playerCh.Concat(enemyCh).OrderByDescending(c => c.getInitiative()).ToList();
        bool[] enemyPosPool, playerPosPool;
        enemyPosPool = playerPosPool = new bool[]{ true, true, true, true };
        int iteration = 1;
        foreach (Character ch in _turnOrder)
        {
            _positions.Add(ch, getRandomPosition(ch.getIsPlayable() ? playerPosPool : enemyPosPool));
            (ch.getIsPlayable() ? playerPosPool : enemyPosPool)[_positions[ch]] = false;
            for(int x = 0; x < (ch.getIsPlayable() ? playerPosPool : enemyPosPool).Length; x++)
            {
                Debug.Log(iteration + " " + (ch.getIsPlayable() ? playerPosPool : enemyPosPool)[x]);
            }
            iteration++;
        }
            
        foreach (Character ch in _positions.Keys)
        {
            Debug.Log(ch.getName() + " jest na pozycji " + _positions[ch]);
        }
    }
    int getRandomPosition(bool[] pool)
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
