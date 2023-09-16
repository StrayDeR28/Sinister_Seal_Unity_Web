using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Reflection.Emit;
using UnityEngine.UIElements;

public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color disabledColor;
    private StoryScene scene;
    private TextMeshProUGUI textMesh;
    private ChooseController controller;
    private string achievement;
    private string condition;

    private bool chooseMade = false;
    private bool conditionMet = true;//Остутсвие условия = условие выполнено

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
    }

    public float GetHeight()
    {
        return textMesh.rectTransform.sizeDelta.y * textMesh.rectTransform.localScale.y;
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y)
    {
        scene = label.nextScene;
        textMesh.text = label.text;
        this.controller = controller;
        achievement = label.achievement;
        condition = label.condition;
        if (condition != "") { conditionMet = controller.CheckConditionContent(condition); }
        if (conditionMet == false) { textMesh.color = disabledColor; }

        Vector3 position = textMesh.rectTransform.localPosition;
        position.y = y;
        textMesh.rectTransform.localPosition = position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (conditionMet==true) 
        { 
            if (chooseMade == false)
            {
                if (achievement != "")
                {
                    controller.CheckAchivement(achievement); 
                }
                if (condition != "")// чтобы не менять следующую сцену для вариантов без condition
                {
                    scene = controller.ChooseStoryScene(condition); 
                }
                controller.PerformChoose(scene);
                chooseMade = true;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (conditionMet == true)
        {
            textMesh.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (conditionMet == true)
        {
            textMesh.color = defaultColor;
        }
    }
}
