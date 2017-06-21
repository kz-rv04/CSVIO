using System;
using System.IO;
using System.Collections.Generic;

namespace KZ
{
    // 外部ファイル入出力系統
    namespace IOLib
    {
        /// <summary>
        /// CSV in out
        /// </summary>
        public static class CSVIO
        {
            // CSVデータの内容を配列に読み込む関数
            #region
            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="dataPath">読み込む外部データのパス</param>
            public static void LoadMap(ref int[,] mapArray, string path)
            {
                StreamReader sr = new StreamReader(path);
                //指定したパスから文字列を読み込み格納
                string strStream = sr.ReadToEnd();
                //空白の文字列は格納しない
                string[] lines = strStream.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new int[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = int.Parse(readStrData[j]);
                    }
                }
            }


            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// TextAssetなどで直接読み込む文字列を指定する場合
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="textAsset">配列に読み込むTextAsset</param>
            public static void LoadMap(ref int[,] mapArray, UnityEngine.TextAsset textAsset)
            {
                //空白の文字列は格納しない
                string[] lines = textAsset.text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new int[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = Int32.Parse(readStrData[j]);
                    }
                }
            }



            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="dataPath">読み込む外部データのパス</param>
            public static void LoadMap(ref byte[,] mapArray, string path)
            {
                StreamReader sr = new StreamReader(path);
                //指定したパスから文字列を読み込み格納
                string strStream = sr.ReadToEnd();
                //空白の文字列は格納しない
                string[] lines = strStream.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new byte[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = byte.Parse(readStrData[j]);
                    }
                }
            }


            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// TextAssetなどで直接読み込む文字列を指定する場合
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="textAsset">配列に読み込むテキスト</param>
            public static void LoadMap(ref byte[,] mapArray, UnityEngine.TextAsset textAsset)
            {
                //空白の文字列は格納しない
                string[] lines = textAsset.text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new byte[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = Byte.Parse(readStrData[j]);
                    }
                }
            }






            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// Tで指定したenum型の配列に読み込む
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="dataPath">読み込む外部データのパス</param>
            public static void LoadMap<T>(ref T[,] mapArray, string path)
                where T : struct
            {
                StreamReader sr = new StreamReader(path);
                //指定したパスから文字列を読み込み格納
                string strStream = sr.ReadToEnd();
                //空白の文字列は格納しない
                string[] lines = strStream.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new T[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = (T)Enum.Parse(typeof(T), readStrData[j]);
                    }
                }
            }


            /// <summary>
            /// .csv形式のファイルから配列にデータを読み出す関数
            /// Tで指定したenum型の配列へ読み込む
            /// TextAssetなどで直接読み込む文字列を指定する場合
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="textAsset">配列に読み込むテキスト</param>
            public static void LoadMap<T>(ref T[,] mapArray, UnityEngine.TextAsset textAsset)
            {
                //空白の文字列は格納しない
                string[] lines = textAsset.text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };
                //行数設定
                int height = lines.Length;
                //列数設定
                int width = lines[0].Split(spliter, StringSplitOptions.RemoveEmptyEntries).Length;

                mapArray = new T[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        string[] readStrData = lines[i].Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                        mapArray[i, j] = (T)Enum.Parse(typeof(T), readStrData[j]);
                    }
                }
            }

            #endregion

            // 配列の要素をCSVデータに保存する関数
            #region
            /// <summary>
            /// 配列の要素を.csv形式で保存する関数
            /// </summary>
            /// <param name="mapArray">.csvファイルに書き出す要素</param>
            /// <param name="path">書き込み先のパス</param>
            public static void SaveMap(ref int[,] mapArray, string path)
            {
                // StreamWriterクラス　指定したパスが存在しない場合新しくファイルを作成する
                StreamWriter sw = new StreamWriter(path, false);
                int i, j;
                // csvに書き込む文字列
                string str = "";
                for (i = 0; i < mapArray.GetLength(0); i++)
                {
                    for (j = 0; j < mapArray.GetLength(1); j++)
                    {
                        str += mapArray[i, j].ToString() + ",";
                    }
                    // 行の終端の文字列の後には改行文字を入れる
                    if (j == mapArray.GetLength(1))
                    {
                        str += "\n";
                    }
                }
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }

            /// <summary>
            /// 配列の要素を.csv形式で保存する関数
            /// </summary>
            /// <param name="mapArray">.csvファイルに書き出す要素</param>
            /// <param name="path">書き込み先のパス</param>
            public static void SaveMap(ref byte[,] mapArray, string path)
            {
                // StreamWriterクラス　指定したパスが存在しない場合新しくファイルを作成する
                StreamWriter sw = new StreamWriter(path, false);
                int i, j;
                // csvに書き込む文字列
                string str = "";
                for (i = 0; i < mapArray.GetLength(0); i++)
                {
                    for (j = 0; j < mapArray.GetLength(1); j++)
                    {
                        str += mapArray[i, j].ToString() + ",";
                    }
                    // 行の終端の文字列の後には改行文字を入れる
                    if (j == mapArray.GetLength(1))
                    {
                        str += "\n";
                    }
                }
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }

            /// <summary>
            /// 配列の要素を.csv形式で保存する関数
            /// Tで指定した型の配列の要素をcsvファイルに保存する
            /// </summary>
            /// <param name="mapArray">.csvファイルに書き出す要素</param>
            /// <param name="path">書き込み先のパス</param>
            public static void SaveMap<T>(ref T[,] mapArray, string path)
                where T : struct
            {
                // StreamWriterクラス　指定したパスが存在しない場合新しくファイルを作成する
                StreamWriter sw = new StreamWriter(path, false);
                int i, j;
                // csvに書き込む文字列
                string str = "";
                for (i = 0; i < mapArray.GetLength(0); i++)
                {
                    for (j = 0; j < mapArray.GetLength(1); j++)
                    {
                        str += mapArray[i, j].ToString() + ",";
                    }
                    // 行の終端の文字列の後には改行文字を入れる
                    if (j == mapArray.GetLength(1))
                    {
                        str += "\n";
                    }
                }
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }
            #endregion

            // 文字列を指定した終端文字列を切り捨て返す
            private static string SubstrData(string data, string EOF)
            {
                int p;// 削除する文字列の位置
                      /*
                      for (int i = 0; i < ignore.Length; i++)
                      {
                          p = data.IndexOf(ignore[i]);
                          if (p < 0) p = data.Length;
                          data = data.Substring(0, p);
                      }*/

                p = data.IndexOf(EOF);
                if (p < 0) p = data.Length;
                data = data.Substring(0, p);
                return data;
            }

            // ignoreで指定された無視するcellであるかどうかを判定する
            private static bool IsIgnoreCell(string cell,string[] ignore)
            {
                for (int i = 0; i < ignore.Length; i++) {
                    if (cell[0].Equals(ignore) || cell.Equals(ignore)) {
                        return true;
                    }
                }
                return false;
            }

            /// 編集中
            public static List<List<string>> LoadMap(/*ref string[,] mapArray,*/ string text, string[] ignore, string EOF)
            {
                List<List<string>> outData = new List<List<string>>();

                // 終端文字列以下を切り捨てる
                text = SubstrData(text, EOF);

                //空白の文字列は格納しない
                string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };

                // カンマごとに区切ったデータを1行ずつリストに格納する
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cells = lines[i].Split(spliter);
                    List<string> line = new List<string>();
                    for (int j = 0; j < cells.Length; j++)
                    {
                        // 空のセルや無視する文字列、識別子は格納しない
                        if (!String.IsNullOrEmpty(cells[j]) && IsIgnoreCell(cells[j], ignore))
                        {
                            UnityEngine.Debug.Log("addcell" + cells[j]);
                            line.Add(cells[j]);
                        }
                    }
                    outData.Add(line);
                }

                return outData;
            }
            
        }

    }
}
