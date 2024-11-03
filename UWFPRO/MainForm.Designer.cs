namespace UWFPRO
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_Overlay_Type = new System.Windows.Forms.Label();
            this.label_filter_Current = new System.Windows.Forms.Label();
            this.comboBox_overlay_Type = new System.Windows.Forms.ComboBox();
            this.comboBox_filter_enable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Overlay_warningsize = new System.Windows.Forms.TextBox();
            this.textBox_Overlay_criticalSize = new System.Windows.Forms.TextBox();
            this.textBox_Overlay_Maxsize = new System.Windows.Forms.TextBox();
            this.button_overlay_size_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Volume = new System.Windows.Forms.DataGridView();
            this.Column_DriverLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CurrentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NextStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip_volume_protect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Protect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_unprotect = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_ExclusionList_Next = new System.Windows.Forms.Button();
            this.button_ExclusionList_current = new System.Windows.Forms.Button();
            this.button_save_exclusionlist = new System.Windows.Forms.Button();
            this.button_import_list = new System.Windows.Forms.Button();
            this.listBox_File_exclusion_list = new System.Windows.Forms.ListBox();
            this.contextMenuStrip_Exclusion_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_delete_item_seleted = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_regedit_commit = new System.Windows.Forms.Button();
            this.button_regedit_addexclusion = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_regedit_path = new System.Windows.Forms.TextBox();
            this.button_file_commit = new System.Windows.Forms.Button();
            this.button_file_addexclusion = new System.Windows.Forms.Button();
            this.button_path_select = new System.Windows.Forms.Button();
            this.button_file_select = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_filepath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Volume)).BeginInit();
            this.contextMenuStrip_volume_protect.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip_Exclusion_menu.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_Overlay_Type);
            this.groupBox1.Controls.Add(this.label_filter_Current);
            this.groupBox1.Controls.Add(this.comboBox_overlay_Type);
            this.groupBox1.Controls.Add(this.comboBox_filter_enable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 208);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // label_Overlay_Type
            // 
            this.label_Overlay_Type.AutoSize = true;
            this.label_Overlay_Type.Location = new System.Drawing.Point(6, 172);
            this.label_Overlay_Type.Name = "label_Overlay_Type";
            this.label_Overlay_Type.Size = new System.Drawing.Size(78, 21);
            this.label_Overlay_Type.TabIndex = 6;
            this.label_Overlay_Type.Text = "覆盖类型:";
            // 
            // label_filter_Current
            // 
            this.label_filter_Current.AutoSize = true;
            this.label_filter_Current.Location = new System.Drawing.Point(6, 140);
            this.label_filter_Current.Name = "label_filter_Current";
            this.label_filter_Current.Size = new System.Drawing.Size(161, 21);
            this.label_filter_Current.TabIndex = 5;
            this.label_filter_Current.Text = "当前: 启用 下次: 启用";
            // 
            // comboBox_overlay_Type
            // 
            this.comboBox_overlay_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_overlay_Type.FormattingEnabled = true;
            this.comboBox_overlay_Type.Items.AddRange(new object[] {
            "内存",
            "硬盘"});
            this.comboBox_overlay_Type.Location = new System.Drawing.Point(99, 90);
            this.comboBox_overlay_Type.Name = "comboBox_overlay_Type";
            this.comboBox_overlay_Type.Size = new System.Drawing.Size(80, 29);
            this.comboBox_overlay_Type.TabIndex = 4;
            this.comboBox_overlay_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_overlay_Type_SelectedIndexChanged);
            // 
            // comboBox_filter_enable
            // 
            this.comboBox_filter_enable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filter_enable.FormattingEnabled = true;
            this.comboBox_filter_enable.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.comboBox_filter_enable.Location = new System.Drawing.Point(99, 36);
            this.comboBox_filter_enable.Name = "comboBox_filter_enable";
            this.comboBox_filter_enable.Size = new System.Drawing.Size(80, 29);
            this.comboBox_filter_enable.TabIndex = 3;
            this.comboBox_filter_enable.SelectedIndexChanged += new System.EventHandler(this.comboBox_filter_enable_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "覆盖类型:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "写入过滤:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Overlay_warningsize);
            this.groupBox2.Controls.Add(this.textBox_Overlay_criticalSize);
            this.groupBox2.Controls.Add(this.textBox_Overlay_Maxsize);
            this.groupBox2.Controls.Add(this.button_overlay_size_save);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 231);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "缓存设置(MB)";
            // 
            // textBox_Overlay_warningsize
            // 
            this.textBox_Overlay_warningsize.Location = new System.Drawing.Point(90, 119);
            this.textBox_Overlay_warningsize.Name = "textBox_Overlay_warningsize";
            this.textBox_Overlay_warningsize.Size = new System.Drawing.Size(100, 29);
            this.textBox_Overlay_warningsize.TabIndex = 11;
            // 
            // textBox_Overlay_criticalSize
            // 
            this.textBox_Overlay_criticalSize.Location = new System.Drawing.Point(90, 75);
            this.textBox_Overlay_criticalSize.Name = "textBox_Overlay_criticalSize";
            this.textBox_Overlay_criticalSize.Size = new System.Drawing.Size(100, 29);
            this.textBox_Overlay_criticalSize.TabIndex = 10;
            // 
            // textBox_Overlay_Maxsize
            // 
            this.textBox_Overlay_Maxsize.Location = new System.Drawing.Point(90, 33);
            this.textBox_Overlay_Maxsize.Name = "textBox_Overlay_Maxsize";
            this.textBox_Overlay_Maxsize.Size = new System.Drawing.Size(100, 29);
            this.textBox_Overlay_Maxsize.TabIndex = 9;
            // 
            // button_overlay_size_save
            // 
            this.button_overlay_size_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_overlay_size_save.Location = new System.Drawing.Point(34, 174);
            this.button_overlay_size_save.Name = "button_overlay_size_save";
            this.button_overlay_size_save.Size = new System.Drawing.Size(109, 41);
            this.button_overlay_size_save.TabIndex = 8;
            this.button_overlay_size_save.Text = "确认保存";
            this.button_overlay_size_save.UseVisualStyleBackColor = true;
            this.button_overlay_size_save.Click += new System.EventHandler(this.button_overlay_size_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "警告阈值:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "严重阈值:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "最大缓存:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_Volume);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(218, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 445);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分区保护设置(右键修改状态)";
            // 
            // dataGridView_Volume
            // 
            this.dataGridView_Volume.AllowUserToAddRows = false;
            this.dataGridView_Volume.AllowUserToDeleteRows = false;
            this.dataGridView_Volume.AllowUserToResizeColumns = false;
            this.dataGridView_Volume.AllowUserToResizeRows = false;
            this.dataGridView_Volume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Volume.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_DriverLetter,
            this.Column_CurrentStatus,
            this.Column_NextStatus});
            this.dataGridView_Volume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Volume.Location = new System.Drawing.Point(3, 25);
            this.dataGridView_Volume.MultiSelect = false;
            this.dataGridView_Volume.Name = "dataGridView_Volume";
            this.dataGridView_Volume.ReadOnly = true;
            this.dataGridView_Volume.RowHeadersVisible = false;
            this.dataGridView_Volume.RowTemplate.Height = 23;
            this.dataGridView_Volume.RowTemplate.ReadOnly = true;
            this.dataGridView_Volume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Volume.ShowEditingIcon = false;
            this.dataGridView_Volume.Size = new System.Drawing.Size(307, 417);
            this.dataGridView_Volume.TabIndex = 0;
            this.dataGridView_Volume.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Volume_CellMouseDown);
            // 
            // Column_DriverLetter
            // 
            this.Column_DriverLetter.HeaderText = "分区";
            this.Column_DriverLetter.Name = "Column_DriverLetter";
            this.Column_DriverLetter.ReadOnly = true;
            // 
            // Column_CurrentStatus
            // 
            this.Column_CurrentStatus.HeaderText = "当前状态";
            this.Column_CurrentStatus.Name = "Column_CurrentStatus";
            this.Column_CurrentStatus.ReadOnly = true;
            // 
            // Column_NextStatus
            // 
            this.Column_NextStatus.HeaderText = "下次状态";
            this.Column_NextStatus.Name = "Column_NextStatus";
            this.Column_NextStatus.ReadOnly = true;
            // 
            // contextMenuStrip_volume_protect
            // 
            this.contextMenuStrip_volume_protect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Protect,
            this.toolStripMenuItem_unprotect});
            this.contextMenuStrip_volume_protect.Name = "contextMenuStrip1";
            this.contextMenuStrip_volume_protect.Size = new System.Drawing.Size(113, 48);
            // 
            // toolStripMenuItem_Protect
            // 
            this.toolStripMenuItem_Protect.Name = "toolStripMenuItem_Protect";
            this.toolStripMenuItem_Protect.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem_Protect.Text = "受保护";
            this.toolStripMenuItem_Protect.Click += new System.EventHandler(this.toolStripMenuItem_Protect_Click);
            // 
            // toolStripMenuItem_unprotect
            // 
            this.toolStripMenuItem_unprotect.Name = "toolStripMenuItem_unprotect";
            this.toolStripMenuItem_unprotect.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem_unprotect.Text = "不保护";
            this.toolStripMenuItem_unprotect.Click += new System.EventHandler(this.toolStripMenuItem_unprotect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_ExclusionList_Next);
            this.groupBox3.Controls.Add(this.button_ExclusionList_current);
            this.groupBox3.Controls.Add(this.button_save_exclusionlist);
            this.groupBox3.Controls.Add(this.button_import_list);
            this.groupBox3.Controls.Add(this.listBox_File_exclusion_list);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(537, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 638);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "排除列表";
            // 
            // button_ExclusionList_Next
            // 
            this.button_ExclusionList_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExclusionList_Next.Location = new System.Drawing.Point(350, 591);
            this.button_ExclusionList_Next.Name = "button_ExclusionList_Next";
            this.button_ExclusionList_Next.Size = new System.Drawing.Size(109, 41);
            this.button_ExclusionList_Next.TabIndex = 15;
            this.button_ExclusionList_Next.Text = "下次列表";
            this.button_ExclusionList_Next.UseVisualStyleBackColor = true;
            this.button_ExclusionList_Next.Click += new System.EventHandler(this.button_ExclusionList_Next_Click);
            // 
            // button_ExclusionList_current
            // 
            this.button_ExclusionList_current.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExclusionList_current.Location = new System.Drawing.Point(236, 591);
            this.button_ExclusionList_current.Name = "button_ExclusionList_current";
            this.button_ExclusionList_current.Size = new System.Drawing.Size(109, 41);
            this.button_ExclusionList_current.TabIndex = 14;
            this.button_ExclusionList_current.Text = "当前列表";
            this.button_ExclusionList_current.UseVisualStyleBackColor = true;
            this.button_ExclusionList_current.Click += new System.EventHandler(this.button_ExclusionList_current_Click);
            // 
            // button_save_exclusionlist
            // 
            this.button_save_exclusionlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save_exclusionlist.Location = new System.Drawing.Point(121, 591);
            this.button_save_exclusionlist.Name = "button_save_exclusionlist";
            this.button_save_exclusionlist.Size = new System.Drawing.Size(109, 41);
            this.button_save_exclusionlist.TabIndex = 13;
            this.button_save_exclusionlist.Text = "保存列表";
            this.button_save_exclusionlist.UseVisualStyleBackColor = true;
            this.button_save_exclusionlist.Click += new System.EventHandler(this.button_save_exclusionlist_Click);
            // 
            // button_import_list
            // 
            this.button_import_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_import_list.Location = new System.Drawing.Point(6, 591);
            this.button_import_list.Name = "button_import_list";
            this.button_import_list.Size = new System.Drawing.Size(109, 41);
            this.button_import_list.TabIndex = 12;
            this.button_import_list.Text = "导入列表";
            this.button_import_list.UseVisualStyleBackColor = true;
            this.button_import_list.Click += new System.EventHandler(this.button_import_list_Click);
            // 
            // listBox_File_exclusion_list
            // 
            this.listBox_File_exclusion_list.ContextMenuStrip = this.contextMenuStrip_Exclusion_menu;
            this.listBox_File_exclusion_list.FormattingEnabled = true;
            this.listBox_File_exclusion_list.HorizontalScrollbar = true;
            this.listBox_File_exclusion_list.ItemHeight = 21;
            this.listBox_File_exclusion_list.Location = new System.Drawing.Point(6, 25);
            this.listBox_File_exclusion_list.Name = "listBox_File_exclusion_list";
            this.listBox_File_exclusion_list.Size = new System.Drawing.Size(453, 550);
            this.listBox_File_exclusion_list.Sorted = true;
            this.listBox_File_exclusion_list.TabIndex = 0;
            // 
            // contextMenuStrip_Exclusion_menu
            // 
            this.contextMenuStrip_Exclusion_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_delete_item_seleted});
            this.contextMenuStrip_Exclusion_menu.Name = "contextMenuStrip1";
            this.contextMenuStrip_Exclusion_menu.Size = new System.Drawing.Size(137, 26);
            // 
            // ToolStripMenuItem_delete_item_seleted
            // 
            this.ToolStripMenuItem_delete_item_seleted.Name = "ToolStripMenuItem_delete_item_seleted";
            this.ToolStripMenuItem_delete_item_seleted.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem_delete_item_seleted.Text = "删除当前项";
            this.ToolStripMenuItem_delete_item_seleted.Click += new System.EventHandler(this.ToolStripMenuItem_delete_item_seleted_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_regedit_commit);
            this.groupBox5.Controls.Add(this.button_regedit_addexclusion);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.textBox_regedit_path);
            this.groupBox5.Controls.Add(this.button_file_commit);
            this.groupBox5.Controls.Add(this.button_file_addexclusion);
            this.groupBox5.Controls.Add(this.button_path_select);
            this.groupBox5.Controls.Add(this.button_file_select);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBox_filepath);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(12, 463);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(519, 187);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "文件/注册表控制";
            // 
            // button_regedit_commit
            // 
            this.button_regedit_commit.Location = new System.Drawing.Point(325, 151);
            this.button_regedit_commit.Name = "button_regedit_commit";
            this.button_regedit_commit.Size = new System.Drawing.Size(91, 30);
            this.button_regedit_commit.TabIndex = 13;
            this.button_regedit_commit.Text = "提交保存";
            this.button_regedit_commit.UseVisualStyleBackColor = true;
            this.button_regedit_commit.Click += new System.EventHandler(this.button_regedit_commit_Click);
            // 
            // button_regedit_addexclusion
            // 
            this.button_regedit_addexclusion.Location = new System.Drawing.Point(422, 152);
            this.button_regedit_addexclusion.Name = "button_regedit_addexclusion";
            this.button_regedit_addexclusion.Size = new System.Drawing.Size(91, 30);
            this.button_regedit_addexclusion.TabIndex = 12;
            this.button_regedit_addexclusion.Text = "添加排除";
            this.button_regedit_addexclusion.UseVisualStyleBackColor = true;
            this.button_regedit_addexclusion.Click += new System.EventHandler(this.button_regedit_addexclusion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "注册表:";
            // 
            // textBox_regedit_path
            // 
            this.textBox_regedit_path.Location = new System.Drawing.Point(74, 108);
            this.textBox_regedit_path.Name = "textBox_regedit_path";
            this.textBox_regedit_path.Size = new System.Drawing.Size(439, 29);
            this.textBox_regedit_path.TabIndex = 7;
            // 
            // button_file_commit
            // 
            this.button_file_commit.Location = new System.Drawing.Point(325, 72);
            this.button_file_commit.Name = "button_file_commit";
            this.button_file_commit.Size = new System.Drawing.Size(91, 30);
            this.button_file_commit.TabIndex = 5;
            this.button_file_commit.Text = "提交保存";
            this.button_file_commit.UseVisualStyleBackColor = true;
            this.button_file_commit.Click += new System.EventHandler(this.button_file_commit_Click);
            // 
            // button_file_addexclusion
            // 
            this.button_file_addexclusion.Location = new System.Drawing.Point(422, 72);
            this.button_file_addexclusion.Name = "button_file_addexclusion";
            this.button_file_addexclusion.Size = new System.Drawing.Size(91, 30);
            this.button_file_addexclusion.TabIndex = 4;
            this.button_file_addexclusion.Text = "添加排除";
            this.button_file_addexclusion.UseVisualStyleBackColor = true;
            this.button_file_addexclusion.Click += new System.EventHandler(this.button_file_addexclusion_Click);
            // 
            // button_path_select
            // 
            this.button_path_select.Location = new System.Drawing.Point(228, 73);
            this.button_path_select.Name = "button_path_select";
            this.button_path_select.Size = new System.Drawing.Size(91, 29);
            this.button_path_select.TabIndex = 3;
            this.button_path_select.Text = "路径选择";
            this.button_path_select.UseVisualStyleBackColor = true;
            this.button_path_select.Click += new System.EventHandler(this.button_path_select_Click);
            // 
            // button_file_select
            // 
            this.button_file_select.Location = new System.Drawing.Point(131, 73);
            this.button_file_select.Name = "button_file_select";
            this.button_file_select.Size = new System.Drawing.Size(91, 30);
            this.button_file_select.TabIndex = 2;
            this.button_file_select.Text = "文件选择";
            this.button_file_select.UseVisualStyleBackColor = true;
            this.button_file_select.Click += new System.EventHandler(this.button_file_select_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "路径:";
            // 
            // textBox_filepath
            // 
            this.textBox_filepath.Location = new System.Drawing.Point(74, 28);
            this.textBox_filepath.Name = "textBox_filepath";
            this.textBox_filepath.Size = new System.Drawing.Size(439, 29);
            this.textBox_filepath.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 700);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "MainForm";
            this.Text = "UWFPRO [made by alechy] FREE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Volume)).EndInit();
            this.contextMenuStrip_volume_protect.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip_Exclusion_menu.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_filter_enable;
        private System.Windows.Forms.ComboBox comboBox_overlay_Type;
        private System.Windows.Forms.Label label_filter_Current;
        private System.Windows.Forms.Label label_Overlay_Type;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Overlay_warningsize;
        private System.Windows.Forms.TextBox textBox_Overlay_criticalSize;
        private System.Windows.Forms.TextBox textBox_Overlay_Maxsize;
        private System.Windows.Forms.Button button_overlay_size_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView_Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DriverLetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CurrentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NextStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_volume_protect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Protect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_unprotect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox_File_exclusion_list;
        private System.Windows.Forms.Button button_save_exclusionlist;
        private System.Windows.Forms.Button button_import_list;
        private System.Windows.Forms.Button button_ExclusionList_Next;
        private System.Windows.Forms.Button button_ExclusionList_current;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Exclusion_menu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_delete_item_seleted;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_path_select;
        private System.Windows.Forms.Button button_file_select;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_filepath;
        private System.Windows.Forms.Button button_file_addexclusion;
        private System.Windows.Forms.Button button_file_commit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_regedit_path;
        private System.Windows.Forms.Button button_regedit_commit;
        private System.Windows.Forms.Button button_regedit_addexclusion;
    }
}

