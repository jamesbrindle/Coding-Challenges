using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THGTests;

namespace Answer1_WordCount
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintWordsAndCountInDecendingOrder(GenerateSortedWordLists(GenerateContent(new CharacterReader())));

            Console.In.ReadLine();
        }

        /// <summary>
        /// Reads characters from the CharacterReader class (GetNextChar() method) and outputs a single string.
        /// </summary>
        private static String GenerateContent(ICharacterReader reader)
        {
            var content = string.Empty;

            while (true)
            {
                // the GetNextChar() method will inevitably break. I don't beleive that the method should be
                // coded that way however it will need to be called within a try-catch block.

                try
                {
                    content += reader.GetNextChar();
                }
                catch
                {
                    break;
                }
            }

            reader.Dispose();

            return content;
        }
        
        /// <summary>
        /// Group words into lists within lists.
        /// </summary>
        public static List<List<String>> GenerateSortedWordLists(string content)
        {
            var wordLists = new List<List<string>>();
            var words = new List<string>();

            var punctuation = content.Where(Char.IsPunctuation).Distinct().ToArray(); // commas, colons, full stops etc.
            var words_ienumerable = content.Split().Select(x => x.Trim(punctuation));

            // convert into List so we can easily use the 'sort' method. Also remove empty strings.
            foreach (var word in words_ienumerable)
            {
                if (word != string.Empty)
                {
                    words.Add(word);
                }
            }

            // alphabetise
            words.Sort();

            var duplicates = words
             .GroupBy(p => p)
             .Where(g => g.Count() > 1)
             .Select(g => g.Key);

            foreach (var duplicate in duplicates)
            {
                var wordList = new List<string>();

                foreach (var word in words)
                {
                    if (word == duplicate)
                    {
                        wordList.Add(word);
                    }
                }

                wordLists.Add(wordList);
            }

            var singles = words
             .GroupBy(p => p)
             .Where(g => g.Count() == 1)
             .Select(g => g.Key);

            foreach (var word in singles)
            {
                wordLists.Add(new List<string> { word });
            }

            return wordLists;
        }

        public static void PrintWordsAndCountInDecendingOrder(List<List<String>> wordLists)
        {
            IEnumerable<List<string>> result = wordLists.OrderByDescending(x => x.Count);

            foreach (var wordList in result)
            {
                try
                {
                    Console.Out.WriteLine(wordList[0] + " - " + wordList.Count());
                }
                catch (FormatException) 
                { 
                    // Do nothing
                }
                catch (IndexOutOfRangeException)
                {
                    // Do nothing
                }
            }
        }
    }
}
