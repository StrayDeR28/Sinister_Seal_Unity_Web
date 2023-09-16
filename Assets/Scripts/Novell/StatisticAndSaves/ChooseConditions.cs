using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseConditions : MonoBehaviour
{
    [SerializeField] private List<StoryScene> storyScenes;
   //public Dictionary<string,StoryScene> storyScenesDictionary;
    public bool CheckContent(string condition)
    {
        if (PlayerPrefs.GetString(condition) == "")
        {
            print("condition is`nt met");
            return false;
        }
        return true;
    }
    public StoryScene ChooseSceneToLoad(string condition)
    {
        StoryScene scene = null;
        if (condition == "Condition:potion")//условия
        {
            switch (PlayerPrefs.GetString(condition))
            {
                case "Bomb"://нужное условие прописать
                    scene = FindListElement("Novell2.1");
                    break;
                default:
                    print("передали не предусмотренный параметр в PlayerPrefs \"Condition:potion\" ");
                    break;
            }
        }
        return scene;
    }
    private StoryScene FindListElement(string name)
    {
        for(int i = 0; i < storyScenes.Count; i++)
        {
            if (storyScenes[i].name == name) { return storyScenes[i]; }
        }
        print("no such story scene "+name);
        return null;
    }
}
