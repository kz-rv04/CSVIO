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

    public List<List<string>> data;

    [SerializeField]
    private string[] ignoreItems;

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
        data =  CSVIO.LoadMap(this.textAsset.text,this.ignoreItems,"END");

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

        print("i =" + array.Count + "j = " + array[0].Count);

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
