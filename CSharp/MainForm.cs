using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

using DemosCommonCode;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.ImageFiles.Dicom;
using Vintasoft.Imaging.Metadata;

namespace DicomMetadataEditorDemo
{
    /// <summary>
    /// Main form of DICOM metadata editor demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Template of the application title.
        /// </summary>
        string _titlePrefix = "VintaSoft DICOM Metadata Editor Demo v" + ImagingGlobalSettings.ProductVersion + " - {0}";

        /// <summary>
        /// A value indicating whether the application form is closing.
        /// </summary> 
        bool _isFormClosing = false;

        /// <summary>
        /// A value indicating whether DICOM file contains MPEG file.
        /// </summary>
        bool _dicomFileContainsMpegFile = false;

        #endregion



        #region Constructors

        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            MoveDicomCodecToFirstPosition();

            DemosTools.SetTestFilesFolder(openDicomFileDialog);

            this.Text = string.Format(_titlePrefix, "(Untitled)");

            // update the UI
            UpdateUI();
        }

        #endregion



        #region Properties

        bool _isDicomFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether the DICOM file is opening.
        /// </summary>
        bool IsDicomFileOpening
        {
            get
            {
                return _isDicomFileOpening;
            }
            set
            {
                _isDicomFileOpening = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        bool _isFileSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether DICOM file is saving.
        /// </summary>
        bool IsFileSaving
        {
            get
            {
                return _isFileSaving;
            }
            set
            {
                _isFileSaving = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        DicomFile _dicomFile = null;
        /// <summary>
        /// Gets the DICOM file.
        /// </summary>
        DicomFile DicomFile
        {
            get
            {
                return _dicomFile;
            }
            set
            {
                _dicomFile = value;

                if (_dicomFile == null)
                {
                    _dicomPageMetadata = null;
                    _dicomFileContainsMpegFile = false;
                }

                dicomMetadataEditorControl1.RootMetadataNode = DicomPageMetadata;
            }
        }

        DicomPageMetadata _dicomPageMetadata;
        /// <summary>
        /// Gets the DICOM page metadata.
        /// </summary>
        DicomPageMetadata DicomPageMetadata
        {
            get
            {
                if (_dicomPageMetadata == null && DicomFile != null)
                {
                    if (DicomFile.Pages.Count != 0)
                    {
                        _dicomPageMetadata = DicomPageMetadata.Create(DicomFile, DicomFile.Pages[0]);
                    }
                    else
                    {
                        _dicomPageMetadata = new DicomPageMetadata(DicomFile);
                    }
                }

                return _dicomPageMetadata;
            }
        }

        #endregion



        #region Methods

        #region PRIVATE

        #region UI

        #region Main Form

        /// <summary>
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;

            // close the previously opened DICOM file
            CloseDicomFile();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the Click event of openDicomFilesToolStripMenuItem object.
        /// </summary>
        private void openDicomFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDicomFileDialog.Multiselect = false;

            if (openDicomFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openDicomFileDialog.FileName))
                {
                    // close the previously opened DICOM file
                    CloseDicomFile();

                    // open DICOM file
                    OpenDicomFile(openDicomFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of saveCurrentDicomFileToolStripMenuItem object.
        /// </summary>
        private void saveCurrentDicomFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DicomFile.SaveChanges();

                UpdateUI();
                MessageBox.Show("DICOM file is saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of saveCurrentDicomFileToToolStripMenuItem object.
        /// </summary>
        private void saveCurrentDicomFileToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDicomFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DicomFile.Save(saveDicomFileDialog.FileName);

                    MessageBox.Show("DICOM file is saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of closeDicomSeriesToolStripMenuItem object.
        /// </summary>
        private void closeDicomSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close DICOM file
            CloseDicomFile();
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Metadata' menu

        /// <summary>
        /// Handles the Click event of saveEmbeddedVideoFileToolStripMenuItem object.
        /// </summary>
        private void saveEmbeddedVideoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DicomDataSet fileDataSet = DicomFile.DataSet;

            DicomDataElement pixelDataElement = fileDataSet.DataElements.Find(DicomDataElementId.PixelData);

            if (pixelDataElement != null && pixelDataElement.Data != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    byte[] mpegData = (byte[])pixelDataElement.Data;
                    File.WriteAllBytes(filePath, mpegData);
                    MessageBox.Show(string.Format("File \"{0}\" Saved", filePath));
                }
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // if application is closing
            if (_isFormClosing)
                // exit
                return;

            bool isDicomFileLoaded = DicomFile != null;
            bool isDicomFileOpening = _isDicomFileOpening;
            bool isFileSaving = _isFileSaving;
            bool dicomFileContainsMpegFile = _dicomFileContainsMpegFile;

            // 'File' menu
            //
            openDicomFilesToolStripMenuItem.Enabled = !isDicomFileOpening && !isFileSaving;
            saveCurrentDicomFileToolStripMenuItem.Enabled = isDicomFileLoaded && !isDicomFileOpening && !isFileSaving;
            saveCurrentDicomFileToToolStripMenuItem.Enabled = isDicomFileLoaded && !isDicomFileOpening && !isFileSaving;
            closeDicomSeriesToolStripMenuItem.Enabled = isDicomFileLoaded && !isDicomFileOpening && !isFileSaving;

            // 'Metadata' menu
            //
            saveEmbeddedVideoFileToolStripMenuItem.Enabled = isDicomFileLoaded && !isDicomFileOpening && !isFileSaving && dicomFileContainsMpegFile;

        }

        #endregion


        #region Main Form

        /// <summary>
        /// Moves the DICOM codec to the first position in <see cref="AvailableCodecs"/>.
        /// </summary>
        private static void MoveDicomCodecToFirstPosition()
        {
            ReadOnlyCollection<Codec> codecs = AvailableCodecs.Codecs;

            for (int i = codecs.Count - 1; i >= 0; i--)
            {
                Codec codec = codecs[i];

                if (codec.Name.Equals("DICOM", StringComparison.InvariantCultureIgnoreCase))
                {
                    AvailableCodecs.RemoveCodec(codec);
                    AvailableCodecs.InsertCodec(0, codec);
                    break;
                }
            }
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Open the DICOM file.
        /// </summary>
        /// <param name="filePath">File path.</param>
        private void OpenDicomFile(string filePath)
        {
            try
            {
                try
                {
                    IsDicomFileOpening = true;

                    // create DICOM file
                    DicomFile = new DicomFile(filePath, false);

                    // if DICOM file contains MPEG file
                    if (ContainsMpegFile(DicomFile))
                        _dicomFileContainsMpegFile = true;
                    else
                        _dicomFileContainsMpegFile = false;

                    // update header of form
                    this.Text = string.Format(_titlePrefix, Path.GetFileName(filePath));
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);

                    CloseDicomFile();
                }

                // update UI
                UpdateUI();
            }
            finally
            {
                if (!_isFormClosing)
                {
                    // update the UI
                    IsDicomFileOpening = false;
                }
            }
        }

        /// <summary>
        /// Determines whether the specified DICOM file contains MPEG file.
        /// </summary>
        /// <param name="dicomFile">The DICOM file.</param>
        /// <returns>
        /// <returns><b>true</b> if the DICOM file contains MPEG file; 
        /// otherwise, <b>false</b>.</returns>
        /// </returns>
        private bool ContainsMpegFile(DicomFile dicomFile)
        {
            DicomDataElement transferSyntaxUidDataElement =
                dicomFile.DataSet.DataElements.Find(DicomDataElementId.TransferSyntaxUID);
            if (transferSyntaxUidDataElement != null)
            {
                DicomUid uid = (DicomUid)transferSyntaxUidDataElement.Data;
                if (uid.Id == DicomUidId.MPEG2MPHL ||
                    uid.Id == DicomUidId.MPEG2MPML ||
                    uid.Id == DicomUidId.MPEG4HP41BDF ||
                    uid.Id == DicomUidId.MPEG4HP41)
                    return true;
                else
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Closes DICOM file.
        /// </summary>
        private void CloseDicomFile()
        {
            if (DicomFile != null)
            {
                DicomFile.Dispose();
                DicomFile = null;
            }

            this.Text = string.Format(_titlePrefix, "(Untitled)");

            // update the UI
            UpdateUI();
        }

        #endregion

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// Represents the <see cref="UpdateUI"/> method.
        /// </summary>
        delegate void UpdateUIDelegate();

        #endregion

    }
}
