Imports System.Data.SqlClient

Public Class ParametrosReportes
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand

    Private intTipoReporte As Integer
    Private strUsuario As String
    Private daSelect As New SqlDataAdapter()
    Private dtCaja As New DataTable()
    Private dtBanco As New DataTable()
    Private rdrSelect As SqlDataReader
    Public blnAdministrador As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        Entrar()
        VerificaUsuario()

        If intTipoReporte = 1 Then
            Text = "Parámetros para desgloce  de fichas"
        End If
        If intTipoReporte = 2 Then
            Text = "Parámetros de cheques posfechados"
        End If
        If intTipoReporte = 3 Then
            Text = "Parámetros de cheques posfechados vencidos"
        End If

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
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbEmpresaContable As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents chkAcumulado As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ParametrosReportes))
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.tbEmpresaContable = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.chkAcumulado = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(129, 40)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(175, 20)
        Me.dtpFecha.TabIndex = 49
        '
        'tbEmpresaContable
        '
        Me.tbEmpresaContable.Enabled = False
        Me.tbEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmpresaContable.Location = New System.Drawing.Point(129, 16)
        Me.tbEmpresaContable.Name = "tbEmpresaContable"
        Me.tbEmpresaContable.ReadOnly = True
        Me.tbEmpresaContable.Size = New System.Drawing.Size(263, 20)
        Me.tbEmpresaContable.TabIndex = 48
        Me.tbEmpresaContable.Text = "Gas Metropolino S.A. de C.V."
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(408, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 46
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(408, 37)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 27)
        Me.btnCancelar.TabIndex = 47
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(7, 18)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(112, 16)
        Me.lblEmpresa.TabIndex = 45
        Me.lblEmpresa.Text = "Empresa Contable:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(71, 42)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(48, 16)
        Me.lblFecha.TabIndex = 44
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBanco
        '
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.Location = New System.Drawing.Point(71, 67)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(48, 16)
        Me.lblBanco.TabIndex = 50
        Me.lblBanco.Text = "Banco :"
        Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.Location = New System.Drawing.Point(129, 65)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(175, 21)
        Me.cmbBanco.TabIndex = 51
        '
        'chkAcumulado
        '
        Me.chkAcumulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAcumulado.Location = New System.Drawing.Point(129, 72)
        Me.chkAcumulado.Name = "chkAcumulado"
        Me.chkAcumulado.Size = New System.Drawing.Size(104, 16)
        Me.chkAcumulado.TabIndex = 52
        Me.chkAcumulado.Text = "Acumulado"
        '
        'ParametrosReportes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 106)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAcumulado, Me.cmbBanco, Me.lblBanco, Me.dtpFecha, Me.tbEmpresaContable, Me.btnAceptar, Me.btnCancelar, Me.lblEmpresa, Me.lblFecha})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ParametrosReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros de reportes"
        Me.ResumeLayout(False)

    End Sub

#End Region
    'Si el usuario logueado es el adminitrador el número de caja depende del cmbCaja
    'sino del dmModulo.VGN_Caja
    Private Function VerificaUsuario() As Integer
        Dim intCaja As Integer
        If blnAdministrador Then
            dmModulo.VGN_Caja = 0
        Else
            intCaja = dmModulo.VGN_Caja
        End If
        Return intCaja
    End Function

    Public Sub Entrar()
        Dim strUsuarioConsulta As String = String.Empty
        'Se obtiene el Usuario Administrador 

        Dim strUsuario2 As String = String.Empty

        strUsuario = ObtenParametroSistema(3, 1, 4, "UsuarioAdministrador")

        strUsuarioConsulta = ObtenParametroSistema(3, 1, 4, "UsuarioConsulta")

        'Si el usuario logueado es el adminitrador se activan los botones:
        'btnPorAutorizar,btnModificarStatus y la elección de las cajas
        If (Trim(strUsuario) = Trim(dmModulo._Usuario)) Or (Trim(strUsuarioConsulta) = Trim(dmModulo._Usuario)) Then
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSSelectCaja"
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtCaja)
            End With

            blnAdministrador = True
        Else
            blnAdministrador = False
        End If
    End Sub

    Public Sub TipoReporte(ByVal intTipoReporte As Integer)
        Me.intTipoReporte = intTipoReporte

        If intTipoReporte = 4 Then
            lblBanco.Visible = True
            cmbBanco.Visible = True
            chkAcumulado.Visible = False
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spBancoConsulta"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtBanco)
                cmbBanco.DataSource = dtBanco
                cmbBanco.ValueMember = "Banco"
                cmbBanco.DisplayMember = "Descripcion"
            End With
        Else
            cmbBanco.Visible = False
            lblBanco.Visible = False
            If intTipoReporte = 1 Then
                chkAcumulado.Visible = False
            Else
                chkAcumulado.Visible = True
            End If
        End If
        Me.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim frmViewParametrosDesgloceFichas As New ViewReport()

        If intTipoReporte = 1 Then
            frmViewParametrosDesgloceFichas.DesgloceFichas(dmModulo._NombreEmpresaContable, dmModulo._EmpresaContable, dtpFecha.Value.ToShortDateString)
        End If
        If intTipoReporte = 2 Then
            frmViewParametrosDesgloceFichas.ChequesPosfechados(dmModulo._NombreEmpresaContable, dtpFecha.Value.ToShortDateString, dmModulo.VGN_Caja, Me.chkAcumulado.Checked)
        End If
        If intTipoReporte = 3 Then
            frmViewParametrosDesgloceFichas.ChequesPosfechadosVencidos(dmModulo._NombreEmpresaContable, dtpFecha.Value.ToShortDateString, dmModulo.VGN_Caja, Me.chkAcumulado.Checked)
        End If
        If intTipoReporte = 4 Then
            frmViewParametrosDesgloceFichas.RelacionChequesDeposito(dmModulo._NombreEmpresaContable, dtpFecha.Value.ToShortDateString, CType(cmbBanco.SelectedValue, Short))
        End If

        frmViewParametrosDesgloceFichas.Dispose()
        Cursor.Current = System.Windows.Forms.Cursors.Default
        Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub ParametrosReportes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '2007-016-EIM-01	
        'REQ 139
        'Autor: Fernando Correa
        tbEmpresaContable.Text = dmModulo._NombreEmpresaContable

    End Sub
End Class
