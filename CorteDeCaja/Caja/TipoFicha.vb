'Descripcion: Pantalla que permite agregar un TipoFicha con sus respectivos tipomovimientocaja y bancos(para el caso tipocosto = 3)
'Fecha: Agosto 25,2005
'Autor: Liliana C.

Imports System.Data
Imports System.Data.SqlClient
Public Class TipoFicha
    Inherits System.Windows.Forms.Form

    Private VGN_ConsecutivoFicha As Integer
    Public VGN_Ficha As Boolean
    Private VGN_TipoCobro As Integer
    Dim BancosL, BancosNames, CheckedBancos As New ArrayList() 'Arreglo para guardar los Bancos 
    Dim TipoMovCajaL, TipoMovCajaNames, CheckedTipoMovCaja As New ArrayList() 'Arreglo para guardar los tipos de mov caja seleccionados
    Dim AgregaModifica As Integer

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Cuenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Prorrateable As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Descripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoTramtre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents PersistentRepository4 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoCobro As System.Windows.Forms.ComboBox
    Friend WithEvents txtMaxFicha As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TMovCaja As System.Windows.Forms.Panel
    Friend WithEvents cklBancos As System.Windows.Forms.CheckedListBox
    Friend WithEvents cklTipoMovCaja As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbDescripcion As System.Windows.Forms.GroupBox
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents gbTipoCobro As System.Windows.Forms.GroupBox
    Friend WithEvents gbBancos As System.Windows.Forms.GroupBox
    Friend WithEvents gbTipoMovCaja As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAutomatica As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoCorte As System.Windows.Forms.ComboBox
    Friend WithEvents chkEspecificarBanco As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TipoFicha))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.TMovCaja = New System.Windows.Forms.Panel()
        Me.chkEspecificarBanco = New System.Windows.Forms.CheckBox()
        Me.chkAutomatica = New System.Windows.Forms.CheckBox()
        Me.cmbTipoCorte = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbTipoMovCaja = New System.Windows.Forms.GroupBox()
        Me.cklTipoMovCaja = New System.Windows.Forms.CheckedListBox()
        Me.gbDescripcion = New System.Windows.Forms.GroupBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbTipoCobro = New System.Windows.Forms.GroupBox()
        Me.cboTipoCobro = New System.Windows.Forms.ComboBox()
        Me.gbBancos = New System.Windows.Forms.GroupBox()
        Me.cklBancos = New System.Windows.Forms.CheckedListBox()
        Me.txtMaxFicha = New System.Windows.Forms.TextBox()
        Me.Cuenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Prorrateable = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Descripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoTramtre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.PersistentRepository4 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.TMovCaja.SuspendLayout()
        Me.gbTipoMovCaja.SuspendLayout()
        Me.gbDescripcion.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.gbTipoCobro.SuspendLayout()
        Me.gbBancos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Turquoise
        '
        'TMovCaja
        '
        Me.TMovCaja.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkEspecificarBanco, Me.chkAutomatica, Me.cmbTipoCorte, Me.Label1, Me.gbTipoMovCaja, Me.gbDescripcion, Me.gbStatus, Me.Label7, Me.gbTipoCobro, Me.gbBancos, Me.txtMaxFicha})
        Me.TMovCaja.Location = New System.Drawing.Point(9, 9)
        Me.TMovCaja.Name = "TMovCaja"
        Me.TMovCaja.Size = New System.Drawing.Size(711, 447)
        Me.TMovCaja.TabIndex = 0
        '
        'chkEspecificarBanco
        '
        Me.chkEspecificarBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEspecificarBanco.ForeColor = System.Drawing.Color.DarkGreen
        Me.chkEspecificarBanco.Location = New System.Drawing.Point(19, 184)
        Me.chkEspecificarBanco.Name = "chkEspecificarBanco"
        Me.chkEspecificarBanco.Size = New System.Drawing.Size(136, 24)
        Me.chkEspecificarBanco.TabIndex = 268
        Me.chkEspecificarBanco.Text = "Especificar Banco"
        '
        'chkAutomatica
        '
        Me.chkAutomatica.Location = New System.Drawing.Point(16, 406)
        Me.chkAutomatica.Name = "chkAutomatica"
        Me.chkAutomatica.Size = New System.Drawing.Size(82, 24)
        Me.chkAutomatica.TabIndex = 267
        Me.chkAutomatica.Text = "Automática"
        '
        'cmbTipoCorte
        '
        Me.cmbTipoCorte.BackColor = System.Drawing.Color.White
        Me.cmbTipoCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCorte.ItemHeight = 16
        Me.cmbTipoCorte.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cmbTipoCorte.Location = New System.Drawing.Point(464, 406)
        Me.cmbTipoCorte.Name = "cmbTipoCorte"
        Me.cmbTipoCorte.Size = New System.Drawing.Size(208, 24)
        Me.cmbTipoCorte.TabIndex = 266
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(392, 410)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "Tipo corte :"
        '
        'gbTipoMovCaja
        '
        Me.gbTipoMovCaja.BackColor = System.Drawing.Color.Transparent
        Me.gbTipoMovCaja.Controls.AddRange(New System.Windows.Forms.Control() {Me.cklTipoMovCaja})
        Me.gbTipoMovCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoMovCaja.ForeColor = System.Drawing.Color.DarkGreen
        Me.gbTipoMovCaja.Location = New System.Drawing.Point(392, 112)
        Me.gbTipoMovCaja.Name = "gbTipoMovCaja"
        Me.gbTipoMovCaja.Size = New System.Drawing.Size(280, 288)
        Me.gbTipoMovCaja.TabIndex = 263
        Me.gbTipoMovCaja.TabStop = False
        Me.gbTipoMovCaja.Text = "Tipo Movimiento Caja"
        '
        'cklTipoMovCaja
        '
        Me.cklTipoMovCaja.CheckOnClick = CType(configurationAppSettings.GetValue("listRuta1.CheckOnClick", GetType(System.Boolean)), Boolean)
        Me.cklTipoMovCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklTipoMovCaja.Location = New System.Drawing.Point(13, 20)
        Me.cklTipoMovCaja.Name = "cklTipoMovCaja"
        Me.cklTipoMovCaja.Size = New System.Drawing.Size(257, 260)
        Me.cklTipoMovCaja.TabIndex = 262
        '
        'gbDescripcion
        '
        Me.gbDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.gbDescripcion.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDesc})
        Me.gbDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDescripcion.ForeColor = System.Drawing.Color.DarkGreen
        Me.gbDescripcion.Location = New System.Drawing.Point(16, 40)
        Me.gbDescripcion.Name = "gbDescripcion"
        Me.gbDescripcion.Size = New System.Drawing.Size(368, 56)
        Me.gbDescripcion.TabIndex = 1
        Me.gbDescripcion.TabStop = False
        Me.gbDescripcion.Text = "Descripcion"
        '
        'txtDesc
        '
        Me.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesc.Location = New System.Drawing.Point(7, 20)
        Me.txtDesc.MaxLength = 30
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(351, 21)
        Me.txtDesc.TabIndex = 0
        Me.txtDesc.Text = ""
        '
        'gbStatus
        '
        Me.gbStatus.BackColor = System.Drawing.Color.Transparent
        Me.gbStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboStatus})
        Me.gbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStatus.ForeColor = System.Drawing.Color.DarkGreen
        Me.gbStatus.Location = New System.Drawing.Point(392, 40)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(280, 56)
        Me.gbStatus.TabIndex = 2
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.ItemHeight = 16
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(15, 20)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(172, 24)
        Me.cboStatus.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label7.Location = New System.Drawing.Point(24, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo Ficha :"
        '
        'gbTipoCobro
        '
        Me.gbTipoCobro.BackColor = System.Drawing.Color.Transparent
        Me.gbTipoCobro.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipoCobro})
        Me.gbTipoCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoCobro.ForeColor = System.Drawing.Color.DarkGreen
        Me.gbTipoCobro.Location = New System.Drawing.Point(16, 112)
        Me.gbTipoCobro.Name = "gbTipoCobro"
        Me.gbTipoCobro.Size = New System.Drawing.Size(272, 65)
        Me.gbTipoCobro.TabIndex = 3
        Me.gbTipoCobro.TabStop = False
        Me.gbTipoCobro.Text = "Tipo Cobro"
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCobro.ItemHeight = 16
        Me.cboTipoCobro.Location = New System.Drawing.Point(11, 24)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(245, 24)
        Me.cboTipoCobro.TabIndex = 0
        '
        'gbBancos
        '
        Me.gbBancos.BackColor = System.Drawing.Color.Transparent
        Me.gbBancos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cklBancos})
        Me.gbBancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBancos.ForeColor = System.Drawing.Color.DarkGreen
        Me.gbBancos.Location = New System.Drawing.Point(16, 216)
        Me.gbBancos.Name = "gbBancos"
        Me.gbBancos.Size = New System.Drawing.Size(272, 184)
        Me.gbBancos.TabIndex = 4
        Me.gbBancos.TabStop = False
        Me.gbBancos.Text = "Banco"
        Me.gbBancos.Visible = False
        '
        'cklBancos
        '
        Me.cklBancos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklBancos.Location = New System.Drawing.Point(10, 18)
        Me.cklBancos.Name = "cklBancos"
        Me.cklBancos.Size = New System.Drawing.Size(241, 148)
        Me.cklBancos.TabIndex = 0
        '
        'txtMaxFicha
        '
        Me.txtMaxFicha.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtMaxFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxFicha.Location = New System.Drawing.Point(112, 16)
        Me.txtMaxFicha.Name = "txtMaxFicha"
        Me.txtMaxFicha.ReadOnly = True
        Me.txtMaxFicha.Size = New System.Drawing.Size(113, 23)
        Me.txtMaxFicha.TabIndex = 0
        Me.txtMaxFicha.Text = ""
        '
        'Cuenta
        '
        Me.Cuenta.Caption = "Cuenta"
        Me.Cuenta.FieldName = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.VisibleIndex = 2
        Me.Cuenta.Width = 150
        '
        'Prorrateable
        '
        Me.Prorrateable.Caption = "Prorrateable"
        Me.Prorrateable.FieldName = "Prorrateable"
        Me.Prorrateable.Name = "Prorrateable"
        Me.Prorrateable.VisibleIndex = 1
        Me.Prorrateable.Width = 70
        '
        'Descripcion
        '
        Me.Descripcion.Caption = "Descripcion"
        Me.Descripcion.FieldName = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.VisibleIndex = 0
        Me.Descripcion.Width = 100
        '
        'TipoTramtre
        '
        Me.TipoTramtre.FieldName = "TipoTramite"
        Me.TipoTramtre.Name = "TipoTramtre"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "CentroEmbarcador"
        Me.GridColumn1.FieldName = "CentroEmbarcador"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(376, 476)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "   &Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(232, 476)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'TipoFicha
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(727, 520)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.TMovCaja})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "TipoFicha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo Ficha"
        Me.TMovCaja.ResumeLayout(False)
        Me.gbTipoMovCaja.ResumeLayout(False)
        Me.gbDescripcion.ResumeLayout(False)
        Me.gbStatus.ResumeLayout(False)
        Me.gbTipoCobro.ResumeLayout(False)
        Me.gbBancos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Procedimiento para llenar los combos Status y tipocosto
    Private Sub LlenaCombos()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtComboTC As New DataTable()
        Dim dtComboTipo As New DataTable()
        Dim dtComboS As New DataTable()
        Dim drLeer As SqlDataReader
        Try
            'Llenar el combo TipoCobro Accion = 12
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 12
            cmdCommand.ExecuteNonQuery()
            dtComboTC.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtComboTC)
            cboTipoCobro.DataSource = dtComboTC
            cboTipoCobro.ValueMember = "tipoCobro"
            cboTipoCobro.DisplayMember = "Descripcion"

            cboStatus.SelectedIndex = 0

            'Llena combo tipocorte
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 19
            cmdCommand.ExecuteNonQuery()
            dtComboTipo.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtComboTipo)
            cmbTipoCorte.DataSource = dtComboTipo
            cmbTipoCorte.ValueMember = "TipoCorte"
            cmbTipoCorte.DisplayMember = "Descripcion"
            cmbTipoCorte.SelectedValue = 0

            If AgregaModifica = 2 Then
                cmdCommand.CommandType = CommandType.StoredProcedure
                cmdCommand.CommandText = "sp_CatalogoTipoFicha"
                cmdCommand.Parameters.Clear()
                cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 20
                cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = VGN_ConsecutivoFicha
                drLeer = cmdCommand.ExecuteReader
                If drLeer.Read Then
                    cmbTipoCorte.SelectedValue = CType(drLeer("TipoCorte"), Integer)
                End If
                drLeer.Close()
            End If

        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Procedimiento para 'Llenar el ListCheckBox de Bancos
    Private Sub LlenaBancos()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtComboB As New DataTable()
        Dim i As Integer

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "sp_CatalogoTipoFicha"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 11
        cmdCommand.ExecuteNonQuery()
        dtComboB.Clear()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtComboB)
        For i = 0 To dtComboB.Rows.Count - 1
            BancosL.Add(CInt(dtComboB.Rows(i)("Banco")))
            BancosNames.Add(CStr(dtComboB.Rows(i)("Descripcion")))
        Next
        For i = 0 To BancosL.Count - 1
            cklBancos.Items.Add(BancosNames(i), False)
        Next

    End Sub

    'Procedimiento para Llenar el ListCheckBox de TipoMovCaja
    Private Sub LlenaTipoMovCaja()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtComboM As New DataTable()
        Dim i As Integer

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "sp_CatalogoTipoFicha"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 13
        cmdCommand.ExecuteNonQuery()
        dtComboM.Clear()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtComboM)
        For i = 0 To dtComboM.Rows.Count - 1
            TipoMovCajaL.Add(CInt(dtComboM.Rows(i)("tipomovimientocaja")))
            TipoMovCajaNames.Add(CStr(dtComboM.Rows(i)("Descripcion")))
        Next
        For i = 0 To TipoMovCajaL.Count - 1
            cklTipoMovCaja.Items.Add(TipoMovCajaNames(i), False)
        Next

    End Sub

    'Procedimiento que obtiene el consecutivo para el tipoFicha
    Private Sub Consecutivo()
        'Dim Max As Integer
        'VGN_ConsecutivoFicha = CType(Max + 1, String)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtConsulta As New DataTable()
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 4
            cmdCommand.ExecuteNonQuery()
            dtConsulta.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtConsulta)
            cboTipoCobro.DataSource = dtConsulta
            VGN_ConsecutivoFicha = CInt(dtConsulta.Rows(0)("MaxTipoFicha"))
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

        txtMaxFicha.Text = CType(VGN_ConsecutivoFicha, String)
        txtMaxFicha.Enabled = False
    End Sub

    'Procedimiento que agrega un registro en la tabla TipoFicha
    Private Sub AgregaTipoFicha(ByVal EspecificaBanco As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 5
            cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = VGN_ConsecutivoFicha
            cmdCommand.Parameters.Add("@Descripcion", SqlDbType.Char).Value = txtDesc.Text.Trim
            cmdCommand.Parameters.Add("@Status", SqlDbType.Char).Value = cboStatus.Text
            cmdCommand.Parameters.Add("@tipoCobro ", SqlDbType.Int).Value = CInt(cboTipoCobro.SelectedValue)
            cmdCommand.Parameters.Add("@Automatica ", SqlDbType.Int).Value = chkAutomatica.Checked
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = CType(cmbTipoCorte.SelectedValue, Integer)
            cmdCommand.Parameters.Add("@EspecificarBanco ", SqlDbType.Int).Value = EspecificaBanco
            cmdCommand.ExecuteNonQuery()
        Catch es As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & es.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    'Procedimiento que agrega un registro para el tipo ficha que se agrega en la tabla TipoFichaMovimientoCaja
    Private Sub AgregaTFMovimientoCaja(ByVal tipomovcaja As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 6
            cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = VGN_ConsecutivoFicha
            cmdCommand.Parameters.Add("@TipoMovCaja", SqlDbType.Char).Value = tipomovcaja
            cmdCommand.ExecuteNonQuery()
        Catch es As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & es.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Procedimiento que agrega un reg para el TipoFicha que se agrega en la tabla TipoFichaBanco
    Private Sub AgregaTFBanco(ByVal banco As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 7
            cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = VGN_ConsecutivoFicha
            cmdCommand.Parameters.Add("@Banco", SqlDbType.Char).Value = banco
            cmdCommand.ExecuteNonQuery()
        Catch es As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & es.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    'Procedimiento para actulizar un tipoficha
    Private Sub ActulizaTipoFicha(ByVal tipof As Integer, ByVal desc As String, ByVal status As String, ByVal tipocobro As Integer, ByVal espbanco As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 9
            cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = tipof
            cmdCommand.Parameters.Add("@Descripcion", SqlDbType.Char).Value = desc
            cmdCommand.Parameters.Add("@Status", SqlDbType.Char).Value = status
            cmdCommand.Parameters.Add("@tipoCobro", SqlDbType.Int).Value = cboTipoCobro.SelectedValue
            cmdCommand.Parameters.Add("@EspecificarBanco", SqlDbType.Int).Value = espbanco
            cmdCommand.Parameters.Add("@Automatica", SqlDbType.Bit).Value = chkAutomatica.Checked
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = cmbTipoCorte.SelectedValue
            cmdCommand.ExecuteNonQuery()
        Catch es As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & es.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    'Procedimiento para eliminar tipofichabanco
    Private Sub EliminaTFBanco(ByVal tipof As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 18
            cmdCommand.Parameters.Add("@TipoFicha ", SqlDbType.Int).Value = tipof
            cmdCommand.ExecuteNonQuery()
        Catch es As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & es.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ActualizaTFMovCaja(ByVal tipof As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtConsulta As New DataTable()
        Dim i, j, tfm, tfmN As Integer
        Dim band As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 16
            cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
            cmdCommand.ExecuteNonQuery()
            dtConsulta.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtConsulta)

            For i = 0 To dtConsulta.Rows.Count - 1
                tfm = CInt(dtConsulta.Rows(i)("tipomovimientoCaja"))
                band = False
                For j = 0 To CheckedTipoMovCaja.Count - 1
                    If tfm = CheckedTipoMovCaja(j) Then
                        band = True
                    End If
                Next
                If Not band Then 'Elimina registro
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 17
                    cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
                    cmdCommand.Parameters.Add("@TipoMovCaja", SqlDbType.Int).Value = tfm
                    cmdCommand.ExecuteNonQuery()
                End If
            Next
            band = False
            For i = 0 To CheckedTipoMovCaja.Count - 1
                band = False
                tfmN = CType(CheckedTipoMovCaja(i), Integer)
                For j = 0 To dtConsulta.Rows.Count - 1
                    tfm = CInt(dtConsulta.Rows(j)("tipomovimientoCaja"))
                    If tfm = tfmN Then
                        band = True
                    End If
                Next
                If Not band Then 'Inserta registro
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 6
                    cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
                    cmdCommand.Parameters.Add("@TipoMovCaja", SqlDbType.Int).Value = tfmN
                    cmdCommand.ExecuteNonQuery()
                End If
            Next
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Procedimiento para actualizar TipoFichaBanco
    Private Sub ActualizaTipoFichaBanco(ByVal tipof As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtConsulta As New DataTable()
        Dim i, j, banco, bancoN As Integer
        Dim band As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 14
            cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
            cmdCommand.ExecuteNonQuery()
            dtConsulta.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtConsulta)

            For i = 0 To dtConsulta.Rows.Count - 1
                banco = CInt(dtConsulta.Rows(i)("Banco"))
                band = False
                For j = 0 To CheckedBancos.Count - 1
                    If banco = CheckedBancos(j) Then
                        band = True
                    End If
                Next
                If Not band Then 'Elimina registro
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 15
                    cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
                    cmdCommand.Parameters.Add("@Banco", SqlDbType.Int).Value = banco
                    cmdCommand.ExecuteNonQuery()
                End If
            Next
            band = False
            For i = 0 To CheckedBancos.Count - 1
                band = False
                bancoN = CType(CheckedBancos(i), Integer)
                For j = 0 To dtConsulta.Rows.Count - 1
                    banco = CInt(dtConsulta.Rows(j)("Banco"))
                    If banco = bancoN Then
                        band = True
                    End If
                Next
                If Not band Then 'Inserta registro
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 7
                    cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipof
                    cmdCommand.Parameters.Add("@Banco", SqlDbType.Int).Value = bancoN
                    cmdCommand.ExecuteNonQuery()
                End If
            Next

        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error :" & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim i As Integer ''EspecificaBanco,

        If txtDesc.Text.Trim = "" Then
            MessageBox.Show("La descripción no es válida, Verifique por favor ", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            If CInt(cboTipoCobro.SelectedValue) = 3 Or chkEspecificarBanco.Checked = True Then 'Es cheque y se agregan los bancos en TipoFichaBanco

                If AgregaModifica = 2 Then
                    ActualizaTipoFichaBanco(VGN_ConsecutivoFicha)
                Else
                    For i = 0 To CheckedBancos.Count - 1
                        AgregaTFBanco(CType(CheckedBancos.Item(i), Integer))
                    Next

                End If

            Else
                chkEspecificarBanco.Checked = False
                If AgregaModifica = 2 Then
                    EliminaTFBanco(VGN_ConsecutivoFicha)
                End If

            End If
            If AgregaModifica = 2 Then
                ActualizaTFMovCaja(VGN_ConsecutivoFicha)
                ActulizaTipoFicha(VGN_ConsecutivoFicha, txtDesc.Text.Trim, cboStatus.Text, VGN_TipoCobro, CType(chkEspecificarBanco.Checked, Integer))
            Else
                For i = 0 To CheckedTipoMovCaja.Count - 1
                    AgregaTFMovimientoCaja(CType(CheckedTipoMovCaja.Item(i), Integer))
                Next
                AgregaTipoFicha(CType(chkEspecificarBanco.Checked, Integer))
            End If
            Me.Close()
        End If


    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub Modificar(ByVal TipoFicha As Integer, ByVal DescFicha As String, ByVal TipoCobro As Integer, ByVal Status As String, ByVal Automatica As Boolean, EspecBanco as Boolean )

        AgregaModifica = 2
        VGN_ConsecutivoFicha = TipoFicha
        VGN_TipoCobro = TipoCobro
        txtMaxFicha.Text = TipoFicha.ToString()
        txtMaxFicha.Enabled = False
        txtDesc.Text = DescFicha
        LlenaCombos()
        cboStatus.SelectedText = Status
        cboTipoCobro.SelectedValue = TipoCobro
        chkEspecificarBanco.Checked = EspecBanco
        chkAutomatica.Checked = Automatica
        LlenaTipoMovCaja()
        SeleccionaTipoMovCaja(TipoFicha)
        If chkEspecificarBanco.Checked = True Then
            LlenaBancos()
            gbBancos.Visible = True
            SeleccionaBancos(TipoFicha)
        End If

    End Sub

    Private Sub SeleccionaBancos(ByVal tipoficha As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtComboB As New DataTable()
        Dim i, j As Integer

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "sp_CatalogoTipoFicha"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 3
        cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipoficha
        cmdCommand.ExecuteNonQuery()
        dtComboB.Clear()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtComboB)

        CheckedBancos.Clear()
        For i = 0 To dtComboB.Rows.Count - 1
            CheckedBancos.Add(CInt(dtComboB.Rows(i)("Banco")))
            For j = 0 To BancosL.Count - 1
                If BancosL(j) = CInt(dtComboB.Rows(i)("Banco")) Then
                    'cklBancos.SetItemChecked(j, True)
                    cklBancos.SetItemCheckState(j, CheckState.Checked)
                End If
            Next
        Next
    End Sub

    Private Sub SeleccionaTipoMovCaja(ByVal tipoficha As Integer)
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtComboTMC As New DataTable()
        Dim i, j As Integer

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "sp_CatalogoTipoFicha"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 2
        cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = tipoficha
        cmdCommand.ExecuteNonQuery()
        dtComboTMC.Clear()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtComboTMC)

        CheckedTipoMovCaja.Clear()
        For i = 0 To dtComboTMC.Rows.Count - 1
            CheckedTipoMovCaja.Add(CInt(dtComboTMC.Rows(i)("TipoMovimientoCaja")))
            For j = 0 To TipoMovCajaL.Count - 1
                If TipoMovCajaL(j) = CInt(dtComboTMC.Rows(i)("TipoMovimientoCaja")) Then
                    cklTipoMovCaja.SetItemChecked(j, True)
                End If
            Next
        Next
    End Sub

    Public Sub Entrar()
        AgregaModifica = 1
        Consecutivo()
        LlenaCombos()
        LlenaTipoMovCaja()
    End Sub

    Private Sub cboTipoCobro_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoCobro.SelectionChangeCommitted
        If CInt(cboTipoCobro.SelectedValue) = 3 Then
            LlenaBancos()
            gbBancos.Visible = True
        Else
            gbBancos.Visible = False
        End If
    End Sub

    'Funcion que agrega los bancos seleccionados al Arraylist checkedBancos
    Private Sub cklBancos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklBancos.ItemCheck
        Dim i, banco As Integer ''idbanco, idcb 
        Dim band, bandb As Boolean

        For i = 0 To BancosL.Count - 1
            If BancosNames.Item(i) = cklBancos.SelectedItem Then
                banco = CType(BancosL(i), Integer)
                bandb = True
            End If
        Next

        For i = 0 To CheckedBancos.Count - 1
            If CheckedBancos(i) = banco Then
                band = True
            End If
        Next

        If Not band And bandb Then
            CheckedBancos.Add(banco)
        Else
            CheckedBancos.Remove(banco)
        End If
    End Sub

    Private Sub cklTipoMovCaja_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklTipoMovCaja.ItemCheck
        Dim i, tmc As Integer
        Dim band, bandm As Boolean

        For i = 0 To TipoMovCajaL.Count - 1
            If TipoMovCajaNames.Item(i) = cklTipoMovCaja.SelectedItem Then
                tmc = CType(TipoMovCajaL(i), Integer)
                bandm = True
            End If
        Next
        For i = 0 To CheckedTipoMovCaja.Count - 1
            If CheckedTipoMovCaja(i) = tmc Then
                band = True
            End If
        Next

        If Not band And bandm Then
            CheckedTipoMovCaja.Add(tmc)
        Else
            CheckedTipoMovCaja.Remove(tmc)
        End If
    End Sub

    Private Sub chkEspecificarBanco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEspecificarBanco.CheckedChanged
        If chkEspecificarBanco.Checked = True Then
            LlenaBancos()
            gbBancos.Visible = True
        Else
            gbBancos.Visible = False
        End If
    End Sub
End Class

