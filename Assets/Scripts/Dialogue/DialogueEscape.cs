using UnityEngine;
using Yarn.Unity;

public class DialogueEscapeStop : MonoBehaviour
{
    DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.Stop();
        }
    }
}