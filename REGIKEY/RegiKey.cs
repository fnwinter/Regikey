using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;

using System.Runtime.InteropServices;

namespace REGIKEY
{
    public partial class RegiKey : Form
    {
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItem_show;
        private System.Windows.Forms.MenuItem menuItem_exit;
        private System.Windows.Forms.NotifyIcon notifyIcon;

        static INIFileParser parser = new INIFileParser();
        private VKKeyCodes keyCode = new VKKeyCodes();

        static string currnet_path;
        static string ini_file_path;
        static string log_file_path;
        static StreamWriter log_file;

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const uint keyDown = 0x00;
        const uint keyUp = 0x02;

        public static int currentPressedKey = -1;
        public static int[] PressedKey = { -1, -1, -1 };
        public static uint currentMatchKey = 0x00;
        public static bool matchKeyPressed = false;

        private LowLevelKeyboardProc _proc = hookProc;
        private static IntPtr hhook = IntPtr.Zero;

        // ... { GLOBAL HOOK }
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public RegiKey()
        {
            currnet_path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            ini_file_path = Path.Combine(currnet_path, "regikey.ini");
            log_file_path = Path.Combine(currnet_path, "regikey.log");

            log_file = new StreamWriter(log_file_path);

            InitializeComponent();

            FillComboItems(ref comboBox1);
            FillComboItems(ref comboBox2);
            FillComboItems(ref comboBox3);
            FillComboItems(ref comboBox4);
            FillComboItems(ref comboBox5);
            FillComboItems(ref comboBox6);
            FillComboItems(ref comboBox7);
            FillComboItems(ref comboBox8);
            FillComboItems(ref comboBox9);
            FillComboItems(ref comboBox10);
            FillComboItems(ref comboBox11);
            FillComboItems(ref comboBox12);

            LoadINIFile();
            Apply();
            CreateNotifyicon();
            SetHook();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        ~RegiKey()
        {
            log_file.Close();
        }

        private void CreateNotifyicon()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenu();

            this.menuItem_show = new System.Windows.Forms.MenuItem();
            this.menuItem_show.Index = 0;
            this.menuItem_show.Text = "S&how";
            this.menuItem_show.Click += new System.EventHandler(this.menuItem_show_Click);

            this.menuItem_exit = new System.Windows.Forms.MenuItem();
            this.menuItem_exit.Index = 1;
            this.menuItem_exit.Text = "E&xit";
            this.menuItem_exit.Click += new System.EventHandler(this.menuItem_exit_Click);
            this.contextMenu.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItem_show, this.menuItem_exit });

            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            notifyIcon.Icon = Properties.Resources.keyboard;
            notifyIcon.ContextMenu = this.contextMenu;
            notifyIcon.Text = "REGIKEY";
            notifyIcon.Visible = true;
            notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);

            if (RegistryHelper.isExist())
            {
                this.button_startup.Text = "Unset as startup";
            }
            else
            {
                this.button_startup.Text = "Set as startup";
            }
        }

        private void LoadINIFile()
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ini_file_path);
                string line;
                ArrayList list = new ArrayList();
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
                edit_INIFile.Text = String.Join("\n", list.ToArray());
                file.Close();
            }
            catch { }
        }

        private void FillComboItems(ref ComboBox combo)
        {
            foreach(VKKeyInfo item in keyCode.mKeys)
            {
                combo.Items.Add(item.description);
            }
        }

        private void SaveINIFile()
        {
            string currnet_path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string ini_file_path = Path.Combine(currnet_path, "regikey.ini");
            try
            {
                String line = edit_INIFile.Text;
                StreamWriter file = new StreamWriter(ini_file_path);
                file.WriteLine(line);
                file.Close();
            }
            catch { }
        }
    
        private void Apply()
        {
            String edtLine = edit_INIFile.Text;
            parser.Parse(edtLine.Replace("  ", string.Empty));
            parser.MakeHandler();
        }

        private void show_dialog()
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.Show();
        }

        private void button_hide_click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void notifyIcon_Click(object Sender, EventArgs e)
        {
            show_dialog();
        }

        private void menuItem_show_Click(object Sender, EventArgs e)
        {
            show_dialog();
        }

        private void menuItem_exit_Click(object Sender, EventArgs e)
        {
            TerminateProgram(true);
        }

        private void link_webpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string target = "https://github.com/fnwinter/Regikey";
                Process.Start(target);
            }
            catch { }
        }

        private void link_vkcode_page_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string target = "https://msdn.microsoft.com/ko-kr/library/windows/desktop/dd375731(v=vs.85).aspx";
                Process.Start(target);
            }
            catch { }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveINIFile();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            SaveINIFile();
            Apply();
        }

        private void button_startup_Click(object sender, EventArgs e)
        {
            String path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String path_with_argument = "\"" + path + "\" --hide";
            if (RegistryHelper.isExist())
            {
                RegistryHelper.registAs(false, path_with_argument);
                this.button_startup.Text = "Set as startup";
            }
            else
            {
                RegistryHelper.registAs(true, path_with_argument);
                this.button_startup.Text = "Unset as startup";
            }
        }

        private void button_check_vkeys_Click(object sender, EventArgs e)
        {
            KeyChecker checker = new KeyChecker();
            this.TopMost = false;
            checker.ShowDialog();
            this.TopMost = true;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            TerminateProgram(false);
        }

        private void RegiKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminateProgram(true);
        }

        private void TerminateProgram(bool save = false)
        {
            if (save)
            {
                SaveINIFile();
            }
            UnHook();
            Application.Exit();
        }

        /// <summary>
        /// Hooking functions
        /// </summary>
        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public static uint RegiKeyPressed()
        {
            foreach (int[] key in parser.mVKValues)
            {
                int count = 0;
                if (key[0] != -1) count++;
                if (key[1] != -1) count++;
                if (key[2] != -1) count++;

                int matchCount = 0;
                if (PressedKey[0] != -1 &&
                    (PressedKey[0] == key[0] ||
                    PressedKey[0] == key[1] ||
                    PressedKey[0] == key[2]))
                {
                    matchCount++;
                }
                if (PressedKey[1] != -1 &&
                    (PressedKey[1] == key[0] ||
                    PressedKey[1] == key[1] ||
                    PressedKey[1] == key[2]))
                {
                    matchCount++;
                }
                if (PressedKey[2] != -1 &&
                    (PressedKey[2] == key[0] ||
                    PressedKey[2] == key[1] ||
                    PressedKey[2] == key[2]))
                {
                    matchCount++;
                }
                //*
                //for debugging
                String log1 = String.Format("KEY {0:G}, {1:G}, {2:G}, ", key[0], key[1], key[2]);
                String log2 = String.Format("PressedKey {0:G}, {1:G}, {2:G}, ", PressedKey[0], PressedKey[1], PressedKey[2]);
                String log3 = String.Format("MATCH {0:G}", key[3]);

                log_file.WriteLine(log1);
                log_file.WriteLine(log2);
                log_file.WriteLine(log3);
                log_file.Flush();
                Console.WriteLine("KEY {0:G}, {1:G}, {2:G}, ", key[0], key[1], key[2]);
                Console.WriteLine("PressedKey {0:G}, {1:G}, {2:G}, ", PressedKey[0], PressedKey[1], PressedKey[2]);
                Console.WriteLine("MATCH {0:G}", key[3]);
                //
                if (count == matchCount)
                    return (uint)key[3];
            }
            return 0x00;
        }

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0) return CallNextHookEx(hhook, code, (int)wParam, lParam);

            int vkCode = Marshal.ReadInt32(lParam);
            currentPressedKey = vkCode;

            if (wParam == (IntPtr)WM_KEYDOWN)
            {
                if (PressedKey[0] == vkCode ||
                    PressedKey[1] == vkCode ||
                    PressedKey[2] == vkCode)
                    return CallNextHookEx(hhook, code, (int)wParam, lParam);
                if (PressedKey[0] == -1)
                {
                    PressedKey[0] = vkCode;
                }
                else if (PressedKey[1] == -1)
                {
                    PressedKey[1] = vkCode;
                }
                else if (PressedKey[2] == -1)
                {
                    PressedKey[2] = vkCode;
                }

                currentMatchKey = RegiKeyPressed();
                if (currentMatchKey != 0x00)
                {
                    matchKeyPressed = true;
                    Send_Key((short)currentMatchKey, keyDown);
                    return (IntPtr)1;
                }
            }
            else if (wParam == (IntPtr)WM_KEYUP)
            {
                if (PressedKey[0] == vkCode)
                {
                    PressedKey[0] = -1;
                }
                if (PressedKey[1] == vkCode)
                {
                    PressedKey[1] = -1;
                }
                if (PressedKey[2] == vkCode)
                {
                    PressedKey[2] = -1;
                }
                if (matchKeyPressed)
                {
                    matchKeyPressed = false;
                    Send_Key((short)currentMatchKey, keyUp);
                }
            }
            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

        // https://msdn.microsoft.com/ko-kr/library/windows/desktop/ms646304(v=vs.85).aspx
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        public static void Send_Key(short Keycode,uint flag)
        {
            keybd_event((byte)Keycode, 0, flag, 0);
        }
    }
}