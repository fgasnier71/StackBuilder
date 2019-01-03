#region Using directives
using System;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormDocDisambiguate : Form
    {
        public FormDocDisambiguate()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // load documents
            FormMain form = FormMain.GetInstance();
            foreach (IDocument d in form.Documents)
                cbDocuments.Items.Add(d);
            if (cbDocuments.Items.Count > 0)
                cbDocuments.SelectedIndex = 0;
        }
        private void OnDocumentChanged(object sender, EventArgs e) => Document = cbDocuments.SelectedItem as IDocument;

        public IDocument Document { get; private set; }
    }
}
