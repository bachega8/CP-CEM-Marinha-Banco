<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainform))
        Me.dg_main = New System.Windows.Forms.DataGridView()
        Me.ano_cbox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tema_cbox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbox_assuntos = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoFitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StrechtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuestãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeradorDeProvasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.total_lbl = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dg_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_main
        '
        Me.dg_main.AllowUserToAddRows = False
        Me.dg_main.AllowUserToDeleteRows = False
        Me.dg_main.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dg_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_main.Location = New System.Drawing.Point(12, 158)
        Me.dg_main.Name = "dg_main"
        Me.dg_main.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dg_main.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_main.Size = New System.Drawing.Size(556, 362)
        Me.dg_main.TabIndex = 8
        '
        'ano_cbox
        '
        Me.ano_cbox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ano_cbox.FormattingEnabled = True
        Me.ano_cbox.Items.AddRange(New Object() {"2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "todos"})
        Me.ano_cbox.Location = New System.Drawing.Point(81, 51)
        Me.ano_cbox.Name = "ano_cbox"
        Me.ano_cbox.Size = New System.Drawing.Size(99, 23)
        Me.ano_cbox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ano:"
        '
        'tema_cbox
        '
        Me.tema_cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tema_cbox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tema_cbox.FormattingEnabled = True
        Me.tema_cbox.Location = New System.Drawing.Point(81, 82)
        Me.tema_cbox.Name = "tema_cbox"
        Me.tema_cbox.Size = New System.Drawing.Size(173, 23)
        Me.tema_cbox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tema:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Assunto:"
        '
        'cbox_assuntos
        '
        Me.cbox_assuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbox_assuntos.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbox_assuntos.FormattingEnabled = True
        Me.cbox_assuntos.Location = New System.Drawing.Point(81, 112)
        Me.cbox_assuntos.Name = "cbox_assuntos"
        Me.cbox_assuntos.Size = New System.Drawing.Size(249, 23)
        Me.cbox_assuntos.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 26)
        '
        'TileToolStripMenuItem
        '
        Me.TileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoFitToolStripMenuItem, Me.ZoomToolStripMenuItem, Me.StrechtToolStripMenuItem, Me.CenterToolStripMenuItem, Me.NormalToolStripMenuItem})
        Me.TileToolStripMenuItem.Name = "TileToolStripMenuItem"
        Me.TileToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.TileToolStripMenuItem.Text = "Size Mode"
        '
        'AutoFitToolStripMenuItem
        '
        Me.AutoFitToolStripMenuItem.Name = "AutoFitToolStripMenuItem"
        Me.AutoFitToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.AutoFitToolStripMenuItem.Text = "AutoSize"
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ZoomToolStripMenuItem.Text = "Zoom"
        '
        'StrechtToolStripMenuItem
        '
        Me.StrechtToolStripMenuItem.Name = "StrechtToolStripMenuItem"
        Me.StrechtToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.StrechtToolStripMenuItem.Text = "Stretch"
        '
        'CenterToolStripMenuItem
        '
        Me.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem"
        Me.CenterToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.CenterToolStripMenuItem.Text = "Center"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.NormalToolStripMenuItem.Text = "Normal"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SistemaToolStripMenuItem, Me.CadastroToolStripMenuItem, Me.GeradorDeProvasToolStripMenuItem, Me.SobreToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 26)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtualizarToolStripMenuItem})
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(60, 22)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        '
        'AtualizarToolStripMenuItem
        '
        Me.AtualizarToolStripMenuItem.Image = Global.BD_QUESTOES_MARINHA.My.Resources.Resources.reload
        Me.AtualizarToolStripMenuItem.Name = "AtualizarToolStripMenuItem"
        Me.AtualizarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.AtualizarToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AtualizarToolStripMenuItem.Text = "Atualizar Dados"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuestãoToolStripMenuItem, Me.TemaToolStripMenuItem, Me.AssuntoToolStripMenuItem})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(66, 22)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'QuestãoToolStripMenuItem
        '
        Me.QuestãoToolStripMenuItem.Image = CType(resources.GetObject("QuestãoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuestãoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Maroon
        Me.QuestãoToolStripMenuItem.Name = "QuestãoToolStripMenuItem"
        Me.QuestãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.QuestãoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.QuestãoToolStripMenuItem.Text = "Questão"
        '
        'TemaToolStripMenuItem
        '
        Me.TemaToolStripMenuItem.Image = CType(resources.GetObject("TemaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TemaToolStripMenuItem.Name = "TemaToolStripMenuItem"
        Me.TemaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.TemaToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.TemaToolStripMenuItem.Text = "Tema"
        '
        'AssuntoToolStripMenuItem
        '
        Me.AssuntoToolStripMenuItem.Image = CType(resources.GetObject("AssuntoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AssuntoToolStripMenuItem.Name = "AssuntoToolStripMenuItem"
        Me.AssuntoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.AssuntoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.AssuntoToolStripMenuItem.Text = "Assunto"
        '
        'GeradorDeProvasToolStripMenuItem
        '
        Me.GeradorDeProvasToolStripMenuItem.Image = CType(resources.GetObject("GeradorDeProvasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GeradorDeProvasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GeradorDeProvasToolStripMenuItem.Name = "GeradorDeProvasToolStripMenuItem"
        Me.GeradorDeProvasToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.GeradorDeProvasToolStripMenuItem.Text = "Gerador de Provas"
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(49, 22)
        Me.SobreToolStripMenuItem.Text = "Sobre"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button5.Location = New System.Drawing.Point(651, 29)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 29)
        Me.Button5.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.Button5, "Remover questão selecionada")
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button3.Location = New System.Drawing.Point(617, 29)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 29)
        Me.Button3.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.Button3, "Mostrar gabarito")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button2.Location = New System.Drawing.Point(584, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 29)
        Me.Button2.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.Button2, "Salvar Imagem")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button4.Location = New System.Drawing.Point(686, 29)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 29)
        Me.Button4.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.Button4, "Editar Questão Selecionada")
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(441, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Questões encontradas"
        '
        'total_lbl
        '
        Me.total_lbl.AutoSize = True
        Me.total_lbl.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total_lbl.ForeColor = System.Drawing.Color.Red
        Me.total_lbl.Location = New System.Drawing.Point(416, 142)
        Me.total_lbl.Name = "total_lbl"
        Me.total_lbl.Size = New System.Drawing.Size(13, 13)
        Me.total_lbl.TabIndex = 14
        Me.total_lbl.Text = "0"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(336, 106)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 33)
        Me.Button1.TabIndex = 7
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Location = New System.Drawing.Point(585, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(437, 459)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1034, 549)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.total_lbl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbox_assuntos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tema_cbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ano_cbox)
        Me.Controls.Add(Me.dg_main)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mainform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Banco de Questões - CP-CEM / Marinha  vs 1.2.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_main As System.Windows.Forms.DataGridView
    Friend WithEvents ano_cbox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tema_cbox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbox_assuntos As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CadastroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuestãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents AtualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoFitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StrechtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents total_lbl As System.Windows.Forms.Label
    Friend WithEvents GeradorDeProvasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
