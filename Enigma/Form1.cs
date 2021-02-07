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
    public partial class enigma : Form
    {
        public enigma()
        {
            InitializeComponent();
        }
        public string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public bool buttonAlreadyPressed = false;
        public int lockedButtonCounter = 0;
        public char lowerButton1;
        public char lowerButton2;
        public char upperButton1;
        public char upperButton2;
        public int progress = 0;
        public Dictionary<char, char> dic = new Dictionary<char, char>();
        public List<int> colorList = new List<int>() {255,0,0, 0,255,0, 0,0,255, 255,255,0, 255,0,255,
                                                      0,255,255, 127,0,255, 0,127,255 , 255,127,0, 255,0,127};
        public int colerCounter = 0;
        public void InitialiseAlphabet()
        {
            dic.Clear();
            foreach (char c in alphabet)
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
            progress += 5;
            ProgressBar.Value = progress;
            lockedButtonCounter++;
            if (lockedButtonCounter == 20)
            {
                ButtonEnable(false);
            }
            if (buttonAlreadyPressed)
                {
                    buttonAlreadyPressed = false;
                    ChangeDictonaryAndColors();
                }
            else buttonAlreadyPressed = true;
            if (buttonAlreadyPressed) ButtonConvert.Enabled = false;
            else ButtonConvert.Enabled = true;
        }
        public void ChangeDictonaryAndColors()
        {
            colerCounter += 3;
            ChangeDictonary(lowerButton1, lowerButton2);
            ChangeDictonary(upperButton1, upperButton2);
            ChangeDictonary(lowerButton2, lowerButton1);
            ChangeDictonary(upperButton2, upperButton1);
        }
        private void enigma_Load(object sender, EventArgs e)
        {
            InitialiseAlphabet();
        }
        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            TextBoxMain.Text = ConvertText(TextBoxMain.Text);
            InitialiseAlphabet();
            ButtonEnable(true);
            ResetButtonColor();
            progress = 0;
            ProgressBar.Value = 0;
            colerCounter = 0;
            buttonAlreadyPressed = false;
            lockedButtonCounter = 0;
            ButtonA.BackColor = Color.Transparent;
            ButtonB.BackColor = Color.Transparent;
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            InitialiseAlphabet();
            ButtonEnable(true);
            ResetButtonColor();            
            progress = 0;
            ProgressBar.Value = 0;
            colerCounter = 0;
            buttonAlreadyPressed = false;
            lockedButtonCounter = 0;
            ButtonConvert.Enabled = true;            
        }
        private void TextBoxMain_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
           if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'a';
                upperButton1 = 'A';
            }
            else
            {
                lowerButton2 = 'a';
                upperButton2 = 'A';
            }
            ButtonA.Enabled = false;
            ButtonA.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonB_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'b';
                upperButton1 = 'B';
            }
            else
            {
                lowerButton2 = 'b';
                upperButton2 = 'B';
            }
            ButtonB.Enabled = false;
            ButtonB.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'c';
                upperButton1 = 'C';
            }
            else
            {
                lowerButton2 = 'c';
                upperButton2 = 'C';
            }
            ButtonC.Enabled = false;
            ButtonC.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonD_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'd';
                upperButton1 = 'D';
            }
            else
            {
                lowerButton2 = 'd';
                upperButton2 = 'D';
            }
            ButtonD.Enabled = false;
            ButtonD.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonE_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'e';
                upperButton1 = 'E';
            }
            else
            {
                lowerButton2 = 'e';
                upperButton2 = 'E';
            }
            ButtonE.Enabled = false;
            ButtonE.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonF_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'f';
                upperButton1 = 'F';
            }
            else
            {
                lowerButton2 = 'f';
                upperButton2 = 'F';
            }
            ButtonF.Enabled = false;
            ButtonF.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonG_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'g';
                upperButton1 = 'G';
            }
            else
            {
                lowerButton2 = 'g';
                upperButton2 = 'G';
            }
            ButtonG.Enabled = false;
            ButtonG.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonH_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'h';
                upperButton1 = 'H';
            }
            else
            {
                lowerButton2 = 'h';
                upperButton2 = 'H';
            }
            ButtonH.Enabled = false;
            ButtonH.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonI_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'i';
                upperButton1 = 'I';
            }
            else
            {
                lowerButton2 = 'i';
                upperButton2 = 'I';
            }
            ButtonI.Enabled = false;
            ButtonI.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonJ_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'j';
                upperButton1 = 'J';
            }
            else
            {
                lowerButton2 = 'j';
                upperButton2 = 'J';
            }
            ButtonJ.Enabled = false;
            ButtonJ.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonK_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'k';
                upperButton1 = 'K';
            }
            else
            {
                lowerButton2 = 'k';
                upperButton2 = 'K';
            }
            ButtonK.Enabled = false;
            ButtonK.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonL_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'l';
                upperButton1 = 'L';
            }
            else
            {
                lowerButton2 = 'l';
                upperButton2 = 'L';
            }
            ButtonL.Enabled = false;
            ButtonL.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonM_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'm';
                upperButton1 = 'M';
            }
            else
            {
                lowerButton2 = 'm';
                upperButton2 = 'M';
            }
            ButtonM.Enabled = false;
            ButtonM.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonN_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'n';
                upperButton1 = 'N';
            }
            else
            {
                lowerButton2 = 'n';
                upperButton2 = 'N';
            }
            ButtonN.Enabled = false;
            ButtonN.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonO_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'o';
                upperButton1 = 'O';
            }
            else
            {
                lowerButton2 = 'o';
                upperButton2 = 'O';
            }
            ButtonO.Enabled = false;
            ButtonO.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonP_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'p';
                upperButton1 = 'P';
            }
            else
            {
                lowerButton2 = 'p';
                upperButton2 = 'P';
            }
            ButtonP.Enabled = false;
            ButtonP.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonQ_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'q';
                upperButton1 = 'Q';
            }
            else
            {
                lowerButton2 = 'q';
                upperButton2 = 'Q';
            }
            ButtonQ.Enabled = false;
            ButtonQ.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonR_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'r';
                upperButton1 = 'R';
            }
            else
            {
                lowerButton2 = 'r';
                upperButton2 = 'R';
            }
            ButtonR.Enabled = false;
            ButtonR.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonS_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 's';
                upperButton1 = 'S';
            }
            else
            {
                lowerButton2 = 's';
                upperButton2 = 'S';
            }
            ButtonS.Enabled = false;
            ButtonS.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonT_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 't';
                upperButton1 = 'T';
            }
            else
            {
                lowerButton2 = 't';
                upperButton2 = 'T';
            }
            ButtonT.Enabled = false;
            ButtonT.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonU_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'u';
                upperButton1 = 'U';
            }
            else
            {
                lowerButton2 = 'u';
                upperButton2 = 'U';
            }
            ButtonU.Enabled = false;
            ButtonU.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonV_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'v';
                upperButton1 = 'V';
            }
            else
            {
                lowerButton2 = 'v';
                upperButton2 = 'V';
            }
            ButtonV.Enabled = false;
            ButtonV.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonW_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'w';
                upperButton1 = 'W';
            }
            else
            {
                lowerButton2 = 'w';
                upperButton2 = 'W';
            }
            ButtonW.Enabled = false;
            ButtonW.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonX_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'x';
                upperButton1 = 'X';
            }
            else
            {
                lowerButton2 = 'x';
                upperButton2 = 'X';
            }
            ButtonX.Enabled = false;
            ButtonX.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonY_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'y';
                upperButton1 = 'Y';
            }
            else
            {
                lowerButton2 = 'y';
                upperButton2 = 'Y';
            }
            ButtonY.Enabled = false;
            ButtonY.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
        private void ButtonZ_Click(object sender, EventArgs e)
        {
            if (!buttonAlreadyPressed)
            {
                lowerButton1 = 'z';
                upperButton1 = 'Z';
            }
            else
            {
                lowerButton2 = 'z';
                upperButton2 = 'Z';
            }
            ButtonZ.Enabled = false;
            ButtonZ.BackColor = Color.FromArgb(colorList[colerCounter], colorList[colerCounter + 1], colorList[colerCounter + 2]);
            UpdateProgress();
        }
    }
}
