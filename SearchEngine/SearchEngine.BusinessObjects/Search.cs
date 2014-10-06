using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SearchEngine.BusinessObjects
{
    public class SearchEntity
    {
        public string Name { get; set; }
        public string Result { get; set; }
    }

    public class Search
    {
        /// <summary>
        ///  Searches for the specified keyword / sentence throughout the database and returns
        ///  a search entity of where the source came from the surrounding sentences where the keyword was found
        ///  the index to where to start the search from in the txt file uploaded is random and the results return are capped
        /// </summary>
        public static List<SearchEntity> SearchDataBase(string keyWord, DataCollection col)
        {
            var seList = new List<SearchEntity>();           

            foreach (DataEntity entity in col.Entities)
            {
                var sb = new StringBuilder();

                string[] sentences = Regex.Split(entity.Content, Regex.Escape(".") + " ");

                int index = new Random().Next(0, sentences.Length);
                bool foundMatch = false;

                while (!foundMatch && index < sentences.Length)
                {
                    if (sentences[index].Contains(keyWord))
                    {
                        var se = new SearchEntity();

                        se.Name = entity.EntityName;

                        //surrounding sentences
                        if ((index - 2) >= 0) sb.Append(sentences[index - 2]);
                        if ((index - 1) >= 0) sb.Append(sentences[index - 1]);
                        sb.Append(sentences[index]);
                        if ((index + 1) <= sentences.Length) sb.Append(sentences[index + 1]);
                        if ((index - 2) <= sentences.Length) sb.Append(sentences[index + 2]);

                        se.Result = sb.ToString();

                        seList.Add(se);

                        foundMatch = true;
                    }
                    else
                        index++;                            
                }     
            }

            return seList;
        }
    }
}
