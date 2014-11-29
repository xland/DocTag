using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocTag.Entity;
using DocTag.Helper;

namespace DocTag
{
    public partial class TagSuggestionCtl : UserControl
    {
        public TagSuggestionCtl()
        {
            InitializeComponent();
        }
        

        private void CloseSuggestionBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void ClearTags()
        {
            TagSuggestionFLP.Controls.Clear();
        }
        public void AddTag(LinkLabel tagLabel)
        {
            TagSuggestionFLP.Controls.Add(tagLabel);
        }

    }
}
