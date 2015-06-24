<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebSite.Index" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/IndexCss.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_head">
            <h1>XXXXXX医院</h1>
        </div>
        <div id="div_search">
            <fieldset>
                <legend>查询条件</legend>
                <div>    
                    <div>
                        <label>申请号:</label>
                        <asp:TextBox ID="CarNumberTextBox" runat="server"></asp:TextBox>
                        <label>姓  名: </label>
                        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                        <label>住院号:</label>
                        <asp:TextBox ID="HospitalizedNumberTextBox" runat="server"></asp:TextBox>
                    </div>                
                    <div>
                        <label>申请ID:</label>
                        <asp:TextBox ID="ApplyIDTextBox" runat="server"></asp:TextBox>
                        <label>患者来源:</label>
                        <asp:DropDownList runat="server" ID="Resourss">
                        <asp:ListItem Value="*">
                            全部
                        </asp:ListItem>
                        <%--<asp:ListItem Value="all">
                            全部
                        </asp:ListItem>--%>
                        </asp:DropDownList>
                        <label>检查项目:</label>
                        <asp:DropDownList ID="CheckItem" runat="server">
                        <asp:ListItem Value="00201" Text="常规心电">
                        </asp:ListItem>
                        <%--<asp:ListItem Value="00206" Text="动态心电">
                        </asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:Button ID="Check" runat="server" Height="20px" Text="查询" Width="100" OnClick="Button1_Click1"  />
                    </div>              
                </div>   
            </fieldset>  
        </div>
        <div id="div_main">
            <div id="div_main_left"></div>
            <div id="div_main_middle">
                <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"
                    onRowCreated="GridView1_RowCreated" AllowPaging="True" PageSize="35"
                    onPageIndexChanging="GridView1_PageIndexChanging" 
                    ShowHeader="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">         
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <PagerTemplate>
                        <asp:LinkButton ID="lbFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" 
                            CssClass="a">首页 </asp:LinkButton> 
                        <asp:LinkButton ID="lbPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CssClass="a"
                            CommandName="Page">上一页 </asp:LinkButton> 
                        <asp:LinkButton ID="lbNext" runat="server" CausesValidation="False" CommandArgument="Next" CssClass="a"
                            CommandName="Page">下一页 </asp:LinkButton> 
                        <asp:LinkButton ID="lbLast" runat="server" CausesValidation="False" CommandArgument="Last" CssClass="a"
                            CommandName="Page">最后一页 </asp:LinkButton> 
                        第 <asp:Label ID="Label2" runat="server" Text=" <%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"/>页  
                        共 <asp:Label ID="Label1" runat="server" Text=" <%# ((GridView)Container.Parent.Parent).PageCount %>"/>页  
                        跳到<asp:TextBox ID="tbpage" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>" Width="20"/>
                        <asp:LinkButton ID="lbGO" runat="server" CausesValidation="False" CommandArgument="-1" 
                            CommandName="Page" Text="GO" OnClick="GoIndex" CssClass="a" />
                    </PagerTemplate>
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            </div>
        </div>
        <div class="div_clear"></div>
        <div id="div_foot">
        </div>        
    </form>
</body>
</html>
