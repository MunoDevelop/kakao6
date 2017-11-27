using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    
namespace Tool
{
    struct V2
    {
        public int x;
        public int y;
        
    }

    internal class Tokenizer
    {
        public static string[] readFile()
        {
                string[]  lineList = File.ReadAllLines(@"Input.txt");
             
            return lineList;
        }
        public static V2 mapXY(string[] lineList)
        {
            V2 v2;
            v2.y =  lineList.Length;
            v2.x = lineList[0].Length;
            return v2;
        }
        public static List<List<char>> getMap()
        {
            string[] lineList = readFile();
            List<List<char>> charMap = new List<List<char>>();
            
            foreach (string line in lineList)
            {
                charMap.Add(line.ToList());
            }
            return charMap;
        }

    }
}
