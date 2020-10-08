using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace REGIKEY
{
    class KeyInfo
    {
        public KeyInfo() {}

        public String firstKey;
        public String secondKey;
        public String thirdKey;
        public String matchedKey;
    }

    class INIFileParser
    {
        public List<KeyInfo> mKeys = new List<KeyInfo>();
        public VKKeyCodes keyInfos = new VKKeyCodes();
        public List<int[]> mVKValues = new List<int[]>();

        public INIFileParser() {}

        public void Parse(String text)
        {
            mKeys.Clear();

            string pattern = @"(\s*\w*\s*)(\+?)(\s*\w*\s*)(\+?)(\s*\w*\s*)(->)(\s*\w*\s*)";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                KeyInfo k = new KeyInfo();
                k.firstKey = match.Groups[1].Value.ToUpper().Trim();
                k.secondKey = match.Groups[3].Value.ToUpper().Trim();
                k.thirdKey = match.Groups[5].Value.ToUpper().Trim();
                k.matchedKey = match.Groups[7].Value.ToUpper().Trim();
                mKeys.Add(k);
            }
        }

        public void MakeHandler()
        {
            foreach (KeyInfo key in mKeys)
            {
                int[] KeyHexaValue = new int[4];
                KeyHexaValue[0] = keyInfos.getKeyValue(key.firstKey);
                KeyHexaValue[1] = keyInfos.getKeyValue(key.secondKey);
                KeyHexaValue[2] = keyInfos.getKeyValue(key.thirdKey);
                KeyHexaValue[3] = keyInfos.getKeyValue(key.matchedKey);
                mVKValues.Add(KeyHexaValue);
            }
        }
    }
}
