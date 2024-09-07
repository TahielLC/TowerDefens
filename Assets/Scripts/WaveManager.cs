using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public List<WaveObject> waves = new List<WaveObject>();
    public bool wavesFinish;
    public bool isWaitingForNextWave;
    public int currentWave;
    public Transform initPosition;
    public TextMeshProUGUI couterText;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void checkCounterForNextWave()
    {
        if (isWaitingForNextWave && !wavesFinish)
        {
            waves[currentWave].counterToNextWave += 1 * Time.deltaTime;
            couterText.text = waves[currentWave].counterToNextWave.ToString("00");
            //condicion que pregunta para pasar a la siguiente ronda 
            if (waves[currentWave].counterToNextWave >= waves[currentWave].timeForNewtWave)
            {
                Debug.Log("Set Next Wave");
            }

        }
    }
    private IEnumerator ProcesWave()
    {
        if (wavesFinish)
        {
            yield break;
            isWaitingForNextWave = false;
            for (int i = 0; i < waves[currentWave].enemys.Count; i++)
            {
                var enemyGo = Instantiate(waves[currentWave].enemys[i], initPosition.position, initPosition.rotation);
                yield return new WaitForSeconds(waves[currentWave].timePerCreation);
            }
            isWaitingForNextWave = true;
            if (currentWave >= waves.Count - 1)
            {
                Debug.Log("Nivel terminado");
                wavesFinish = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
[System.Serializable]
public class WaveObject
{
    public float timePerCreation = 1;
    public float timeForNewtWave = 10f;
    public float counterToNextWave = 0;
    public List<Enemy> enemys = new List<Enemy>();

}