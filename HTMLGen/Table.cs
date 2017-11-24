using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScratchApp.HTMLGen
{
    public class Table : Element
    {
        string[] headers;
        TableRowData[] data;
        int numFields;
        int numRecords;
        public Table(string name, string[] _headers, TableRowData[] _data, Style style) : base(name, style)
        {
            this.headers = _headers;
            this.data = _data;
            this.numFields = headers.Count();
            this.numRecords = data.Count();
        }
        public override GeneratedHtmlAndCss Construct()
        {
            return new GeneratedHtmlAndCss { Html = ConstructHtml(), css = this.Style.Construct() };
        }
        private string ConstructHtml()
        {
            string tableHTML;
            string headersHTML = "<tr>\n";
            string rowsHTML = "";
            foreach (string header in headers)
            {
                headersHTML += $"<th>{header}</th>\n";
            }
            headersHTML += "</tr>\n";
            foreach (TableRowData row in data)
            {
                string tableRowHTML = "<tr>\n";

                foreach (string rowData in row.data)
                {
                    tableRowHTML += $"<td>{rowData}</td>\n";
                }
                tableRowHTML += "</tr>\n";
                rowsHTML += tableRowHTML;
            }
            return tableHTML = headersHTML + rowsHTML;
        }


    }
}