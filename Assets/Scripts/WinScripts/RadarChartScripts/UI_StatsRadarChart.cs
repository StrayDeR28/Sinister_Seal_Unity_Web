using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatsRadarChart : MonoBehaviour {

    [SerializeField] private Material radarMaterial;
    [SerializeField] private Texture2D radarTexture2D;

    private Stats stats;
    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake() {
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
        stats = new Stats(80,80,80,80,80,80,80);
        for (int i = 0; i < 7; i++)
        {
            int Stat = 0;
            for (int j = 0; j < 4; j++)
            {
                Stat += WebManager.player.progress[i * 4 + j];
            }
            stats.SetStatAmount((Stats.Type)i, Stat);
        }
        SetStats(stats);
    }

    public void SetStats(Stats stats) {
        this.stats = stats;
        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsVisual();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e) {
        UpdateStatsVisual();
    }

    private void UpdateStatsVisual() {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[8];
        Vector2[] uv = new Vector2[8];
        int[] triangles = new int[3 * 7];

        float angleIncrement = 360f / 7;
        float radarChartSize = 128f;//в конце поменять на нужное
        //надо будет все в правильном порядке
        Vector3 ZerokottoVertex     = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Zerokotto);
        int ZerokottoVertexIndex    = 1;
        Vector3 ChatabottoVertex    = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Chatabotto);
        int ChatabottoVertexIndex   = 2;
        Vector3 IgrahagiVertex      = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Igrahagi);
        int IgrahagiVertexIndex     = 3;
        Vector3 JavascriptuVertex   = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Javascriptu);
        int JavascriptuVertexIndex  = 4;
        Vector3 ReliaochokiVertex   = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Reliaochoki);
        int ReliaochokiVertexIndex  = 5;
        Vector3 NapitoneVertex      = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Napitone);
        int NapitoneVertexIndex     = 6;
        Vector3 AndroididzuVertex   = Quaternion.Euler(0, 0, -angleIncrement * 6) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Androididzu);
        int AndroididzuVertexIndex  = 7;

        vertices[0]                      = Vector3.zero;
        vertices[ZerokottoVertexIndex]   = ZerokottoVertex;
        vertices[AndroididzuVertexIndex] = AndroididzuVertex;
        vertices[ReliaochokiVertexIndex] = ReliaochokiVertex;
        vertices[ChatabottoVertexIndex]  = ChatabottoVertex;
        vertices[IgrahagiVertexIndex]    = IgrahagiVertex;
        vertices[JavascriptuVertexIndex] = JavascriptuVertex;
        vertices[NapitoneVertexIndex]    = NapitoneVertex;

        uv[0]                      = Vector2.zero;
        uv[ZerokottoVertexIndex]   = Vector2.one;
        uv[AndroididzuVertexIndex] = Vector2.one;
        uv[ReliaochokiVertexIndex] = Vector2.one;
        uv[ChatabottoVertexIndex]  = Vector2.one;
        uv[IgrahagiVertexIndex]    = Vector2.one;
        uv[JavascriptuVertexIndex] = Vector2.one;
        uv[NapitoneVertexIndex]    = Vector2.one;

        triangles[0]  = 0;
        triangles[1]  = ZerokottoVertexIndex;
        triangles[2]  = ChatabottoVertexIndex;

        triangles[3]  = 0;
        triangles[4]  = ChatabottoVertexIndex;
        triangles[5]  = IgrahagiVertexIndex;

        triangles[6]  = 0;
        triangles[7]  = IgrahagiVertexIndex;
        triangles[8]  = JavascriptuVertexIndex;

        triangles[9]  = 0;
        triangles[10] = JavascriptuVertexIndex;
        triangles[11] = ReliaochokiVertexIndex;

        triangles[12] = 0;
        triangles[13] = ReliaochokiVertexIndex;
        triangles[14] = NapitoneVertexIndex;

        triangles[15] = 0;
        triangles[16] = NapitoneVertexIndex;
        triangles[17] = AndroididzuVertexIndex;

        triangles[18] = 0;
        triangles[19] = AndroididzuVertexIndex;
        triangles[20] = ZerokottoVertexIndex;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, radarTexture2D);
    }
}