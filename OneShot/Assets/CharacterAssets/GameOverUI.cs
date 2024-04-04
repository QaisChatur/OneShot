using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{

    [SerializeField]
    private Text scoreValueText;

    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        Health.OnPlayerDeath += ActivateGameObject;
        Health.OnEnemyHealth += CountScore;
        this.gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        Health.OnPlayerDeath -= ActivateGameObject;
        Health.OnEnemyHealth -= CountScore;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CountScore()
    {
        score++;
    }

    public void ActivateGameObject()
    {
        this.gameObject.SetActive(true);
        scoreValueText.text = score.ToString();
    }

}
