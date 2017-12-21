using System;
using System.Collections.Generic;


namespace Dictionary
{
    class ClassDict
    {
        private Dictionary<string, List<string>> _English = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> _Russian = new Dictionary<string, List<string>>();

        public ClassDict(string Engl = "", string Rus = "")
        {
            Engl = Engl.Trim().ToLower();
            Rus = Rus.Trim().ToLower();
            _English.Add(Engl, new List<string> {Rus});
            _Russian.Add(Rus, new List<string> {Engl});
        }

        public ClassDict(string Engl, List<string> Rus)
        {
            
            Engl = Engl.Trim().ToLower();
            List<string> RusParse = new List<string>();
            Rus.ForEach((string name) => RusParse.Add(name.Trim().ToLower()));

            _English.Add(Engl, RusParse);
            foreach (string word in Rus)
                _Russian.Add(word.Trim().ToLower(), new List<string> { Engl });
            
        }

        public void Add(string word, List<string> A)
        {
            word = word.Trim().ToLower();
            List<string> RusParse = new List<string>();
            A.ForEach((string name) => RusParse.Add(name.Trim().ToLower()));

            if (_English.ContainsKey(word))
            {
                foreach (string ch in RusParse)
                    if (!(_English[word].Contains(ch)))
                        _English[word].Add(ch);
            }
            else
                _English.Add(word, RusParse);
            
            foreach (string chr in RusParse)
                if (_Russian.ContainsKey(chr))
                    _Russian[chr].Add(word);
                else
                    _Russian.Add(chr, new List<string> { word });
        }

        public void Add(string word, string a)
        {
            a = a.Trim().ToLower();
            word = word.Trim().ToLower();

            if (_English.ContainsKey(word))
            {
                if (!(_English[word].Contains(a)))
                    _English[word].Add(a);
                
            }
            else
                _English.Add(word, new List<string> { a });

            if (_Russian.ContainsKey(a))
            {
                if (!(_Russian[a].Contains(word)))
                    _Russian[a].Add(word);
            }
            else
                _Russian.Add(a, new List<string> { word });
        }

        public List<string> GetTranslate(string word)
        {
            if (_Russian.ContainsKey(word))
                return _Russian[word];
            if (_English.ContainsKey(word))
                return _English[word];
            return null;
        }
    }
}
