using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using log4net;
using System.ComponentModel;

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormImportExcelCatalog : Form
    {
        #region Constructor
        public FormImportExcelCatalog()
        {
            InitializeComponent();
        }
        #endregion

        #region Override form
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // load file path from properties
            excelFileSelect.FileName = Properties.Settings.Default.ExcelLibraryPath;

            _bgWorker = new BackgroundWorker();
            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            _bgWorker.DoWork += new DoWorkEventHandler(ImportItems);
            _bgWorker.ProgressChanged += new ProgressChangedEventHandler(WorkerProgressChanged);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerRunCompleted);
            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.WorkerSupportsCancellation = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Properties.Settings.Default.ExcelLibraryPath = excelFileSelect.FileName;
        }
        #endregion

        #region Handlers
        private void OnFileNameChanged(object sender, EventArgs e)
        {
            bool fileExist = File.Exists(excelFileSelect.FileName);
            // enable disable import button
            bnImport.Enabled = fileExist;

            UpdateStatus(fileExist ? string.Empty : "Define a valid file path.");
        }

         private void OnButtonImportClick(object sender, EventArgs e)
        {
            bnImport.Enabled = false;
            bnStop.Enabled = true;
            richTextBoxLog.Clear();
            // Kickoff the worker thread to begin it's DoWork function
            _bgWorker.RunWorkerAsync();
        }
        private void ImportItems(object sender, DoWorkEventArgs e)
        {
            try
            {
                _iCount = 0;
                while (_iCount < 100)
                {
                    try
                    {
                        ++_iCount;
                        _bgWorker.ReportProgress(_iCount);

                        AppendRtb(string.Format("{0} done", _iCount));

                        if (_bgWorker.CancellationPending)
                        {
                            // Set the e.Cancel flag so that the WorkerCompleted event
                            // knows that the process was cancelled.
                            e.Cancel = true;
                            _bgWorker.ReportProgress(0);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        /// <summary>
        /// On completed do the appropriate task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WorkerRunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
                UpdateStatus( "Task Cancelled.");
            else if (e.Error != null)
                UpdateStatus("Error while performing background operation.");
            else
                // Everything completed normally.
                UpdateStatus("Task Completed...");

            //Change the status of the buttons on the UI accordingly
            bnImport.Enabled = true;
            bnStop.Enabled = false;
        }

        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            UpdateStatus( "Processing : " + e.ProgressPercentage + "%");
        }
        private void OnStopWork(object sender, EventArgs e)
        {
            if (_bgWorker.IsBusy)
                _bgWorker.CancelAsync();
        }
        #endregion

        #region Helpers
        public void AppendRtb(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendRtb), new object[] { value });
                return;
            }
            richTextBoxLog.Text += value + Environment.NewLine;
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        private void UpdateStatus(string message)
        {
            if (string.IsNullOrEmpty(message))
                statusLabel.Text = "Ready";
            else
                statusLabel.Text = message;
        }
        #endregion

        #region Data members
        protected int _iCount = 0;
        BackgroundWorker _bgWorker;
        protected ILog _log = LogManager.GetLogger(typeof(FormImportExcelCatalog));
        #endregion
    }
}
