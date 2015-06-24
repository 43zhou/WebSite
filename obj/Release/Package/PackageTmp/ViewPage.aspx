<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="WebSite.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function change(obj) {
            document.forms["form1"].submit();
        }

        function print() {
            form1.window.focus();
            window.print();
        }
    </script> 
    <link href="css/ViewPageCss.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .auto-style1 {
            width: 88px;
        }
        .auto-style2 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="div_head">
             <h1>XXXXXX医院</h1>
        </div>
        <div id="div_detail">
            <p>详细报告</p>
            <div id="div_detail_left">
                <asp:Label ID="Label1" runat="server" Text="姓名："></asp:Label>
                <asp:TextBox ID="txtB_name" runat="server" ></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="申请号："></asp:Label>
                <asp:TextBox ID="txtB_applyId" runat="server"></asp:TextBox>        
                <asp:Label ID="Label3" runat="server" Text="检查类型：" ></asp:Label>
                <asp:DropDownList ID="ddl_checkType" runat="server" onchange="change(this)" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btn_print" OnClick="btn_print_Click" Text="打印" runat="server" Width="60"/>
                <asp:Button ID="btn_back" OnClick="btn_back_Click" Text="返回" runat="server" Width="60"/>
            </div>
            <div id="div_detail_middle">
                <table>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text=" 心率："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_HR" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label6" runat="server" Text="房率："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_FL" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label15" runat="server" Text="室率："></asp:Label></td>
                        <td class="auto-style1"><asp:TextBox ID="txtB_SL" runat="server" ></asp:TextBox></td>            
                        <td><asp:Label ID="Label7" runat="server" Text="QRS："></asp:Label></td>
                        <td class="auto-style1"><asp:TextBox ID="txtB_QRS" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label8" runat="server" Text="QT："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_QT" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label9" runat="server" Text="QTc："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_QTc" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label10" runat="server" Text="电轴：" Width="49px"></asp:Label></td>
                        <td><asp:TextBox ID="txtB_AXIS" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label11" runat="server" Text="RV5/SV1："></asp:Label></td>
                        <td class="auto-style1"><asp:TextBox ID="txtB_RV5_SV1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label12" runat="server" Text="RV6："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_RV6" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label13" runat="server" Text="P时限："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_PWD" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label14" runat="server" Text="RS："></asp:Label></td>
                        <td><asp:TextBox ID="txtB_RS" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label5" runat="server" Text="PR：" ></asp:Label></td>
                        <td><asp:TextBox ID="txtB_PR" runat="server" ></asp:TextBox></td>
                    </tr>
                </table>          
            </div>
            <div id="div_detail_right">
                <table>
                     <tr>
                        <td class="auto-style2"><asp:Label ID="Label16" runat="server" Text="特征："></asp:Label></td>
                        <td class="auto-style2"><asp:TextBox ID="txtB_fuature" runat="server" TextMode="MultiLine" Height="127px" Width="132px" ></asp:TextBox></td>
                        <td class="auto-style2"><asp:Label ID="Label17" runat="server" Text="诊断："></asp:Label></td>
                        <td class="auto-style2"><asp:TextBox ID="txtB_conclution" runat="server" TextMode="MultiLine" Height="121px" Width="128px"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="div_clear"></div>
        <div id="div_main">
            <asp:Image ID="image1" runat="server" />
        </div>
        <div class="div_clear"></div>
        <div id="div_foot"></div>
    </form>
</body>
</html>