using UnityEngine;
using KZ.IOLib;
using System.Collections.Generic;

public enum TestEnum
{
    A,
    B,
    C
}
public class IOTester : MonoBehaviour {

    public string datapath;

    public string fileName;

    public TextAsset textAsset;

    //public TestEnum[,] array;

    public string[,] array;

    // csvデータ読み出し先
    public List<List<string>> data;

    // ファイル読み込み時に無視する文字列または文字
    [SerializeField]
    private string[] ignoreItems;
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
        Init();

        Show(this.array);

        //CSVIO.SaveMap(ref this.array, this.datapath);

        print("Saved " + this.datapath);
    }

    public void TestLoad()
    {
        //CSVIO.LoadMap(ref this.array, this.datapath);
        CSVIO.LoadMap(ref data,this.textAsset.text,this.ignoreItems,EOF_Descriptor);

        print("Loaded " + this.datapath);

        Show(data);
    }


    #region
    void Init()
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                //array[i, j] = (TestEnum)Random.Range(0, 3);
            }
        }
    }
    #region
    // 配列表示用関数
    void Show(string[,] array)
    {
        string stream = "";
        /*
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                stream += array[i, j];
                if (j != array.GetLength(1) - 1)
                {
                    stream += ",";
                }
                else
                {
                    stream += "\n";
                }
            }
        }
        print(stream);
        */

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                print("array[" + i + "," + j + "] : " + array[i, j]);
            }
        }
    }
    void Show(List<List<string>> array)
    {
        string stream = "";
        /*
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                stream += array[i, j];
                if (j != array.GetLength(1) - 1)
                {
                    stream += ",";
                }
                else
                {
                    stream += "\n";
                }
            }
        }
        print(stream);
        */

        print("rows =" + array.Count + "cols = " + array[0].Count);

        for (int i = 0; i < array.Count; i++)
        {
            for (int j = 0; j < array[i].Count; j++)
            {
                print("array[" + i + "," + j + "] : " + array[i][j]);
            }
        }
    }
    #endregion
    #endregion
}
