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
        private string modsListFilePath;
        private List<string> selectedFilePaths = new List<string>();


        public dbdPakInstaller()
        {
            InitializeComponent();

            LoadSelectedFilePaths();
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
            // set the modlist path to modList.txt in the app directory
            modsListFilePath = Path.Combine(appDirectory, "modsList.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSelectedFilePaths();

            //modsList.Items.Clear();
            modsList.Items.AddRange(selectedFilePaths.Select(Path.GetFileName).ToArray());
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
                    //selectedFilePaths.Clear(); // Clear the selected file paths list
                    selectedFilePaths.AddRange(openFileDialog.FileNames); // Add the selected file paths to the list
                    //modsList.Items.Clear(); // Clear the modsList
                    modsList.Items.AddRange(openFileDialog.FileNames.Select(Path.GetFileName).ToArray()); // Add the selected file names to the modsList

                    // Write the selected file names to modsList.txt
                    try
                    {
                        File.AppendAllLines(modsListFilePath, openFileDialog.FileNames.Select(Path.GetFileName));
                        logger.Log("Selected file names saved to modsList.txt");
                    }
                    catch (Exception ex)
                    {
                        logger.Log($"Error occurred while saving selected file names to modsList.txt: {ex.Message}");
                    }

                    logger.Log($"PAK or BAK files selected: {string.Join(", ", openFileDialog.FileNames)}");

                    // Check whether the Paks folder is valid
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

        private void Uninstall_Click(object sender, EventArgs e)
        {
            // Read the Paks folder path from PaksFolderPath.txt
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string paksFolderPathFile = Path.Combine(appDirectory, "PaksFolderPath.txt");
            string paksFolderPath = File.Exists(paksFolderPathFile) ? File.ReadAllText(paksFolderPathFile).Trim() : "";

            if (modsList.SelectedIndex != -1)
            {
                // Get the selected item's index
                int selectedIndex = modsList.SelectedIndex;

                // Get the corresponding file path from the selectedFilePaths list
                string selectedFilePath = selectedFilePaths[selectedIndex];
                string selectedFileName = Path.GetFileName(selectedFilePath);

                // Remove the selected file from the Paks folder
                string pakFilePath = Path.Combine(paksFolderPath, selectedFileName);
                string sigFilePath = Path.Combine(paksFolderPath, $"{Path.GetFileNameWithoutExtension(selectedFileName)}.sig");
                string kekFilePath = Path.Combine(paksFolderPath, $"{Path.GetFileNameWithoutExtension(selectedFileName)}.kek");

                // Ask for confirmation before uninstalling
                DialogResult result = MessageBox.Show($"Are you sure you want to uninstall {selectedFileName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the PAK/BAK file and its copies
                        File.Delete(pakFilePath);
                        File.Delete(sigFilePath);
                        File.Delete(kekFilePath);

                        logger.Log($"Files removed: {selectedFileName}, {Path.GetFileName(sigFilePath)}, {Path.GetFileName(kekFilePath)}");
                        MessageBox.Show($"Files removed: {selectedFileName}, {Path.GetFileName(sigFilePath)}, {Path.GetFileName(kekFilePath)}");

                        // Remove the item from the modsList and selectedFilePaths lists
                        modsList.Items.RemoveAt(selectedIndex);
                        selectedFilePaths.RemoveAt(selectedIndex);

                        // Save the updated selected file paths back to modsList.txt
                        SaveSelectedFilePaths();

                        // Update modsList.txt by writing the updated list of file names
                        File.WriteAllLines(modsListFilePath, selectedFilePaths);

                        logger.Log("Updated modsList.txt with the removed file.");

                    }
                    catch (IOException ex)
                    {
                        logger.Log($"Error occurred while removing files: {ex.Message}");
                        MessageBox.Show($"Error occurred while removing files: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a file to uninstall.");
            }
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

        private void UpdateCopies(string paksFolder, string fileName) // Updating the copies of pakchunk348-EGS.sig
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

    
        private void LoadSelectedFilePaths()
        {

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            modsListFilePath = Path.Combine(appDirectory, "modsList.txt");

            // Check if the modsList.txt file exists
            if (File.Exists(modsListFilePath))
            {
                try
                {
                    // Read the file names from modsList.txt
                    var fileNames = File.ReadAllLines(modsListFilePath);

                    // Add the file names to the selectedFilePaths list
                    selectedFilePaths.AddRange(fileNames.Except(selectedFilePaths));
                }
                catch (Exception ex)
                {
                    logger.Log($"Error occurred while loading selected file names from modsList.txt: {ex.Message}");
                }
            }

        }

        private void SaveSelectedFilePaths()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string modsListFilePath = Path.Combine(appDirectory, "modsList.txt");

            if (selectedFilePaths.Count > 0)
            {
                try
                {
                    File.WriteAllLines(modsListFilePath, selectedFilePaths);
                    logger.Log("Selected file paths saved to modsList.txt");
                }
                catch (Exception ex)
                {
                    logger.Log($"Error occurred while saving selected file paths: {ex.Message}");
                }
            }
            else
            {
                logger.Log("No selected file paths to save.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSelectedFilePaths();
            }
            catch (Exception ex)
            {
                logger.Log($"Error occurred while saving selected file paths: {ex.Message}");
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

        private void modsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modsList.SelectedIndex != -1)
            {
                // Get the selected item's index
                int selectedIndex = modsList.SelectedIndex;

                // Get the corresponding file path from the selectedFilePaths list
                string selectedFilePath = selectedFilePaths[selectedIndex];
               
            }
        }
    }
}
