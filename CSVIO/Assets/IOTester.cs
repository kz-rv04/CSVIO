using UnityEngine;
using KZ.IOLib;
using System.Collections.Generic;

public enum TestEnum
{
    A,
    B,
    C,
    D
}
public class IOTester : MonoBehaviour {

    public string datapath;

    public string fileName;

    public TextAsset textAsset;
    
    // csvデータ読み出し先
    private List<List<float>> data;
    // csvデータ読み出し先
    private float[,] array;

    // ファイル読み込み時に無視する文字列または文字
    [SerializeField]
    private List<string> ignoreItems;
    // ファイル終端識別子
    [SerializeField]
    private string EOF_Descriptor;

	// Use this for initialization
	void Start () {
        //array = new TestEnum[3, 3];
        datapath = Application.dataPath + "/" +  fileName;
	}

    public void TestSave()
    {
        datapath = Application.dataPath + "/" + fileName;

        CSVIO.SaveMap<float>(ref this.data, this.datapath);

        print("Saved " + this.datapath);
    }

    public void TestLoad()
    {
        // ファイルパス指定により読み込み
        //CSVIO.LoadMap<int>(ref data,this.datapath,this.ignoreItems,EOF_Descriptor);
        // TextAssetから読み込み
        //CSVIO.LoadMap<float>(ref data, this.textAsset, this.ignoreItems, EOF_Descriptor);
        // 配列へ読み込み path指定、TextAssetからの読み込みに対応
        CSVIO.LoadMap(ref array, this.textAsset, EOF_Descriptor);

        print("Loaded " + this.datapath);
        //配列内のデータ表示
        Show(array);
        //リスト内のデータ表示
        //Show<float>(this.data);
    }

    #region
    // 配列表示用関数
    void Show<T>(T[,] array)
    {
        string str = string.Empty;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                str += array[i, j].ToString() + ",";
            }
            str += "\n";
        }
        print(str);
    }
    void Show<T>(List<List<T>> array)
    {
        string str = string.Empty;
        foreach (List<T> line in array)
        {
            foreach (T i in line)
            {
                str += i.ToString() + ',';
            }
            str += '\n';
        }
        print(str);
    }
    #endregion
}
