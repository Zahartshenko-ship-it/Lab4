using System.Collections.Generic;

namespace Lab4
{
    internal class ListTask
    {
        private static int _processedCount;

        public static void RemoveElementAfterTarget(
            List<int> list, int targetElement)
        {
            _processedCount = 0;
            int nextIndex = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == targetElement)
                {
                    nextIndex = i + 1;

                    if (nextIndex < list.Count)
                    {
                        if (list[nextIndex] != targetElement)
                        {
                            list.RemoveAt(nextIndex);
                            _processedCount++;
                        }
                    }
                }
            }
        }

        public static bool HasElementEqualToNextCircular(
            LinkedList<int> list)
        {
            if (list == null || list.Count == 0)
            {
                return false;
            }

            _processedCount = 0;

            LinkedListNode<int>? currentNode = list.First;

            while (currentNode != null)
            {
                LinkedListNode<int>? nextNode;

                if (currentNode.Next != null)
                {
                    nextNode = currentNode.Next;
                }
                else
                {
                    nextNode = list.First;
                }

                _processedCount++;

                if (currentNode.Value == nextNode!.Value)
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public static void AnalyzeTourismChoices(
            List<HashSet<int>> touristPreferences, 
            int totalCountriesCount, 
            out HashSet<int> visitedByAll, 
            out HashSet<int> visitedBySome, 
            out HashSet<int> visitedByNone)
        {
            if (touristPreferences == null || touristPreferences.Count == 0)
            {
                visitedByAll = new HashSet<int>();
                visitedBySome = new HashSet<int>();
                visitedByNone = new HashSet<int>();
                return;
            }

            visitedByAll = new HashSet<int>(touristPreferences[0]);
            for (int i = 1; i < touristPreferences.Count; i++)
            {
                visitedByAll.IntersectWith(touristPreferences[i]);
            }

            visitedBySome = new HashSet<int>();
            for (int i = 0; i < touristPreferences.Count; i++)
            {
                visitedBySome.UnionWith(touristPreferences[i]);
            }

            HashSet<int> allPossibleCountries = new HashSet<int>();
            for (int i = 1; i <= 100; i++)
            {
                allPossibleCountries.Add(i);
            }

            visitedByNone = new HashSet<int>(allPossibleCountries);
            
            visitedByNone.ExceptWith(visitedBySome);
        }

        public static void AnalyzeTextGluhie(
            string text, 
            out SortedSet<int> resultChars)
        {
            resultChars = new SortedSet<int>();

            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            HashSet<char> gluhieConsonants = new HashSet<char>()
            {
                'п', 'ф', 'с', 'т', 'ш', 'к', 'ц', 'ч', 'щ', 'х',
                'П', 'Ф', 'С', 'Т', 'Ш', 'К', 'Ц', 'Ч', 'Щ', 'Х'
            };

            string[] words = text.Split(
                new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '"', '(', ')' }, 
                StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, HashSet<string>> letterWordCounts = 
                new Dictionary<char, HashSet<string>>();

            foreach (char c in gluhieConsonants)
            {
                letterWordCounts[c] = new HashSet<string>();
            }

            foreach (string word in words)
            {
                HashSet<char> uniqueCharsInWord = new HashSet<char>();
                foreach (char c in word)
                {
                    char lowerC = char.ToLower(c);
                    if (gluhieConsonants.Contains(lowerC) || gluhieConsonants.Contains(c))
                    {
                        uniqueCharsInWord.Add(char.ToLower(c));
                    }
                }

                foreach (char c in uniqueCharsInWord)
                {
                    if (letterWordCounts.ContainsKey(c))
                    {
                        letterWordCounts[c].Add(word);
                    }
                }
            }

            foreach (var pair in letterWordCounts)
            {
                int wordCount = pair.Value.Count;
                if (wordCount != 1)
                {
                    resultChars.Add(pair.Key);
                }
            }
        }

        public static void AnalyzeApplicants(
            string[] inputLines, 
            out SortedDictionary<string, string> failedApplicants)
        {
            failedApplicants = new SortedDictionary<string, string>();

            if (inputLines == null || inputLines.Length == 0)
            {
                return;
            }

            string surname;
            string firstName;

            foreach (string line in inputLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(
                    new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                surname = parts[0];
                firstName = parts[1];

                int.TryParse(parts[2], out int score1);
                int.TryParse(parts[3], out int score2);

                if (score1 < 30 || score2 < 30)
                {
                    string key = surname + " " + firstName;

                    if (!failedApplicants.ContainsKey(key))
                    {
                        failedApplicants.Add(key, key);
                    }
                }
            }
        }
    }
}