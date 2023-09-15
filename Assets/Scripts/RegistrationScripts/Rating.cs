using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

[System.Serializable]
public struct RatingHolder
{
    public string nickname;
    public int rating;
}

[System.Serializable]
public struct Ratings
{
    public RatingHolder[] ratings;
}

[System.Serializable]
public struct RatingFields
{
    public TMP_Text nickname;
    public TMP_Text rating;
}

public class Rating : MonoBehaviour
{
    string www = "https://it.dpo.tsu.ru/itgame/rating.php";

    public Ratings players;

    public TMP_Text nickname, rating, position;

    public RatingFields[] fields;

    public GameObject frame1, frame2, frame3;

    public void Awake()
    {
        nickname.text = WebManager.player.nickname;
        rating.text = WebManager.player.progress.Sum().ToString();
        StartCoroutine(GetRating());
        StartCoroutine(GetPosition());
    }

    IEnumerator GetRating()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(www))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) //зокментировать до else
            {
                Debug.Log(request.error);
            }
            else
            {
                print(request.downloadHandler.text);

                string json = "{\"ratings\":" + request.downloadHandler.text + "}";

                print(json);

                players = JsonUtility.FromJson<Ratings>(json);

                for (int i = 0; i < 5; i++)
                {
                    fields[i].nickname.text = players.ratings[i].nickname;
                    fields[i].rating.text = players.ratings[i].rating.ToString();
                }
            }
        }
    }

    IEnumerator GetPosition()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", WebManager.player.id);

        using (UnityWebRequest request = UnityWebRequest.Post(www, form))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) //зокментировать до else
            {
                Debug.Log(request.error);
            }
            else
            {
                string ans = request.downloadHandler.text;
                print(ans);

                if(ans.Length < 4) position.text = ans;
                else position.text = ">1k";

                switch (ans.Length)
                {
                    case 1:
                        frame1.gameObject.SetActive(true);
                        break;
                    case 2:
                        frame2.gameObject.SetActive(true);
                        break;
                    default:
                        frame3.gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}
