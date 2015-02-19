using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using THGTests;

namespace Answer2_Threading
{
    /// <summary>
    /// This class also utilises (re-uses) some methods created in the project 'Answer1_WordCount'
    /// </summary>
    class Program
    {
        private static long m_timerInterval = 10 * 1000; // 10 seconds
        private static List<String> m_contentLists; // seperate list of different contents from different RandomCharacterReaders

        private static volatile string m_allContent = string.Empty;        

        private static RandomCharacterReader[] m_readers = 
            {
                new RandomCharacterReader(),
                new RandomCharacterReader(),
                new RandomCharacterReader(),
                new RandomCharacterReader()
            };

        static void Main(string[] args)
        {
            m_contentLists = new List<string>();

            new Timer(TimerTick, null, 0, m_timerInterval);

            Console.In.ReadLine();
        }

        private static void TimerTick(Object input)
        {
            ProcessMultipleReadersInParallel();

            m_allContent += String.Join(String.Empty, m_contentLists.ToArray());

            // Decided to clear console and start afresh for the next timer tick.
            Console.Clear();

            var wordLists = Answer1_WordCount.Program.GenerateSortedWordLists(m_allContent);
            Answer1_WordCount.Program.PrintWordsAndCountInDecendingOrder(wordLists);
        }

        private static void ProcessMultipleReadersInParallel()
        {
            var readerProcessThreads = new List<Thread>();

            for (int i = 0; i < m_readers.Count(); i++)
            {
                // create position for the content for each RandomCharacterReader
                m_contentLists.Add("");

                readerProcessThreads.Add(new Thread(new ParameterizedThreadStart(GenerateContent)));
                readerProcessThreads[i].IsBackground = true;

                readerProcessThreads[i].Start(new object[] { m_readers[i], i });
            }
        }

        /// <summary>
        /// Reads characters from a RandomCharacterReader and inserts it into a specified content list.
        /// </summary>
        private static void GenerateContent(Object input)
        {
            object[] parameters = (object[])input;

            var reader = (ICharacterReader)parameters[0];
            var contentListIndex = (int)parameters[1];

            var content = string.Empty;

            while (true)
            {
                try
                {
                    m_contentLists[contentListIndex] += reader.GetNextChar();
                }
                catch
                {
                    // Do nothing
                }
            }
        }
    }
}
