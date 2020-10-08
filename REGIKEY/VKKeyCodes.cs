using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace REGIKEY
{
    class VKKeyCodes
    {
        public struct KeyInfo
        {
            public KeyInfo(String name, int keyValue, String description)
            {
                this.name = name;
                this.keyValue = keyValue;
                this.description = description;
            }
            public String name;
            public int keyValue;
            public String description;
        }

        public List<KeyInfo> mKeys = new List<KeyInfo>();

        public VKKeyCodes()
        {
            // https://msdn.microsoft.com/ko-kr/library/windows/desktop/dd375731(v=vs.85).aspx

            mKeys.Add(new KeyInfo("VK_LBUTTON", 0x01, "Left mouse button"));
            mKeys.Add(new KeyInfo("VK_RBUTTON", 0x02, "Right mouse button"));
            mKeys.Add(new KeyInfo("VK_CANCEL", 0x03, "Control-break processing"));
            mKeys.Add(new KeyInfo("VK_MBUTTON", 0x04, "Middle mouse button (three-button mouse)"));
            mKeys.Add(new KeyInfo("VK_XBUTTON1", 0x05, "X1 mouse button"));
            mKeys.Add(new KeyInfo("VK_XBUTTON2", 0x06, "X2 mouse button"));
            mKeys.Add(new KeyInfo("VK_BACK", 0x08, "BACKSPACE"));
            mKeys.Add(new KeyInfo("VK_TAB", 0x09, "TAB"));
            mKeys.Add(new KeyInfo("VK_CLEAR", 0x0C, "CLEAR"));
            mKeys.Add(new KeyInfo("VK_RETURN", 0x0D, "ENTER"));
            mKeys.Add(new KeyInfo("VK_SHIFT", 0x10, "SHIFT"));
            mKeys.Add(new KeyInfo("VK_CONTROL", 0x11, "CTRL"));
            mKeys.Add(new KeyInfo("VK_MENU", 0x12, "ALT"));
            mKeys.Add(new KeyInfo("VK_PAUSE", 0x13, "PAUSE"));
            mKeys.Add(new KeyInfo("VK_CAPITAL", 0x14, "CAPS LOCK"));

            // Hangul
            mKeys.Add(new KeyInfo("VK_HANGUL", 0x15, "IME Hangul"));
            mKeys.Add(new KeyInfo("VK_JUNJA", 0x17, "IME Junja"));
            mKeys.Add(new KeyInfo("VK_FINAL", 0x18, "IME final"));
            mKeys.Add(new KeyInfo("VK_HANJA", 0x19, "IME Hanja"));

            mKeys.Add(new KeyInfo("VK_ESCAPE", 0x1B, "ESC key"));
            mKeys.Add(new KeyInfo("VK_CONVERT", 0x1C, "IME convert"));
            mKeys.Add(new KeyInfo("VK_NONCONVERT", 0x1D, "IME nonconvert"));
            mKeys.Add(new KeyInfo("VK_ACCEPT", 0x1E, "IME accept"));
            mKeys.Add(new KeyInfo("VK_MODECHANGE", 0x1F, "IME mode change request"));
            mKeys.Add(new KeyInfo("VK_SPACE", 0x20, "SPACEBAR"));
            mKeys.Add(new KeyInfo("VK_PRIOR", 0x21, "PAGE UP"));
            mKeys.Add(new KeyInfo("VK_NEXT", 0x22, "PAGE DOWN"));
            mKeys.Add(new KeyInfo("VK_END", 0x23, "END"));
            mKeys.Add(new KeyInfo("VK_HOME", 0x24, "HOME"));
            mKeys.Add(new KeyInfo("VK_LEFT", 0x25, "LEFT ARROW"));
            mKeys.Add(new KeyInfo("VK_UP", 0x26, "UP ARROW"));
            mKeys.Add(new KeyInfo("VK_RIGHT", 0x27, "RIGHT ARROW"));
            mKeys.Add(new KeyInfo("VK_DOWN", 0x28, "DOWN ARROW"));
            mKeys.Add(new KeyInfo("VK_SELECT", 0x29, "SELECT"));
            mKeys.Add(new KeyInfo("VK_PRINT", 0x2A, "PRINT"));
            mKeys.Add(new KeyInfo("VK_EXECUTE", 0x2B, "EXECUTE"));
            mKeys.Add(new KeyInfo("VK_SNAPSHOT", 0x2C, "PRINT SCREEN"));
            mKeys.Add(new KeyInfo("VK_INSERT", 0x2D, "INS"));
            mKeys.Add(new KeyInfo("VK_DELETE", 0x2E, "DEL"));
            mKeys.Add(new KeyInfo("VK_HELP", 0x2F, "HELP"));

            // Number
            for (int i = 0x30; i < 0x3A; i++)
            {
                String name = String.Format("VK_{0}", i);
                String description = String.Format("{0}", i);
                mKeys.Add(new KeyInfo(name, i, description));
            }

            // Alphabet
            for (int i = 0x41; i < 0x5B; i++)
            {
                String name = "VK_" + ((Char)i).ToString();
                String description = "Alphabet " + ((Char)i).ToString();
                mKeys.Add(new KeyInfo(name, i, description));
            }

            mKeys.Add(new KeyInfo("VK_LWIN", 0x5B, "Left Windows key"));
            mKeys.Add(new KeyInfo("VK_RWIN", 0x5C, "Right Windows key"));
            mKeys.Add(new KeyInfo("VK_APPS", 0x5D, "Applications key"));
            mKeys.Add(new KeyInfo("VK_SLEEP", 0x5F, "Computer Sleep"));

            mKeys.Add(new KeyInfo("VK_NUMPAD0", 0x60, "Num 0"));
            mKeys.Add(new KeyInfo("VK_NUMPAD1", 0x61, "Num 1"));
            mKeys.Add(new KeyInfo("VK_NUMPAD2", 0x62, "Num 2"));
            mKeys.Add(new KeyInfo("VK_NUMPAD3", 0x63, "Num 3"));
            mKeys.Add(new KeyInfo("VK_NUMPAD4", 0x64, "Num 4"));
            mKeys.Add(new KeyInfo("VK_NUMPAD5", 0x65, "Num 5"));
            mKeys.Add(new KeyInfo("VK_NUMPAD6", 0x66, "Num 6"));
            mKeys.Add(new KeyInfo("VK_NUMPAD7", 0x67, "Num 7"));
            mKeys.Add(new KeyInfo("VK_NUMPAD8", 0x68, "Num 8"));
            mKeys.Add(new KeyInfo("VK_NUMPAD9", 0x69, "Num 9"));

            mKeys.Add(new KeyInfo("VK_MULTIPLY", 0x6A, "*"));
            mKeys.Add(new KeyInfo("VK_ADD", 0x6B, "+"));
            mKeys.Add(new KeyInfo("VK_SEPARATOR", 0x6C, "|"));
            mKeys.Add(new KeyInfo("VK_SUBTRACT", 0x6D, "-"));
            mKeys.Add(new KeyInfo("VK_DECIMAL", 0x6E, "."));
            mKeys.Add(new KeyInfo("VK_DIVIDE", 0x6F, "/"));

            // Function keys
            for (int i = 0x70; i < 0x88; i++)
            {
                int F_NUMBER = i - 0x6F;
                String name = String.Format("VK_F{0}", F_NUMBER);
                String description = String.Format("F{0}", F_NUMBER);
                mKeys.Add(new KeyInfo(name, i, description));
            }

            mKeys.Add(new KeyInfo("VK_NUMLOCK", 0x90, "NUM LOCK"));
            mKeys.Add(new KeyInfo("VK_SCROLL", 0x91, "SCROLL LOCK"));

            mKeys.Add(new KeyInfo("VK_LSHIFT", 0xA0, "Left SHIFT"));
            mKeys.Add(new KeyInfo("VK_RSHIFT", 0xA1, "Right SHIFT"));
            mKeys.Add(new KeyInfo("VK_LCONTROL", 0xA2, "Left CONTROL"));
            mKeys.Add(new KeyInfo("VK_RCONTROL", 0xA3, "Right CONTROL"));
            mKeys.Add(new KeyInfo("VK_LMENU", 0xA4, "Left MENU"));
            mKeys.Add(new KeyInfo("VK_RMENU", 0xA5, "Right MENU"));

            mKeys.Add(new KeyInfo("VK_BROWSER_BACK", 0xA6, "Browser Back"));
            mKeys.Add(new KeyInfo("VK_BROWSER_FORWARD", 0xA7, "Browser Forward"));
            mKeys.Add(new KeyInfo("VK_BROWSER_REFRESH", 0xA8, "Browser Refresh"));
            mKeys.Add(new KeyInfo("VK_BROWSER_STOP", 0xA9, "Browser Stop"));
            mKeys.Add(new KeyInfo("VK_BROWSER_SEARCH", 0xAA, "Browser Search"));
            mKeys.Add(new KeyInfo("VK_BROWSER_FAVORITES", 0xAB, "Browser Favorites"));
            mKeys.Add(new KeyInfo("VK_BROWSER_HOME", 0xAC, "Browser Start and Home"));
            mKeys.Add(new KeyInfo("VK_VOLUME_MUTE", 0xAD, "Volume Mute"));
            mKeys.Add(new KeyInfo("VK_VOLUME_DOWN", 0xAE, "Volume Down"));
            mKeys.Add(new KeyInfo("VK_VOLUME_UP", 0xAF, "Volume Up"));
            mKeys.Add(new KeyInfo("VK_MEDIA_NEXT_TRACK", 0xB0, "Next Track"));
            mKeys.Add(new KeyInfo("VK_MEDIA_PREV_TRACK", 0xB1, "Previous Track"));
            mKeys.Add(new KeyInfo("VK_MEDIA_STOP", 0xB2, "Stop Media"));
            mKeys.Add(new KeyInfo("VK_MEDIA_PLAY_PAUSE", 0xB3, "Play/Pause Media"));
            mKeys.Add(new KeyInfo("VK_LAUNCH_MAIL", 0xB4, "Start Mail"));
            mKeys.Add(new KeyInfo("VK_LAUNCH_MEDIA_SELECT", 0xB5, "Select Media"));
            mKeys.Add(new KeyInfo("VK_LAUNCH_APP1", 0xB6, "Start Application 1"));
            mKeys.Add(new KeyInfo("VK_LAUNCH_APP2", 0xB7, "Start Application 2"));

            mKeys.Add(new KeyInfo("VK_OEM_1", 0xBA, "Used for miscellaneous characters"));
            mKeys.Add(new KeyInfo("VK_OEM_PLUS", 0xBB, "For any country/region, the '+' key"));
            mKeys.Add(new KeyInfo("VK_OEM_COMMA", 0xBC, "For any country/region, the ',' key"));
            mKeys.Add(new KeyInfo("VK_OEM_MINUS", 0xBD, "For any country/region, the '-' key"));
            mKeys.Add(new KeyInfo("VK_OEM_PERIOD", 0xBE, "For any country/region, the '.' key"));
            mKeys.Add(new KeyInfo("VK_OEM_2", 0xBF, "?"));
            mKeys.Add(new KeyInfo("VK_OEM_3", 0xC0, "~"));
            mKeys.Add(new KeyInfo("VK_OEM_4", 0xDB, "[{"));
            mKeys.Add(new KeyInfo("VK_OEM_5", 0xDC, "\\|"));
            mKeys.Add(new KeyInfo("VK_OEM_6", 0xDD, "]}"));
            mKeys.Add(new KeyInfo("VK_OEM_7", 0xDE, "\"\'"));
            mKeys.Add(new KeyInfo("VK_OEM_8", 0xDF, "Used for miscellaneous characters"));
            mKeys.Add(new KeyInfo("VK_OEM_102", 0xE2,
                "Either the angle bracket key or the backslash key on the RT 102-key keyboard"));

            mKeys.Add(new KeyInfo("VK_PROCESSKEY", 0xE5, "IME PROCESS key"));
            mKeys.Add(new KeyInfo("VK_PACKET", 0xE7, "VK_PACKET"));
            mKeys.Add(new KeyInfo("VK_ATTN", 0xF6, "Attn key"));
            mKeys.Add(new KeyInfo("VK_CRSEL", 0xF7, "CrSel key"));
            mKeys.Add(new KeyInfo("VK_EXSEL", 0xF8, "ExSel key"));
            mKeys.Add(new KeyInfo("VK_EREOF", 0xF9, "Erase EOF key"));
            mKeys.Add(new KeyInfo("VK_PLAY", 0xFA, "Play key"));
            mKeys.Add(new KeyInfo("VK_ZOOM", 0xFB, "Zoom key"));
            mKeys.Add(new KeyInfo("VK_NONAME", 0xFC, "Reserved"));
            mKeys.Add(new KeyInfo("VK_PA1", 0xFD, "PA1 key"));
            mKeys.Add(new KeyInfo("VK_OEM_CLEAR", 0xFE, "Clear key"));
        }

        public int getKeyValue(String name)
        {
            if (name == "")
                return -1;

            if (name.Contains("0X"))
            {
                int value = (int)new Int32Converter().ConvertFromString(name);
                return value;
            }
            foreach(KeyInfo key in mKeys)
            {
                if (key.name == name)
                    return key.keyValue;
            }
            return -1;
        }

        public String getKeyName(int value)
        {
            foreach (KeyInfo key in mKeys)
            {
                if (key.keyValue == value)
                    return key.name;
            }
            return "Not found";
        }

        public String getKeyDesc(int value)
        {
            foreach (KeyInfo key in mKeys)
            {
                if (key.keyValue == value)
                    return key.description;
            }
            return "Not found";
        }
    }
}
