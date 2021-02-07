using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Enigma : Form
    {
        public Enigma()
        {
            InitializeComponent();
        }
        public string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public bool ButtonAlreadyPressed = false;
        public int LockedButtonCounter = 0;
        public char LowerButton1;
        public char LowerButton2;
        public char UpperButton1;
        public char UpperButton2;
        public int Progress = 0;
        public Dictionary<char, char> dic = new Dictionary<char, char>();
        public List<int> ColorList = new List<int>() {255,0,0, 0,255,0, 0,0,255, 255,255,0, 255,0,255,
                                                      0,255,255, 127,0,255, 0,127,255 , 255,127,0, 255,0,127};
        public int ColorCounter = 0;
        public void InitialiseAlphabet()
        {
            dic.Clear();
            foreach (char c in Alphabet)
            {
                dic.Add(c, c);
            }
        }
        public void ButtonEnable(bool enable)
        {
            ButtonA.Enabled = enable;
            ButtonB.Enabled = enable;
            ButtonC.Enabled = enable;
            ButtonD.Enabled = enable;
            ButtonE.Enabled = enable;
            ButtonF.Enabled = enable;
            ButtonG.Enabled = enable;
            ButtonH.Enabled = enable;
            ButtonI.Enabled = enable;
            ButtonJ.Enabled = enable;
            ButtonK.Enabled = enable;
            ButtonL.Enabled = enable;
            ButtonM.Enabled = enable;
            ButtonN.Enabled = enable;
            ButtonO.Enabled = enable;
            ButtonP.Enabled = enable;
            ButtonQ.Enabled = enable;
            ButtonR.Enabled = enable;
            ButtonS.Enabled = enable;
            ButtonT.Enabled = enable;
            ButtonU.Enabled = enable;
            ButtonV.Enabled = enable;
            ButtonW.Enabled = enable;
            ButtonX.Enabled = enable;
            ButtonY.Enabled = enable;
            ButtonZ.Enabled = enable;
        }
        public void ResetButtonColor()
        {
            ButtonA.BackColor = Color.Transparent;
            ButtonB.BackColor = Color.Transparent;
            ButtonC.BackColor = Color.Transparent;
            ButtonD.BackColor = Color.Transparent;
            ButtonE.BackColor = Color.Transparent;
            ButtonF.BackColor = Color.Transparent;
            ButtonG.BackColor = Color.Transparent;
            ButtonH.BackColor = Color.Transparent;
            ButtonI.BackColor = Color.Transparent;
            ButtonJ.BackColor = Color.Transparent;
            ButtonK.BackColor = Color.Transparent;
            ButtonL.BackColor = Color.Transparent;
            ButtonM.BackColor = Color.Transparent;
            ButtonN.BackColor = Color.Transparent;
            ButtonO.BackColor = Color.Transparent;
            ButtonP.BackColor = Color.Transparent;
            ButtonQ.BackColor = Color.Transparent;
            ButtonR.BackColor = Color.Transparent;
            ButtonS.BackColor = Color.Transparent;
            ButtonT.BackColor = Color.Transparent;
            ButtonU.BackColor = Color.Transparent;
            ButtonV.BackColor = Color.Transparent;
            ButtonW.BackColor = Color.Transparent;
            ButtonX.BackColor = Color.Transparent;
            ButtonY.BackColor = Color.Transparent;
            ButtonZ.BackColor = Color.Transparent;
        }
        public string ConvertText(string s)
        {
            var emptystring = new StringBuilder();
            foreach (char c in s)
            {
                if (dic.ContainsKey(c)) emptystring.Append(dic[c]);
                else emptystring.Append(c);
            }
            return emptystring.ToString();
        }
        public void ChangeDictonary(char key, char value)
        {
            dic[key] = value;
        }
        public void UpdateProgress()
        {
            Progress += 5;
            ProgressBar.Value = Progress;
            LockedButtonCounter++;
            if (LockedButtonCounter == 20)
            {
                ButtonEnable(false);
            }
            if (ButtonAlreadyPressed)
                {
                    ButtonAlreadyPressed = false;
                    ChangeDictonaryAndColors();
                }
            else ButtonAlreadyPressed = true;
            if (ButtonAlreadyPressed) ButtonConvert.Enabled = false;
            else ButtonConvert.Enabled = true;
        }
        public void ChangeDictonaryAndColors()
        {
            ColorCounter += 3;
            ChangeDictonary(LowerButton1, LowerButton2);
            ChangeDictonary(UpperButton1, UpperButton2);
            ChangeDictonary(LowerButton2, LowerButton1);
            ChangeDictonary(UpperButton2, UpperButton1);
        }
        private void Enigma_Load(object sender, EventArgs e)
        {
            InitialiseAlphabet();
        }
        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            TextBoxMain.Text = ConvertText(TextBoxMain.Text);
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            InitialiseAlphabet();
            ButtonEnable(true);
            ResetButtonColor();            
            Progress = 0;
            ProgressBar.Value = 0;
            ColorCounter = 0;
            ButtonAlreadyPressed = false;
            LockedButtonCounter = 0;
            ButtonConvert.Enabled = true;            
        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
           if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'a';
                UpperButton1 = 'A';
            }
            else
            {
                LowerButton2 = 'a';
                UpperButton2 = 'A';
            }
            ButtonA.Enabled = false;
            ButtonA.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonB_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'b';
                UpperButton1 = 'B';
            }
            else
            {
                LowerButton2 = 'b';
                UpperButton2 = 'B';
            }
            ButtonB.Enabled = false;
            ButtonB.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'c';
                UpperButton1 = 'C';
            }
            else
            {
                LowerButton2 = 'c';
                UpperButton2 = 'C';
            }
            ButtonC.Enabled = false;
            ButtonC.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonD_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'd';
                UpperButton1 = 'D';
            }
            else
            {
                LowerButton2 = 'd';
                UpperButton2 = 'D';
            }
            ButtonD.Enabled = false;
            ButtonD.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonE_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'e';
                UpperButton1 = 'E';
            }
            else
            {
                LowerButton2 = 'e';
                UpperButton2 = 'E';
            }
            ButtonE.Enabled = false;
            ButtonE.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonF_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'f';
                UpperButton1 = 'F';
            }
            else
            {
                LowerButton2 = 'f';
                UpperButton2 = 'F';
            }
            ButtonF.Enabled = false;
            ButtonF.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonG_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'g';
                UpperButton1 = 'G';
            }
            else
            {
                LowerButton2 = 'g';
                UpperButton2 = 'G';
            }
            ButtonG.Enabled = false;
            ButtonG.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonH_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'h';
                UpperButton1 = 'H';
            }
            else
            {
                LowerButton2 = 'h';
                UpperButton2 = 'H';
            }
            ButtonH.Enabled = false;
            ButtonH.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonI_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'i';
                UpperButton1 = 'I';
            }
            else
            {
                LowerButton2 = 'i';
                UpperButton2 = 'I';
            }
            ButtonI.Enabled = false;
            ButtonI.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonJ_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'j';
                UpperButton1 = 'J';
            }
            else
            {
                LowerButton2 = 'j';
                UpperButton2 = 'J';
            }
            ButtonJ.Enabled = false;
            ButtonJ.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonK_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'k';
                UpperButton1 = 'K';
            }
            else
            {
                LowerButton2 = 'k';
                UpperButton2 = 'K';
            }
            ButtonK.Enabled = false;
            ButtonK.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonL_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'l';
                UpperButton1 = 'L';
            }
            else
            {
                LowerButton2 = 'l';
                UpperButton2 = 'L';
            }
            ButtonL.Enabled = false;
            ButtonL.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonM_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'm';
                UpperButton1 = 'M';
            }
            else
            {
                LowerButton2 = 'm';
                UpperButton2 = 'M';
            }
            ButtonM.Enabled = false;
            ButtonM.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonN_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'n';
                UpperButton1 = 'N';
            }
            else
            {
                LowerButton2 = 'n';
                UpperButton2 = 'N';
            }
            ButtonN.Enabled = false;
            ButtonN.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonO_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'o';
                UpperButton1 = 'O';
            }
            else
            {
                LowerButton2 = 'o';
                UpperButton2 = 'O';
            }
            ButtonO.Enabled = false;
            ButtonO.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonP_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'p';
                UpperButton1 = 'P';
            }
            else
            {
                LowerButton2 = 'p';
                UpperButton2 = 'P';
            }
            ButtonP.Enabled = false;
            ButtonP.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonQ_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'q';
                UpperButton1 = 'Q';
            }
            else
            {
                LowerButton2 = 'q';
                UpperButton2 = 'Q';
            }
            ButtonQ.Enabled = false;
            ButtonQ.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonR_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'r';
                UpperButton1 = 'R';
            }
            else
            {
                LowerButton2 = 'r';
                UpperButton2 = 'R';
            }
            ButtonR.Enabled = false;
            ButtonR.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonS_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 's';
                UpperButton1 = 'S';
            }
            else
            {
                LowerButton2 = 's';
                UpperButton2 = 'S';
            }
            ButtonS.Enabled = false;
            ButtonS.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonT_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 't';
                UpperButton1 = 'T';
            }
            else
            {
                LowerButton2 = 't';
                UpperButton2 = 'T';
            }
            ButtonT.Enabled = false;
            ButtonT.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonU_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'u';
                UpperButton1 = 'U';
            }
            else
            {
                LowerButton2 = 'u';
                UpperButton2 = 'U';
            }
            ButtonU.Enabled = false;
            ButtonU.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonV_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'v';
                UpperButton1 = 'V';
            }
            else
            {
                LowerButton2 = 'v';
                UpperButton2 = 'V';
            }
            ButtonV.Enabled = false;
            ButtonV.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonW_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'w';
                UpperButton1 = 'W';
            }
            else
            {
                LowerButton2 = 'w';
                UpperButton2 = 'W';
            }
            ButtonW.Enabled = false;
            ButtonW.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonX_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'x';
                UpperButton1 = 'X';
            }
            else
            {
                LowerButton2 = 'x';
                UpperButton2 = 'X';
            }
            ButtonX.Enabled = false;
            ButtonX.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonY_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'y';
                UpperButton1 = 'Y';
            }
            else
            {
                LowerButton2 = 'y';
                UpperButton2 = 'Y';
            }
            ButtonY.Enabled = false;
            ButtonY.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
        private void ButtonZ_Click(object sender, EventArgs e)
        {
            if (!ButtonAlreadyPressed)
            {
                LowerButton1 = 'z';
                UpperButton1 = 'Z';
            }
            else
            {
                LowerButton2 = 'z';
                UpperButton2 = 'Z';
            }
            ButtonZ.Enabled = false;
            ButtonZ.BackColor = Color.FromArgb(ColorList[ColorCounter], ColorList[ColorCounter + 1], ColorList[ColorCounter + 2]);
            UpdateProgress();
        }
    }
}
