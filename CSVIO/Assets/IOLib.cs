using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

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
            /// Tで指定したenum型の配列に読み込む
            /// </summary>
            /// <param name="mapArray">データを格納するための配列</param>
            /// <param name="dataPath">読み込む外部データのパス</param>
            public static void LoadMap<T>(ref T[,] mapArray, string path, List<string> ignore, string EOF = "")
                where T : struct
            {
                StreamReader sr = new StreamReader(path,Encoding.ASCII);
                //指定したパスから文字列を読み込み格納
                string strStream = sr.ReadToEnd();


                // 終端文字列以下を切り捨てる
                if (!string.IsNullOrEmpty(EOF))
                    strStream = SubstrData(strStream, EOF);
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
                        if (!String.IsNullOrEmpty(readStrData[j]) && !IsIgnoreCell(readStrData[j], ignore))
                        {
                            mapArray[i, j] = (T)Enum.Parse(typeof(T), readStrData[j]);
                        }
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
            public static void LoadMap<T>(ref T[,] mapArray, UnityEngine.TextAsset textAsset, List<string> ignore, string EOF = "") 
                where T : struct
            {
                string text = LoadTextAsset(textAsset);
                //空白の文字列は格納しない
                string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

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
                        // 空のセルや無視する文字列、識別子は格納しない
                        if (!String.IsNullOrEmpty(readStrData[j]) && !IsIgnoreCell(readStrData[j], ignore))
                        {
                            mapArray[i, j] = (T)Enum.Parse(typeof(T), readStrData[j]);
                        }
                    }
                }
            }
            /*
            public static void LoadMap(ref List<List<string>> outData, string text, List<string> ignore, string EOF)
            {
                outData = new List<List<string>>();

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
                        if (!String.IsNullOrEmpty(cells[j]) && !IsIgnoreCell(cells[j], ignore))
                        {
                            line.Add(cells[j]);
                        }
                    }
                    // 空列は飛ばす
                    if (line.Count > 0)
                        outData.Add(line);
                }
            }
            */
            /// <summary>
            /// 文字列をTで指定した型に変換して格納
            /// </summary>
            /// <typeparam name="T">変換する型</typeparam>
            /// <param name="outData">読み込み先の配列</param>
            /// <param name="text">読み込む文字列</param>
            /// <param name="ignore">無視する文字列のリスト</param>
            /// <param name="EOF">ファイル終端識別子 初期値はEmpty</param>
            public static void LoadMap<T>(ref List<List<T>> outData, string path, List<string> ignore, string EOF = "")
            {
                Type type = typeof(T);
                UnityEngine.Debug.Log(type);
                outData = new List<List<T>>();
                
                StreamReader sr = new StreamReader(path, Encoding.ASCII);
                //指定したパスから文字列を読み込み格納
                string text = sr.ReadToEnd();

                // 終端文字列以下を切り捨てる
                if (!string.IsNullOrEmpty(EOF))
                    text = SubstrData(text, EOF);

                //空白の文字列は格納しない
                string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };

                // カンマごとに区切ったデータを1行ずつリストに格納する
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cells = lines[i].Split(spliter);
                    List<T> line = new List<T>();
                    for (int j = 0; j < cells.Length; j++)
                    {
                        // 空のセルや無視する文字列、識別子は格納しない
                        if (!String.IsNullOrEmpty(cells[j]) && !IsIgnoreCell(cells[j], ignore))
                        {
                            T cell = Convert<T>(cells[j]);
                            line.Add(cell);
                        }
                    }
                    // 空列は飛ばす
                    if (line.Count > 0)
                        outData.Add(line);
                }
            }
            /// <summary>
            /// 文字列をTで指定した型に変換して格納
            /// </summary>
            /// <typeparam name="T">変換する型</typeparam>
            /// <param name="outData">読み込み先の配列</param>
            /// <param name="textAsset">読み込むTextAsset</param>
            /// <param name="ignore">無視する文字列のリスト</param>
            /// <param name="EOF">ファイル終端識別子 初期値はEmpty</param>
            public static void LoadMap<T>(ref List<List<T>> outData, UnityEngine.TextAsset textAsset, List<string> ignore, string EOF = "")
            {
                Type type = typeof(T);
                UnityEngine.Debug.Log(type);
                outData = new List<List<T>>();
                // 終端文字列以下を切り捨てる
                string text = LoadTextAsset(textAsset); // ASCII文字コードのエンコードして読み込むこと
                if(!string.IsNullOrEmpty(EOF))
                    text = SubstrData(text, EOF);

                //空白の文字列は格納しない
                string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //カンマ分けの準備(区分けする文字を設定する)
                char[] spliter = new char[1] { ',' };

                // カンマごとに区切ったデータを1行ずつリストに格納する
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cells = lines[i].Split(spliter);
                    List<T> line = new List<T>();
                    for (int j = 0; j < cells.Length; j++)
                    {
                        // 空のセルや無視する文字列、識別子は格納しない
                        if (!String.IsNullOrEmpty(cells[j]) && !IsIgnoreCell(cells[j], ignore))
                        {
                            T cell = Convert<T>(cells[j]);
                            line.Add(cell);
                        }
                    }
                    // 空列は飛ばす
                    if (line.Count > 0)
                        outData.Add(line);
                }
            }

            #endregion

            // 配列の要素をCSVデータに保存する関数
            #region
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

            public static void SaveMap<T>(ref List<List<T>> mapArray, string path)
                 where T : struct
            {
                // StreamWriterクラス　指定したパスが存在しない場合新しくファイルを作成する
                StreamWriter sw = new StreamWriter(path, false);
                int i, j;
                // csvに書き込む文字列
                string str = "";
                for (i = 0; i < mapArray.Count; i++)
                {
                    List<T> line = mapArray[i];
                    for (j = 0; j < line.Count; j++)
                    {
                        str += line[j].ToString() + ",";
                    }
                    str += '\n';
                }
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }
            #endregion

            // 文字列操作処理系統
            #region
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
            private static bool IsIgnoreCell(string cell, string[] ignore)
            {
                int p;
                for (int i = 0; i < ignore.Length; i++)
                {
                    p = cell.IndexOf(ignore[i]);
                    // cellの文字列の先頭にignoreと一致するものがあるかどうか判定
                    if (p == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            private static bool IsIgnoreCell(string cell, List<string> ignore)
            {
                int p;
                for (int i = 0; i < ignore.Count; i++)
                {
                    p = cell.IndexOf(ignore[i]);
                    // cellの文字列の先頭にignoreと一致するものがあるかどうか判定
                    if (p == 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// TextAssetから文字列を読み込む関数
            /// </summary>
            /// <param name="textAsset"></param>
            /// <returns>ASCII形式でエンコードされた文字列を返す</returns>
            private static string LoadTextAsset(UnityEngine.TextAsset textAsset)
            {
                // バイト列でまず読み込み
                byte[] bytes = textAsset.bytes;
                return System.Text.Encoding.ASCII.GetString(bytes);
            }

            // 文字列をTで指定した型にキャストする
            private static T Convert<T>(string str)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                Type type = typeof(T);
                try
                {
                    return (T)converter.ConvertFromString(str);
                }
                catch
                {
                    throw new NotSupportedException(type + " is not suported.");
                }
            }
            #endregion

            
        }

    }
}
