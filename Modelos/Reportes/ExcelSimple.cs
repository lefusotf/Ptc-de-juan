using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Modelos.Reportes
{
    /// <summary>Escritor mínimo de archivos .xlsx (sin librerías externas): una hoja con título, encabezados con formato y datos tipados.</summary>
    public static class ExcelSimple
    {
        public static void Guardar(string ruta, string hoja, string titulo, string subtitulo, DataTable tabla)
        {
            if (File.Exists(ruta)) File.Delete(ruta);
            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                Agregar(zip, "[Content_Types].xml",
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">" +
                    "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/><Default Extension=\"xml\" ContentType=\"application/xml\"/>" +
                    "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>" +
                    "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>" +
                    "<Override PartName=\"/xl/styles.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml\"/></Types>");
                Agregar(zip, "_rels/.rels",
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                    "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument\" Target=\"xl/workbook.xml\"/></Relationships>");
                Agregar(zip, "xl/workbook.xml",
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" " +
                    "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\"><sheets><sheet name=\"" + Xml(NombreHoja(hoja)) + "\" sheetId=\"1\" r:id=\"rId1\"/></sheets></workbook>");
                Agregar(zip, "xl/_rels/workbook.xml.rels",
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                    "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet1.xml\"/>" +
                    "<Relationship Id=\"rId2\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles\" Target=\"styles.xml\"/></Relationships>");
                Agregar(zip, "xl/styles.xml",
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><styleSheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">" +
                    "<numFmts count=\"1\"><numFmt numFmtId=\"164\" formatCode=\"dd/mm/yyyy\"/></numFmts>" +
                    "<fonts count=\"4\"><font><sz val=\"10\"/><name val=\"Calibri\"/></font><font><b/><sz val=\"10\"/><color rgb=\"FFFFFFFF\"/><name val=\"Calibri\"/></font>" +
                    "<font><b/><sz val=\"14\"/><color rgb=\"FF1F4E8C\"/><name val=\"Calibri\"/></font><font><i/><sz val=\"10\"/><color rgb=\"FF6B7280\"/><name val=\"Calibri\"/></font></fonts>" +
                    "<fills count=\"3\"><fill><patternFill patternType=\"none\"/></fill><fill><patternFill patternType=\"gray125\"/></fill>" +
                    "<fill><patternFill patternType=\"solid\"><fgColor rgb=\"FF1F4E8C\"/></patternFill></fill></fills>" +
                    "<borders count=\"2\"><border><left/><right/><top/><bottom/><diagonal/></border>" +
                    "<border><left style=\"thin\"><color rgb=\"FFE5E7EB\"/></left><right style=\"thin\"><color rgb=\"FFE5E7EB\"/></right><top style=\"thin\"><color rgb=\"FFE5E7EB\"/></top><bottom style=\"thin\"><color rgb=\"FFE5E7EB\"/></bottom><diagonal/></border></borders>" +
                    "<cellStyleXfs count=\"1\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\"/></cellStyleXfs>" +
                    "<cellXfs count=\"7\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyBorder=\"1\"/>" +                      // 0 texto
                    "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"2\" borderId=\"1\" xfId=\"0\" applyFont=\"1\" applyFill=\"1\" applyBorder=\"1\"/>" +            // 1 encabezado
                    "<xf numFmtId=\"4\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyNumberFormat=\"1\" applyBorder=\"1\"/>" +                    // 2 decimal
                    "<xf numFmtId=\"164\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyNumberFormat=\"1\" applyBorder=\"1\"/>" +                  // 3 fecha
                    "<xf numFmtId=\"0\" fontId=\"2\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyFont=\"1\"/>" +                                             // 4 título
                    "<xf numFmtId=\"0\" fontId=\"3\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyFont=\"1\"/>" +                                             // 5 subtítulo
                    "<xf numFmtId=\"1\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyNumberFormat=\"1\" applyBorder=\"1\"/></cellXfs>" +         // 6 entero
                    "<cellStyles count=\"1\"><cellStyle name=\"Normal\" xfId=\"0\" builtinId=\"0\"/></cellStyles></styleSheet>");
                Agregar(zip, "xl/worksheets/sheet1.xml", ConstruirHoja(titulo, subtitulo, tabla));
            }
        }

        private static string ConstruirHoja(string titulo, string subtitulo, DataTable t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">");
            sb.Append("<sheetViews><sheetView workbookViewId=\"0\"><pane ySplit=\"4\" topLeftCell=\"A5\" activePane=\"bottomLeft\" state=\"frozen\"/></sheetView></sheetViews><cols>");
            for (int c = 0; c < t.Columns.Count; c++)
            {
                int max = Math.Max(Texto(t.Columns[c]).Length, 8);
                foreach (DataRow f in t.Rows) { int l = Valor(f[c]).Length; if (l > max) max = l; }
                sb.Append("<col min=\"" + (c + 1) + "\" max=\"" + (c + 1) + "\" width=\"" + Math.Min(max + 3, 50).ToString(CultureInfo.InvariantCulture) + "\" customWidth=\"1\"/>");
            }
            sb.Append("</cols><sheetData>");
            sb.Append("<row r=\"1\"><c r=\"A1\" s=\"4\" t=\"inlineStr\"><is><t>" + Xml(titulo) + "</t></is></c></row>");
            sb.Append("<row r=\"2\"><c r=\"A2\" s=\"5\" t=\"inlineStr\"><is><t>" + Xml(subtitulo) + "</t></is></c></row>");
            sb.Append("<row r=\"4\">");
            for (int c = 0; c < t.Columns.Count; c++)
                sb.Append("<c r=\"" + Ref(c, 4) + "\" s=\"1\" t=\"inlineStr\"><is><t>" + Xml(Texto(t.Columns[c])) + "</t></is></c>");
            sb.Append("</row>");

            int fila = 5;
            foreach (DataRow f in t.Rows)
            {
                sb.Append("<row r=\"" + fila + "\">");
                for (int c = 0; c < t.Columns.Count; c++)
                {
                    object v = f[c];
                    string r = Ref(c, fila);
                    if (v == DBNull.Value || v == null) sb.Append("<c r=\"" + r + "\" s=\"0\"/>");
                    else if (v is decimal || v is double || v is float)
                        sb.Append("<c r=\"" + r + "\" s=\"2\"><v>" + Convert.ToDouble(v).ToString("R", CultureInfo.InvariantCulture) + "</v></c>");
                    else if (v is int || v is long || v is short || v is byte)
                        sb.Append("<c r=\"" + r + "\" s=\"6\"><v>" + Convert.ToInt64(v).ToString(CultureInfo.InvariantCulture) + "</v></c>");
                    else if (v is DateTime)
                        sb.Append("<c r=\"" + r + "\" s=\"3\"><v>" + ((DateTime)v).ToOADate().ToString(CultureInfo.InvariantCulture) + "</v></c>");
                    else sb.Append("<c r=\"" + r + "\" s=\"0\" t=\"inlineStr\"><is><t>" + Xml(Valor(v)) + "</t></is></c>");
                }
                sb.Append("</row>");
                fila++;
            }
            sb.Append("</sheetData></worksheet>");
            return sb.ToString();
        }

        private static string Texto(DataColumn c) { return string.IsNullOrEmpty(c.Caption) ? c.ColumnName : c.Caption; }

        private static string Valor(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            if (v is DateTime) return ((DateTime)v).ToString("dd/MM/yyyy");
            if (v is TimeSpan) return ((TimeSpan)v).ToString(@"hh\:mm");
            if (v is decimal) return ((decimal)v).ToString("N2", CultureInfo.InvariantCulture);
            return Convert.ToString(v, CultureInfo.InvariantCulture);
        }

        private static string Ref(int columna, int fila)
        {
            string letras = "";
            int n = columna;
            do { letras = (char)('A' + n % 26) + letras; n = n / 26 - 1; } while (n >= 0);
            return letras + fila;
        }

        private static string NombreHoja(string h)
        {
            foreach (char c in "[]:*?/\\") h = h.Replace(c.ToString(), "");
            return h.Length > 31 ? h.Substring(0, 31) : (h.Length == 0 ? "Hoja1" : h);
        }

        private static string Xml(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s ?? "")
            {
                if (c == '&') sb.Append("&amp;"); else if (c == '<') sb.Append("&lt;"); else if (c == '>') sb.Append("&gt;");
                else if (c == '"') sb.Append("&quot;"); else if (c < 32 && c != '\t' && c != '\n' && c != '\r') continue; else sb.Append(c);
            }
            return sb.ToString();
        }

        private static void Agregar(ZipArchive zip, string nombre, string contenido)
        {
            ZipArchiveEntry e = zip.CreateEntry(nombre);
            using (Stream s = e.Open())
            {
                byte[] b = new UTF8Encoding(false).GetBytes(contenido);
                s.Write(b, 0, b.Length);
            }
        }
    }
}
