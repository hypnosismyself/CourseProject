using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject.View
{
    public partial class MDIParentView: Form
    {
        public MDIParentView()
        {
            InitializeComponent();

            EditorView f = new EditorView(Color.Aqua)
            {
                MdiParent = this,
                Text = "Редактор - " + MdiChildren.Length.ToString(),
            };

            f.Show();
        }
    }
}
