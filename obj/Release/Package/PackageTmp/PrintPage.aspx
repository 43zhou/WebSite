<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPage.aspx.cs" Inherits="WebSite.PrintPage" %>
<%@ Register assembly="FastReport.Web" namespace="FastReport.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <cc1:WebReport ID="WebReport1" runat="server" BackColor="White" Font-Bold="False"
            Width="1050px" Height="1000px"
            OnStartReport="WebReport1_StartReport"
            Padding="5, 5, 5, 5" ToolbarColor="Lavender"
            PdfEmbeddingFonts="True"
            Layers="False" Zoom="1"
            ToolbarBackgroundStyle="Light"
            ToolbarIconsStyle="Blue"
            ShowCsvExport="False" ShowDbfExport="False"
            ShowMhtExport="False" ShowOdsExport="False" ShowOdtExport="False"
            ShowPowerPoint2007Export="False" ShowRtfExport="False" ShowTextExport="False"
            ShowXmlExcelExport="False" ShowXpsExport="False" PdfPrintScaling="False" />
    </div>
    </form>
</body>
</html>
