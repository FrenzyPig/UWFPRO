using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWFCMD;

namespace UWFPRO
{
    public partial class MainForm : Form
    {
        static UWF_Filter uwf_filter = new UWF_Filter();
        static UWF_OverlayConfig uwf_OverlayConfig_CurrentSession = new UWF_OverlayConfig(true);
        static UWF_OverlayConfig uwf_OverlayConfig_NextSession = new UWF_OverlayConfig(false);
        static UWF_Volume uwf_Volume_CurrentSession = new UWF_Volume(true);
        static UWF_Volume uwf_Volume_NextSession = new UWF_Volume(false);
        static UWF_Overlay uwf_Overlay = new UWF_Overlay();
        static UWF_RegistryFilter uwf_Registry_Current = new UWF_RegistryFilter(true);
        static UWF_RegistryFilter uwf_Registry_Next = new UWF_RegistryFilter(false);
        public MainForm()
        {
            uwf_filter.GetConfig();
            uwf_OverlayConfig_CurrentSession.GetConfig();
            uwf_OverlayConfig_NextSession.GetConfig();
            uwf_Overlay.GetConfig();
            uwf_Volume_CurrentSession.GetExclusions();
            uwf_Registry_Next.GetExclusions();
            uwf_Registry_Current.GetExclusions();

            InitializeComponent();
        }




        void GetVolumeList()
        {
            dataGridView_Volume.Rows.Clear();
            Dictionary<string, bool> Dic_DriverLetterNow = uwf_Volume_CurrentSession.GetDriverLetters();
            Dictionary<string, bool> Dic_DriverLetterNext = uwf_Volume_NextSession.GetDriverLetters();
            foreach (var DATA in Dic_DriverLetterNow)
            {
                if (Dic_DriverLetterNext.ContainsKey(DATA.Key))
                    dataGridView_Volume.Rows.Add(DATA.Key, DATA.Value ? "已保护" : "不保护", Dic_DriverLetterNext[DATA.Key] ? "受保护" : "不保护");
                else
                    dataGridView_Volume.Rows.Add(DATA.Key, DATA.Value ? "已保护" : "不保护", "不保护");
            }


        }
        private void UpdateLabel(string text)
        {
            if (label_AvailableSpace.InvokeRequired)
            {
                label_AvailableSpace.Invoke(new Action(() => label_AvailableSpace.Text = text));
            }
            else
            {
                label_AvailableSpace.Text = text;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, bool> Dic_DriverLetterNow = uwf_Volume_CurrentSession.GetDriverLetters();
            Dictionary<string, bool> Dic_DriverLetterNext = uwf_Volume_NextSession.GetDriverLetters();
            comboBox_overlay_Type.SelectedIndex = (int)uwf_OverlayConfig_CurrentSession.Type;
            if (uwf_filter.CurrentEnabled)
            {
                comboBox_overlay_Type.Enabled = false;
                textBox_Overlay_Maxsize.Enabled = false;
            }
            if (uwf_filter.NextEnabled)
            {
                comboBox_filter_enable.SelectedIndex = 0;
            }
            else
            {
                comboBox_filter_enable.SelectedIndex = 1;
            }
            label_filter_Current.Text = "当前: " + (uwf_filter.CurrentEnabled ? "启用" : "禁用") + " 下次: " + (uwf_filter.NextEnabled ? "启用" : "禁用");
            label_Overlay_Type.Text = "覆盖类型: " + (uwf_OverlayConfig_NextSession.Type == 0 ? "内存" : "硬盘");
            textBox_Overlay_criticalSize.Text = uwf_Overlay.CriticalOverlayThreshold.ToString();
            textBox_Overlay_warningsize.Text = uwf_Overlay.WarningOverlayThreshold.ToString();
            textBox_Overlay_Maxsize.Text = uwf_OverlayConfig_NextSession.MaximumSize.ToString();
            GetVolumeList();
            get_listBox_File_exclusion_list();
            Thread updateThread = new Thread(UpdateAvailableSpace);
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        private void UpdateAvailableSpace()
        {
            while (true)
            {
                try
                {
                    // 连接 WMI
                    uwf_Overlay.GetConfig();
                    UpdateLabel(uwf_Overlay.AvailableSpace.ToString()+" MB");
                }
                catch (Exception ex)
                {
                    UpdateLabel($"Error: {ex.Message}");
                }

                // 等待 2 秒再更新
                Thread.Sleep(2000);
            }
        }
        private void comboBox_filter_enable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_filter_enable.SelectedIndex == 0)
            {
                uwf_filter.Enable();
            }
            else
            {
                uwf_filter.Disable();
            }
            uwf_filter.GetConfig();
            label_filter_Current.Text = "当前: " + (uwf_filter.CurrentEnabled ? "启用" : "禁用") + " 下次: " + (uwf_filter.NextEnabled ? "启用" : "禁用");
        }

        private void comboBox_overlay_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uwf_filter.CurrentEnabled == false)
                if (comboBox_overlay_Type.SelectedIndex == 0)
                {
                    uwf_OverlayConfig_NextSession.SetType(0);
                }
                else
                {
                    uwf_OverlayConfig_NextSession.SetType(1);
                }
            uwf_OverlayConfig_NextSession.GetConfig();
            label_Overlay_Type.Text = "覆盖类型: " + (uwf_OverlayConfig_NextSession.Type == 0 ? "内存" : "硬盘");
        }

        private void button_overlay_size_save_Click(object sender, EventArgs e)
        {
            if (uwf_filter.CurrentEnabled == false)
            {
                uwf_OverlayConfig_NextSession.SetMaximumSize(uint.Parse(this.textBox_Overlay_Maxsize.Text));
                uwf_OverlayConfig_NextSession.GetConfig();
                textBox_Overlay_Maxsize.Text = uwf_OverlayConfig_NextSession.MaximumSize.ToString();
            }
            uwf_Overlay.SetCriticalThreshold(uint.Parse(this.textBox_Overlay_criticalSize.Text));
            uwf_Overlay.SetWarningThreshold(uint.Parse(this.textBox_Overlay_warningsize.Text));
            uwf_Overlay.GetConfig();
            textBox_Overlay_criticalSize.Text = uwf_Overlay.CriticalOverlayThreshold.ToString();
            textBox_Overlay_warningsize.Text = uwf_Overlay.WarningOverlayThreshold.ToString();
        }

        private void dataGridView_Volume_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView_Volume.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView_Volume.ClearSelection();
                        dataGridView_Volume.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView_Volume.SelectedRows.Count == 1)
                    {
                        dataGridView_Volume.CurrentCell = dataGridView_Volume.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip_volume_protect.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void toolStripMenuItem_Protect_Click(object sender, EventArgs e)
        {
            if (uwf_Volume_CurrentSession.Protect(dataGridView_Volume.SelectedRows[0].Cells[0].Value.ToString()))
            {
                MessageBox.Show(dataGridView_Volume.SelectedRows[0].Cells[0].Value.ToString() + " 保护成功!");
                GetVolumeList();
            }
        }

        private void toolStripMenuItem_unprotect_Click(object sender, EventArgs e)
        {
            uwf_Volume_CurrentSession.Unprotect(dataGridView_Volume.SelectedRows[0].Cells[0].Value.ToString());
            GetVolumeList();
        }

        private void button_ExclusionList_current_Click(object sender, EventArgs e)
        {
            listBox_File_exclusion_list.Items.Clear();
            foreach (var DATA in uwf_Volume_CurrentSession.Dic_FileExclusion)
            {
                foreach (var DATA2 in DATA.Value)
                {
                    listBox_File_exclusion_list.Items.Add(DATA.Key + DATA2);
                }
            }
            foreach (var DATA in uwf_Registry_Current.List_RegistryExclusions)
            {
                listBox_File_exclusion_list.Items.Add(DATA);
            }
        }
        void get_listBox_File_exclusion_list()
        {
            listBox_File_exclusion_list.Items.Clear();
            uwf_Volume_NextSession.GetExclusions();
            uwf_Registry_Next.GetExclusions();
            foreach (var DATA in uwf_Volume_NextSession.Dic_FileExclusion)
            {
                foreach (var DATA2 in DATA.Value)
                {
                    listBox_File_exclusion_list.Items.Add(DATA.Key + DATA2);
                }
            }
            foreach (var DATA in uwf_Registry_Next.List_RegistryExclusions)
            {
                listBox_File_exclusion_list.Items.Add(DATA);
            }
        }

        private void button_ExclusionList_Next_Click(object sender, EventArgs e)
        {
            get_listBox_File_exclusion_list();
        }

        private void ToolStripMenuItem_delete_item_seleted_Click(object sender, EventArgs e)
        {
            if (listBox_File_exclusion_list.SelectedItem != null && listBox_File_exclusion_list.SelectedItem.ToString().StartsWith("HK") != true)
            {
                uwf_Volume_NextSession.RemoveExclusion(listBox_File_exclusion_list.SelectedItem.ToString());
            }
            if (listBox_File_exclusion_list.SelectedItem != null && listBox_File_exclusion_list.SelectedItem.ToString().StartsWith("HK") == true)
            {
                uwf_Registry_Next.RemoveExclusion(listBox_File_exclusion_list.SelectedItem.ToString());
            }
            get_listBox_File_exclusion_list();
        }

        private void button_file_select_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.textBox_filepath.Text = openFileDialog.FileName;
                }
            }
        }

        private void button_path_select_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.textBox_filepath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void button_file_commit_Click(object sender, EventArgs e)
        {
            if (uwf_Volume_CurrentSession.CommitFile(this.textBox_filepath.Text))
                MessageBox.Show("提交成功!");
        }

        private void button_file_addexclusion_Click(object sender, EventArgs e)
        {
            if (uwf_Volume_NextSession.AddExclusion(this.textBox_filepath.Text))
                get_listBox_File_exclusion_list();
        }

        private void button_delete_commit_Click(object sender, EventArgs e)
        {
            if (uwf_Volume_NextSession.CommitFileDeletion(this.textBox_filepath.Text))
            {
                MessageBox.Show("删除提交成功!");
            }
        }

        private void button_regedit_addexclusion_Click(object sender, EventArgs e)
        {
            if (uwf_Registry_Next.AddExclusion(this.textBox_regedit_path.Text))
            {
                get_listBox_File_exclusion_list();
            }
        }

        private void button_save_exclusionlist_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.FileName = "EXCLUSIONLIST_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt"; // 设置预设文件名
                dlg.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filename = dlg.FileName;
                    if (listBox_File_exclusion_list.Items.Count > 0)
                    {
                        using (StreamWriter sw = new StreamWriter(filename, false))
                        {
                            foreach (var DATA in listBox_File_exclusion_list.Items)
                            {
                                sw.WriteLine(DATA.ToString());
                            }
                        }
                    }
                }
            }
        }
        private void button_import_list_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filename = dlg.FileName;
                    string filepath = "";
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        while ((filepath = sr.ReadLine()) != null)
                        {
                            if (filepath.StartsWith("HK"))
                            {
                                uwf_Registry_Next.AddExclusion(filepath);
                            }
                            else
                            {
                                uwf_Volume_NextSession.AddExclusion(filepath);
                            }

                        }
                    }
                    get_listBox_File_exclusion_list();
                }
            }

        }

        private void button_regedit_commit_Click(object sender, EventArgs e)
        {
            if (uwf_Registry_Current.CommitRegistry(this.textBox_regedit_path.Text))
                MessageBox.Show("提交成功!");
        }
    }
}
