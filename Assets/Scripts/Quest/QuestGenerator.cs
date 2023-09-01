using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class QuestGenerator
{
    public List<Quest> questList = new List<Quest>();
    public List<Quest> getQuest()
    {
        return questList;
    }
    public abstract void CreateQuest(Quest quest);
}
