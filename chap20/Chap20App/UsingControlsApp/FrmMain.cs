using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsingControlsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var FontsList = FontFamily.Families;
            foreach (var font in FontsList)
            {
                CboFont.Items.Add(font.Name);
            }
        }

        /// <summary>
        /// 콤보박스, 체크박스 값변경으로 글자체 변경 메서드
        /// </summary>
        private void ChangeFont()
        {
            if (CboFont.SelectedIndex < 0) return; // 콤보박스에 아무것도 선택안했으면(-1) 메서드 탈출

            FontStyle style = FontStyle.Regular; // 00000000
            if (ChkBold.Checked) style |= FontStyle.Bold;  // 00000001 
            if (ChkItalic.Checked) style |= FontStyle.Italic; // 00000010   
            // 00000001 | 00000010  = 00000011 = Bold + Italic 00001111 8+4+2+1
            TxtResult.Font = new Font((string)CboFont.SelectedItem, 14, style);
        }

        private void CboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void TrbHandle_Scroll(object sender, EventArgs e)
        {
            PrbDisplay.Value = TrbHandle.Value;
        }
    }
}
