using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace kakao
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //----------------Test
            string[] lineList = Tokenizer.readFile();

           
            V2 v2 = Tokenizer.mapXY(lineList);
            //Console.WriteLine("x: " + v2.x + "y: " + v2.y);
            //--------------
            List<List<char>> charMap = Tokenizer.getMap();

           
            List<List<char>> twoDimensionList = new List<List<char>>();
            for (int i = 0; i < v2.x; i++)
            {
                twoDimensionList.Add(new List<char>());
                for (int j = 0; j < v2.y; j++)
                {
                    if ((j <v2.y)&&(i<v2.x))
                    {
                         twoDimensionList[i].Add(charMap[j][i]);
                    }
                }
               
            }
            //-----------Test
            foreach (List<char> list in twoDimensionList)
            {
                foreach(char ca in list)
                {
                    Console.Write(ca);
                }
                Console.WriteLine();
            }
            //--------------
            List<V2> deleteList = new List<V2>();

            for(int i = 0;i< twoDimensionList.Count-1; i++)
            {
                for(int j = 0; j < v2.y-1;j++)
                {
                    char ca = twoDimensionList[i].ElementAt(j);
                    if(
                       (ca==twoDimensionList[i].ElementAt(j+1)) &&
                        (ca== twoDimensionList[i+1].ElementAt(j))&&
                       (ca== twoDimensionList[i+1].ElementAt(j+1))
                      )
                    {
                         V2 deleteV;
                        deleteV.x = j;
                        deleteV.y = i;
                        deleteList.Add(deleteV);
                        deleteV.x = j+1;
                        deleteV.y = i;
                        deleteList.Add(deleteV);
                        deleteV.x = j ;
                        deleteV.y = i+1;
                        deleteList.Add(deleteV);
                        deleteV.x = j+1;
                        deleteV.y = i + 1;
                        deleteList.Add(deleteV);
                    }

                }
            
            }
            
            foreach(V2 vec in deleteList)
            {
                Console.WriteLine("x: " + vec.x + " y:" + vec.y);
            }

            List<V2> noSameDeleteList = new List<V2>();

            for (int i = 0; i < deleteList.Count; i++)
            {
                if (!noSameDeleteList.Contains(deleteList.ElementAt(i)))
                {
                    noSameDeleteList.Add(deleteList.ElementAt(i));
                }
            }
            Console.WriteLine();
            foreach (V2 vec in noSameDeleteList)
            {
                Console.WriteLine("x: " + vec.x + " y:" + vec.y);
            }

            for(int i = 0; i < twoDimensionList.Count; i++)
            {
                for(int j = twoDimensionList[i].Count; j > 0; j--)
                {
                    V2 vec2;
                    vec2.x = j;
                    vec2.y = i;
                    if ((noSameDeleteList.Contains(vec2)))
                    {
                        twoDimensionList[i].RemoveAt(j);
                    }
                }
            }

            foreach (List<char> list in twoDimensionList)
            {
                foreach (char ca in list)
                {
                    Console.Write(ca);
                }
                Console.WriteLine();
            }

        }
    }
}
