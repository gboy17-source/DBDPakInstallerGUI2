using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBDPakInstallerGUI2
{
    public partial class dbdPakInstaller : Form
    {
        private TextBox paksTextBox;
        private TextBox pakFileTextBox;
        private TextBox paksTextBoxDisplay;
        private TextBox pakFileTextBoxDisplay;
        private Logger logger;
        private string paksFolderPath;
        public dbdPakInstaller()
        {
            InitializeComponent();

            //Textbox field instances
            paksTextBox = new TextBox();
            pakFileTextBox = new TextBox();

            //display TextBoxes
            paksTextBoxDisplay = new TextBox();
            paksTextBoxDisplay.ReadOnly = true;
            pakFileTextBoxDisplay = new TextBox();
            pakFileTextBoxDisplay.ReadOnly = true;

            // Get the application directory path
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Initialize logger with the log file path in the application directory
            string logFilePath = Path.Combine(appDirectory, "logs.txt");
            logger = new Logger(logFilePath);
            logger.Log("Application started.");

            // Set the paksFolderPath to the PaksFolderPath.txt file in the application directory
            paksFolderPath = Path.Combine(appDirectory, "PaksFolderPath.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Log("Form loaded.");
        }

        private void selectPaksFolder_Click(object sender, EventArgs e)
        {
            logger.Log("Selecting Paks folder.");
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                string paksFolder = string.Empty;

                // Check if the PaksFolderPath.txt file exists and contains a valid path
                if (File.Exists(paksFolderPath))
                {
                    paksFolder = File.ReadAllText(paksFolderPath).Trim();
                    if (Directory.Exists(paksFolder))
                    {
                        logger.Log($"Paks folder found at: {paksFolder}");
                        DialogResult result = MessageBox.Show($"Paks folder is already found at: {paksFolder}\nDo you want to select a different folder?", "Paks Folder Found", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            paksTextBox.Text = paksFolder;
                            paksTextBoxDisplay.Text = paksFolder;
                            return;
                        }
                    }
                }

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    paksFolder = folderBrowserDialog.SelectedPath;
                    logger.Log($"Paks folder selected: {paksFolder}");
                    paksTextBox.Text = paksFolder;
                    paksTextBoxDisplay.Text = paksFolder;

                    // Save the selected Paks folder path to PaksFolderPath.txt
                    File.WriteAllText(paksFolderPath, paksFolder);
                }
            }
        }
        private void selectPakBakFile_Click(object sender, EventArgs e)
        {
            logger.Log("Selecting PAK or BAK file.");

            string paksFolder = string.Empty;

            // Check if the PaksFolderPath.txt file exists and contains a valid path
            if (File.Exists(paksFolderPath))
            {
                paksFolder = File.ReadAllText(paksFolderPath).Trim();
                if (Directory.Exists(paksFolder))
                {
                    logger.Log($"Paks folder found at: {paksFolder}");
                    paksTextBox.Text = paksFolder;
                    paksTextBoxDisplay.Text = paksFolder;
                }
            }

            if (string.IsNullOrEmpty(paksFolder))
            {
                // Prompt the user to select the Paks folder
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        paksFolder = folderBrowserDialog.SelectedPath;
                        logger.Log($"Paks folder selected: {paksFolder}");
                        paksTextBox.Text = paksFolder;
                        paksTextBoxDisplay.Text = paksFolder;

                        // Save the selected Paks folder path to PaksFolderPath.txt
                        File.WriteAllText(paksFolderPath, paksFolder);
                    }
                    else
                    {
                        logger.Log("No Paks folder selected.");
                        MessageBox.Show("No Paks folder selected. Operation canceled.");
                        return;
                    }
                }
            }

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PAK files (*.pak)|*.pak|BAK files (*.bak)|*.bak";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string chosenPakFileName = openFileDialog.FileName;
                    logger.Log($"PAK or BAK file selected: {chosenPakFileName}");
                    pakFileTextBox.Text = chosenPakFileName;
                    pakFileTextBoxDisplay.Text = chosenPakFileName; // Update display TextBox

                    // Check wether the Paks folder is valid or nah
                    if (!string.IsNullOrEmpty(paksFolder) && Directory.Exists(paksFolder))
                    {
                        // Create copies of pakchunk348-EGS.sig
                        CreatePakSigCopies(paksFolder);
                    }
                    else
                    {
                        logger.Log("Invalid Paks folder selected.");
                        MessageBox.Show("Please select a valid Paks folder before selecting the PAK/BAK file.");
                    }
                }
            }
        }


        private void EpicGames_CheckedChanged(object sender, EventArgs e)
        {
            if (EpicGames.Checked)
            {
                RenameFileToEGS();
            }
        }

        private void Steam_CheckedChanged(object sender, EventArgs e)
        {
            if (Steam.Checked)
            {
                RenameFileToWindowsNoEditor();
            }
        }

        private void RenameFileToEGS()
        {
            string chosenPakFileName = pakFileTextBox.Text;

            if (!string.IsNullOrEmpty(chosenPakFileName))
            {
                // Check if the file contains "WindowsNoEditor"
                if (chosenPakFileName.Contains("WindowsNoEditor"))
                {
                    string newFileName = chosenPakFileName.Replace("WindowsNoEditor", "EGS");
                    RenameFile(chosenPakFileName, newFileName);
                    // Update the pakFileTextBox with the new filename
                    pakFileTextBox.Text = newFileName;
                }
                else
                {
                    MessageBox.Show("File does not contain 'WindowsNoEditor'. No action taken.");
                }
            }
        }

        private void RenameFileToWindowsNoEditor()
        {
            string chosenPakFileName = pakFileTextBox.Text;

            if (!string.IsNullOrEmpty(chosenPakFileName))
            {
                // Check if the file contains "EGS"
                if (chosenPakFileName.Contains("EGS"))
                {
                    string newFileName = chosenPakFileName.Replace("EGS", "WindowsNoEditor");
                    RenameFile(chosenPakFileName, newFileName);
                    // Update the pakFileTextBox with the new filename
                    pakFileTextBox.Text = newFileName;
                }
                else
                {
                    MessageBox.Show("File does not contain 'EGS'. No action taken.");
                }
            }
        }

        private void RenameFile(string oldFileName, string newFileName)
        {
            string paksFolder = paksTextBox.Text;
            string oldFilePath = Path.Combine(paksFolder, oldFileName);
            string newFilePath = Path.Combine(paksFolder, newFileName);

            if (File.Exists(oldFilePath))
            {
                try
                {
                    File.Move(oldFilePath, newFilePath);
                    logger.Log($"File renamed: {oldFileName} -> {newFileName}");
                    MessageBox.Show($"File renamed: {oldFileName} -> {newFileName}");
                }
                catch (IOException ex)
                {
                    logger.Log($"Error occurred while renaming file: {ex.Message}");
                    MessageBox.Show($"Error occurred while renaming file: {ex.Message}");
                }
            }
            else
            {
                logger.Log($"File not found: {oldFileName}");
                MessageBox.Show($"File not found: {oldFileName}");
            }
        }

        private void EXECUTE_Click(object sender, EventArgs e)
        {
            logger.Log("Executing operation.");
            string paksFolder = paksTextBox.Text;
            string chosenPakFileName = pakFileTextBox.Text;

            // Check if either "Epic Games" or "Steam" option is checked
            if (!EpicGames.Checked && !Steam.Checked)
            {
                logger.Log("Platform not chosen.");
                MessageBox.Show("Please choose your platform first before executing.");
                return;
            }

            if (string.IsNullOrEmpty(paksFolder) || string.IsNullOrEmpty(chosenPakFileName))
            {
                logger.Log("Paks folder or PAK/BAK file not selected.");
                MessageBox.Show("Please select the Paks folder and PAK/BAK file.");
                return;
            }

            string chosenPakFile = Path.Combine(paksFolder, chosenPakFileName);
            if (!File.Exists(chosenPakFile) || (!chosenPakFileName.EndsWith(".pak") && !chosenPakFileName.EndsWith(".bak")))
            {
                logger.Log("Invalid file name or file not found.");
                MessageBox.Show("Error: invalid file name or file not found.");
                return;
            }

            logger.Log("Operation started.");
            CopyPakOrBakFile(chosenPakFile, paksFolder);
            RenameCopies(paksFolder, chosenPakFileName);
            logger.Log("Operation completed successfully!");
            MessageBox.Show("Operation completed successfully! HAPPY MODDING!");
        }

        private void PakBypass_Click(object sender, EventArgs e)
        {
            RunPakBypassProgram();
        }

        private void CopyPakOrBakFile(string sourceFile, string destinationFolder)
        {
            logger.Log($"Copying {Path.GetFileName(sourceFile)} to {destinationFolder}");
            string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));
            try
            {
                File.Copy(sourceFile, destinationFile, true); // Overwrite if the file already exists
                logger.Log($"{Path.GetFileName(sourceFile)} copied successfully.");
            }
            catch (IOException ex)
            {
                logger.Log($"Error occurred while copying {Path.GetFileName(sourceFile)} to Paks folder: {ex.Message}");
                MessageBox.Show($"Error occurred while copying {Path.GetFileName(sourceFile)} to Paks folder: {ex.Message}");
            }
        }

        private void UpdateCopies(string paksFolder, string fileName) // Updating the copies 
        {
            logger.Log("Updating copies of pakchunk348-EGS.sig.");
            try
            {
                File.WriteAllText(Path.Combine(paksFolder, "pakchunk348-EGS - Copy.sig"), Path.GetFileNameWithoutExtension(fileName));
                File.WriteAllText(Path.Combine(paksFolder, "pakchunk348-EGS - Copy (2).sig"), Path.GetFileNameWithoutExtension(fileName));
                logger.Log("Copies updated successfully.");
            }
            catch (IOException ex)
            {
                logger.Log($"Error occurred while updating copies of pakchunk348-EGS.sig: {ex.Message}");
                MessageBox.Show($"Error occurred while updating copies of pakchunk348-EGS.sig: {ex.Message}");
            }
        }

        private void RenameCopies(string paksFolder, string fileName)
        {
            logger.Log("Renaming copies.");
            string renamedFile1 = Path.Combine(paksFolder, "pakchunk348-EGS - Copy.sig");
            string renamedFile2 = Path.Combine(paksFolder, "pakchunk348-EGS - Copy (2).sig");

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string newName1 = Path.Combine(paksFolder, $"{fileNameWithoutExtension}.sig");
            string newName2 = Path.Combine(paksFolder, $"{fileNameWithoutExtension}.kek");

            try
            {
                File.Move(renamedFile1, newName1);
                File.Move(renamedFile2, newName2);
                logger.Log("Files renamed successfully.");
            }
            catch (IOException ex)
            {
                logger.Log($"Error occurred while renaming files: {ex.Message}");
                MessageBox.Show($"Error occurred while renaming files: {ex.Message}");
            }
        }

        private void CreatePakSigCopies(string paksFolder)
        {
            string pakSigFile = Path.Combine(paksFolder, "pakchunk348-EGS.sig");

            if (File.Exists(pakSigFile))
            {
                // Make copies of the "pakchunk348-EGS.sig" file
                try
                {
                    logger.Log("Creating copies of pakchunk348-EGS.sig.");
                    File.Copy(pakSigFile, Path.Combine(paksFolder, "pakchunk348-EGS - Copy.sig"), true);
                    File.Copy(pakSigFile, Path.Combine(paksFolder, "pakchunk348-EGS - Copy (2).sig"), true);
                    logger.Log("Copies created successfully.");
                }
                catch (IOException ex)
                {
                    logger.Log($"Error occurred while copying files: {ex.Message}");
                    MessageBox.Show($"Error occurred while copying files: {ex.Message}");
                }
            }
            else
            {
                logger.Log("pakchunk348-EGS.sig not found.");
                MessageBox.Show("pakchunk348-EGS.sig is not found. Please select the Paks folder again.");
            }
        }

        private string ExtractPakBypassExecutable()
        {
            string exeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string tempFolderPath = Path.Combine(exeDirectory, "Temp");

            // Create a temporary folder if it doesn't exist
            Directory.CreateDirectory(tempFolderPath);

            // Path to the extracted PakBypass.exe
            string extractedFilePath = Path.Combine(tempFolderPath, "PakBypass.exe");

            // Check if PakBypass.exe already exists in the temporary folder
            if (!File.Exists(extractedFilePath))
            {
                // Extract PakBypass.exe from the embedded resource to the temporary folder
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DBDPakInstallerGUI2.PakBypass.PakBypass.exe"))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = new FileStream(extractedFilePath, FileMode.Create))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                    else
                    {
                        // Resource stream is null, indicating that the resource was not found
                        logger.Log("PakBypass.exe resource not found.");
                        MessageBox.Show("PakBypass.exe resource not found. Please ensure it is properly embedded.");
                    }
                }
            }

            return extractedFilePath;
        }

        private string FindPakBypassExecutable()
        {
            string extractedFilePath = ExtractPakBypassExecutable();

            if (!string.IsNullOrEmpty(extractedFilePath) && File.Exists(extractedFilePath))
            {
                return extractedFilePath;
            }

            // PakBypass.exe not found or failed to extract, return an empty string
            return string.Empty;
        }
        private void RunPakBypassProgram()
        {
            string pakBypassProgramPath = FindPakBypassExecutable();

            if (!string.IsNullOrEmpty(pakBypassProgramPath))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(pakBypassProgramPath);
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    logger.Log($"Error occurred while running the Pak Bypass program: {ex.Message}");
                    MessageBox.Show($"Error occurred while running the Pak Bypass program: {ex.Message}");
                }
            }
            else
            {
                logger.Log("Pak Bypass executable not found.");
                MessageBox.Show("The Pak Bypass executable was not found in the expected location.");
            }
        }


        public class Logger
        {
            private string logFilePath;

            public Logger(string logFilePath)
            {
                this.logFilePath = logFilePath;
            }

            public void Log(string message)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine($"{DateTime.Now.ToString()} - {message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while logging: {ex.Message}");
                }
            }
        }

    }
}
