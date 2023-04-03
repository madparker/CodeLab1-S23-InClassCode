using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueueExample : MonoBehaviour
{
    private Queue<string> fishQueue = new Queue<string>();

    public Text display;

    private float timer = 0;
    private float timePerTurn = 5;

    private void Start()
    {
    }

    private void Update()
    {
        // If you press space, reload the scene.  This makes it easy to restart!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // If a move takes more than 5 seconds, continue.
        if (timer > timePerTurn) return;
        
        // Increase the timer.
        timer += Time.deltaTime;

        // If you press A, S, D, or F, push that move into the queue.
        if (Input.GetKeyDown(KeyCode.A))
        {
            fishQueue.Enqueue("Angel Fish");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            fishQueue.Enqueue("Sailfish");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            fishQueue.Enqueue("Dartfish");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fishQueue.Enqueue("Flounder");
        }

        // If the time is up, say that time is up and show the effects.
        if (timer >= timePerTurn)
        {
            display.text = "Time is up!\n";

            ShowQueueEffects();
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F2");
        }
    }

    private void ShowQueueEffects()
    {
        // While there are effects in the queue, dequeue them out and show them.
        while (fishQueue.Count > 0)
            display.text += "\n" + fishQueue.Dequeue();
    }
}
