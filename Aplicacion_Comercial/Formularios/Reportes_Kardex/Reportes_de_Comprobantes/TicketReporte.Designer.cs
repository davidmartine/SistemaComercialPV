namespace Aplicacion_Comercial.Formularios.Reportes_Kardex.Reportes_de_Comprobantes
{
    partial class TicketReporte
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Barcodes.PDF417Encoder pdF417Encoder1 = new Telerik.Reporting.Barcodes.PDF417Encoder();
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Barcodes.QRCodeEncoder qrCodeEncoder1 = new Telerik.Reporting.Barcodes.QRCodeEncoder();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.barcode1 = new Telerik.Reporting.Barcode();
            this.htmlTextBox1 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox2 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox3 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox4 = new Telerik.Reporting.HtmlTextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.htmlTextBox5 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox6 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox7 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox8 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox9 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox10 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox11 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox12 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox13 = new Telerik.Reporting.HtmlTextBox();
            this.barcode2 = new Telerik.Reporting.Barcode();
            this.htmlTextBox14 = new Telerik.Reporting.HtmlTextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.928D), Telerik.Reporting.Drawing.Unit.Cm(0.442D));
            this.textBox1.Value = "Cantidad";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.886D), Telerik.Reporting.Drawing.Unit.Cm(0.442D));
            this.textBox3.Value = "Producto";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.933D), Telerik.Reporting.Drawing.Unit.Cm(0.442D));
            this.textBox5.Value = "Importe";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(8.1D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.barcode1,
            this.htmlTextBox1,
            this.htmlTextBox2,
            this.htmlTextBox3,
            this.htmlTextBox4,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.15D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(1.3D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = "=Fields.Logo";
            // 
            // barcode1
            // 
            this.barcode1.Encoder = pdF417Encoder1;
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.3D), Telerik.Reporting.Drawing.Unit.Cm(4.551D));
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.9D), Telerik.Reporting.Drawing.Unit.Cm(1.449D));
            this.barcode1.Stretch = true;
            this.barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.barcode1.Value = "=Fields.Empresa + Fields.Identificador_Fiscal + Fields.Monto_Total";
            // 
            // htmlTextBox1
            // 
            this.htmlTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(6D));
            this.htmlTextBox1.Name = "htmlTextBox1";
            this.htmlTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox1.Value = "------------------------------------";
            // 
            // htmlTextBox2
            // 
            this.htmlTextBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(6.4D));
            this.htmlTextBox2.Name = "htmlTextBox2";
            this.htmlTextBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox2.Style.Font.Bold = true;
            this.htmlTextBox2.Value = "Cajer@ :";
            // 
            // htmlTextBox3
            // 
            this.htmlTextBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(6.8D));
            this.htmlTextBox3.Name = "htmlTextBox3";
            this.htmlTextBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox3.Style.Font.Bold = true;
            this.htmlTextBox3.Value = "Fecha :";
            // 
            // htmlTextBox4
            // 
            this.htmlTextBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(7.201D));
            this.htmlTextBox4.Name = "htmlTextBox4";
            this.htmlTextBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox4.Style.Font.Bold = true;
            this.htmlTextBox4.Value = "Cliente :";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.3D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Value = "=Fields.Empresa";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.25D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Value = "=Fields.Identificador_Fiscal";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.8D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8D), Telerik.Reporting.Drawing.Unit.Cm(0.55D));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Value = "=Fields.Direccion";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.5D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "=Fields.Provincia_Departamento";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.951D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "=Fields.Comprobante";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.4D), Telerik.Reporting.Drawing.Unit.Cm(3.951D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Value = "=Fields.Numero_de_Documento";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.3D), Telerik.Reporting.Drawing.Unit.Cm(6.4D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.5D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox13.Value = "=Fields.Usuario";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.3D), Telerik.Reporting.Drawing.Unit.Cm(6.8D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.5D), Telerik.Reporting.Drawing.Unit.Cm(0.401D));
            this.textBox14.Value = "=Fields.Fecha_Venta";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(7.201D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.3D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox15.Value = "=Fields.Nombre";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.132D);
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.132D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(13.4D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1,
            this.htmlTextBox5,
            this.htmlTextBox6,
            this.htmlTextBox7,
            this.htmlTextBox8,
            this.htmlTextBox9,
            this.htmlTextBox10,
            this.htmlTextBox11,
            this.htmlTextBox12,
            this.htmlTextBox13,
            this.barcode2,
            this.htmlTextBox14,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.928D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.886D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.933D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.68D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox2);
            this.table1.Body.SetCellContent(0, 1, this.textBox4);
            this.table1.Body.SetCellContent(0, 2, this.textBox6);
            tableGroup1.Name = "tableGroup";
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "tableGroup1";
            tableGroup2.ReportItem = this.textBox3;
            tableGroup3.Name = "tableGroup2";
            tableGroup3.ReportItem = this.textBox5;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox4,
            this.textBox6,
            this.textBox1,
            this.textBox3,
            this.textBox5});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.table1.Name = "table1";
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "detailTableGroup";
            this.table1.RowGroups.Add(tableGroup4);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(1.122D));
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.928D), Telerik.Reporting.Drawing.Unit.Cm(0.68D));
            this.textBox2.Value = "=Fields.Cantidad";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.886D), Telerik.Reporting.Drawing.Unit.Cm(0.68D));
            this.textBox4.Value = "=Fields.Producto";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0:N2}";
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.933D), Telerik.Reporting.Drawing.Unit.Cm(0.68D));
            this.textBox6.Value = "=Fields.Importe";
            // 
            // htmlTextBox5
            // 
            this.htmlTextBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.928D), Telerik.Reporting.Drawing.Unit.Cm(1.8D));
            this.htmlTextBox5.Name = "htmlTextBox5";
            this.htmlTextBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox5.Style.Font.Bold = true;
            this.htmlTextBox5.Value = "TOTAL :";
            // 
            // htmlTextBox6
            // 
            this.htmlTextBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.6D));
            this.htmlTextBox6.Name = "htmlTextBox6";
            this.htmlTextBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox6.Style.Font.Bold = true;
            this.htmlTextBox6.Value = "SON :";
            // 
            // htmlTextBox7
            // 
            this.htmlTextBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.2D));
            this.htmlTextBox7.Name = "htmlTextBox7";
            this.htmlTextBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox7.Value = "-------------------------------------------------";
            // 
            // htmlTextBox8
            // 
            this.htmlTextBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(4.401D));
            this.htmlTextBox8.Name = "htmlTextBox8";
            this.htmlTextBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox8.Style.Font.Bold = true;
            this.htmlTextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox8.Value = "=Fields.Agradecimiento";
            // 
            // htmlTextBox9
            // 
            this.htmlTextBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(4D));
            this.htmlTextBox9.Name = "htmlTextBox9";
            this.htmlTextBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox9.Value = "-------------------------------------------------";
            // 
            // htmlTextBox10
            // 
            this.htmlTextBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.6D));
            this.htmlTextBox10.Name = "htmlTextBox10";
            this.htmlTextBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.3D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox10.Style.Font.Bold = true;
            this.htmlTextBox10.Value = "CANTIDAD DE PRODUCTOS :";
            // 
            // htmlTextBox11
            // 
            this.htmlTextBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(4.801D));
            this.htmlTextBox11.Name = "htmlTextBox11";
            this.htmlTextBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox11.Style.Font.Bold = true;
            this.htmlTextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.htmlTextBox11.Value = "=Fields.Pagina_Web";
            // 
            // htmlTextBox12
            // 
            this.htmlTextBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.201D));
            this.htmlTextBox12.Name = "htmlTextBox12";
            this.htmlTextBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox12.Style.Font.Bold = true;
            this.htmlTextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.htmlTextBox12.Value = "=Fields.Anuncio";
            // 
            // htmlTextBox13
            // 
            this.htmlTextBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.601D));
            this.htmlTextBox13.Name = "htmlTextBox13";
            this.htmlTextBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox13.Value = "**************************************************************";
            // 
            // barcode2
            // 
            this.barcode2.Encoder = qrCodeEncoder1;
            this.barcode2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(6.3D));
            this.barcode2.Name = "barcode2";
            this.barcode2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.39D), Telerik.Reporting.Drawing.Unit.Cm(3.39D));
            this.barcode2.Stretch = true;
            this.barcode2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode2.Value = "=Fields.Empresa + \'|\' + Fields.Identificador_Fiscal + \'|\' +Fields.Monto_Total";
            // 
            // htmlTextBox14
            // 
            this.htmlTextBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.69D));
            this.htmlTextBox14.Name = "htmlTextBox14";
            this.htmlTextBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.747D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.htmlTextBox14.Style.Font.Bold = true;
            this.htmlTextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.htmlTextBox14.Value = "=Fields.Pagina_Web";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:N2}";
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.928D), Telerik.Reporting.Drawing.Unit.Cm(1.4D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox16.Value = "=Fields.Impuesto";
            // 
            // textBox17
            // 
            this.textBox17.Format = "{0:N2}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1D), Telerik.Reporting.Drawing.Unit.Cm(1.4D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.647D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox17.Value = "=Fields.Moneda + Fields.SubTotal_Impuesto";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.181D), Telerik.Reporting.Drawing.Unit.Cm(1.8D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.619D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox18.Value = "=Fields.Moneda + Fields.Monto_Total";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.4D), Telerik.Reporting.Drawing.Unit.Cm(2.6D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.347D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox19.Value = "=Fields.Total_en_Letras + Fields.Nombre_de_Moneda";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.3D), Telerik.Reporting.Drawing.Unit.Cm(3.6D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.447D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox20.Value = "=Fields.Cantidad_de_Productos";
            // 
            // TicketReporte
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "TicketReporte";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(1D), Telerik.Reporting.Drawing.Unit.Mm(1D), Telerik.Reporting.Drawing.Unit.Mm(2D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9D), Telerik.Reporting.Drawing.Unit.Cm(20D));
            this.Style.Font.Bold = true;
            this.Style.Font.Name = "Courier New";
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(8.8D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        public Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        public Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        public Telerik.Reporting.Table table1;
        public Telerik.Reporting.PictureBox pictureBox1;
        public Telerik.Reporting.Barcode barcode1;
        public Telerik.Reporting.HtmlTextBox htmlTextBox1;
        public Telerik.Reporting.HtmlTextBox htmlTextBox2;
        public Telerik.Reporting.HtmlTextBox htmlTextBox3;
        public Telerik.Reporting.HtmlTextBox htmlTextBox4;
        public Telerik.Reporting.TextBox textBox4;
        public Telerik.Reporting.HtmlTextBox htmlTextBox5;
        public Telerik.Reporting.HtmlTextBox htmlTextBox6;
        public Telerik.Reporting.HtmlTextBox htmlTextBox7;
        public Telerik.Reporting.HtmlTextBox htmlTextBox8;
        public Telerik.Reporting.HtmlTextBox htmlTextBox9;
        public Telerik.Reporting.HtmlTextBox htmlTextBox10;
        public Telerik.Reporting.HtmlTextBox htmlTextBox11;
        public Telerik.Reporting.HtmlTextBox htmlTextBox12;
        public Telerik.Reporting.HtmlTextBox htmlTextBox13;
        public Telerik.Reporting.Barcode barcode2;
        public Telerik.Reporting.HtmlTextBox htmlTextBox14;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
    }
}