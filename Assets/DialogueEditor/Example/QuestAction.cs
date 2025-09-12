using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class QuestAction : MonoBehaviour
{
    [SerializeField] private NPCConversation _nPCConversation;
    [SerializeField] private Quest _quest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveController>(out MoveController moveController))
        {
            var instance = ConversationManager.Instance;

            instance.StartConversation(_nPCConversation);
            _quest.SetValues();
        }
    }
}