<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:-:-:-:-::Document Repository  System::-:-:-:-:</title>
    <link rel="Shortcut icon" href="favicon.ico" type="image/x-icon"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="High Tower Text" ForeColor="Gray"
            Style="left: 6px; position: relative; top: 28px;" Text="Document Repository  System" Width="225px" meta:resourcekey="Label1Resource1" Font-Size="Medium" Height="21px"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <img src="images/NewLogoofbses.gif.gif" style="left: 264px; width: 128px; position: relative;
            top: 2px; height: 34px;" /><br />
        <asp:Panel ID="Panel2" runat="server" Style="border-right: #000000 thin solid;
            border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
            background-color: #718bbe;" Width="951px" meta:resourcekey="Panel2Resource1" Height="20px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
                    ForeColor="Gainsboro" Height="20px" Style="z-index: 100; left: 41px; position: relative;
                    top: 0px" Width="246px" meta:resourcekey="Label3Resource1"></asp:Label>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;
                <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="Gainsboro" Style="left: -78px;
                    position: relative; top: -7px" Width="170px" Font-Names="Bell MT" Height="11px"></asp:Label></asp:Panel>
       <table frame="above" style="border-right: black thin solid; border-top: black thin solid;
            border-left: black thin solid;  border-bottom: black thin solid; width: 943px;" bordercolor="#000000">
                <tr>
                    <td colspan="5" style="height: 13px">
                        &nbsp; 
                        <asp:LinkButton ID="lk_pwd" runat="server" Font-Bold="False" ForeColor="Black" meta:resourcekey="lk_pwdResource1"
                            OnClick="lk_pwd_Click" Width="125px" Font-Size="Medium"></asp:LinkButton>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="False" ForeColor="Black"
                            meta:resourcekey="LinkButton4Resource1" OnClick="LinkButton4_Click" Text="Administrator" Font-Size="Medium"></asp:LinkButton>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False"
                            ForeColor="Black" meta:resourcekey="LinkButton2Resource1" OnClick="LinkButton2_Click" Font-Size="Medium" Text="Create Folder" Visible="False"></asp:LinkButton>
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="False" ForeColor="Black"
                            meta:resourcekey="LinkButton3Resource1" OnClick="LinkButton3_Click" Text="Upload Files" Visible="False" Font-Size="Medium"></asp:LinkButton>
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton5" runat="server" Font-Size="Medium" ForeColor="Black"
                            OnClick="LinkButton5_Click">Uploading Details</asp:LinkButton></td>
                    <td style="width: 100px; height: 13px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" Font-Size="Medium"
                            ForeColor="Red" meta:resourcekey="LinkButton1Resource1" OnClick="LinkButton1_Click"
                            Style="left: 316px; top: -54px"></asp:LinkButton></td>
                </tr>
            </table>
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="18px" ImageUrl="~/images/back.png"
            OnClick="ImageButton1_Click" Width="50px" BorderStyle="Groove" ToolTip="Back" meta:resourcekey="ImageButton1Resource1" />&nbsp;
        <asp:Literal ID="litLocation" runat="server" Mode="PassThrough" meta:resourcekey="litLocationResource1" />
        &nbsp; &nbsp; &nbsp;<asp:Panel ID="Panel3" runat="server" Height="188px" ScrollBars="Auto"
            Width="955px">
        <asp:GridView ID="GridView2" runat="server"
            BorderColor="#999999" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
            OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="934px" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="False" BorderStyle="None" OnRowCommand="GridView2_RowCommand" Height="10px" meta:resourcekey="GridView2Resource1" ShowHeader="False" style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <Columns>
                <asp:TemplateField HeaderText="Folders/Files" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="17px" Width="27px" meta:resourcekey="Image1Resource1"  />
                 
                        &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Width="516px"  Text='<%# Bind("Name") %>' meta:resourcekey="HyperLink2Resource1" OnDataBinding="HyperLink2_DataBinding"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Details" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Width="151px" meta:resourcekey="HyperLink1Resource1">Details</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource4" HeaderText="Size">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink3" runat="server" meta:resourcekey="HyperLink3Resource1" Text="Size" Visible="False"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource3" Visible="False" >
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Image") %>' meta:resourcekey="Label2Resource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="del" Height="17px" ImageUrl="~/icons/trash.png" Width="27px" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ToolTip="Delete" meta:resourcekey="ImageButton2Resource1" OnClick="ImageButton2_Click" Visible="False"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="Gainsboro" />
            <RowStyle Font-Names="Arial" Font-Size="Small" BackColor="#EEEEEE" ForeColor="Black" />
        </asp:GridView>
        </asp:Panel>
        <table id="table_search" runat="server" visible="false" style="height: 16px; border-right: #003300 2px solid; border-top: #003300 2px solid; border-left: #003300 2px solid; border-bottom: #003300 2px solid;" frame="border" >
            <tr>
                <td style="width: 123px">
                    <strong><span style="color: #006699">Search By</span>::</strong></td>
                <td style="width: 281px">
                    <span style="font-size: 9pt; font-family: Verdana"><span style="text-decoration: underline">
                        Application ID</span> <span style="font-size: 11pt; color: red"><strong>/</strong></span>
                        <span style="text-decoration: underline">File Name</span> <span style="font-size: 11pt;
                            color: #ff3366"><strong>/</strong></span> <span><span style="text-decoration: underline">
                                Document
                                ID</span><strong> ::</strong></span></span></td>
                <td>
        <asp:TextBox ID="txt_search" runat="server" Width="196px" AutoCompleteType="Disabled" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>&nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="19px" ImageUrl="~/images/search_button.jpg"
                        OnClick="ImageButton3_Click" Width="92px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Red" Text="You are not authorized to view this folder!!!!"
            Visible="False" Width="293px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <table id="TABLE1" runat="server" frame="below" style="border-right: black thin solid;
            border-top: black thin solid; border-left: black thin solid;  border-bottom: black thin solid"
            visible="false">
            <tr>
                <td >
                    <span style="font-size: 10pt; font-family: Arial">Folder Name <strong>::</strong></span></td>
                <td >
                    <asp:TextBox ID="txtFolder" runat="server" BackColor="LemonChiffon" meta:resourcekey="txtFolderResource1" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                <td >
                    <asp:Button ID="Button1" runat="server" OnClick="btnNewFolder_Click" Text="Create New Folder"
                        Width="130px" meta:resourcekey="Button1Resource2" /></td>
            </tr>
        </table>
        <table style="border-top-width: 2px; border-left-width: 2px; border-left-color: black; border-bottom-width: 2px; border-bottom-color: black; border-top-color: black; border-right-width: 2px; border-right-color: black">
            <tr>
                <td style="width: 100px">
        <asp:FileUpload ID="fupTest" runat="server" BackColor="LemonChiffon" Width="400px" meta:resourcekey="fupTestResource1" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" /></td>
                <td style="width: 100px">
        <asp:TextBox ID="txt_sapno" runat="server" BorderStyle="Solid" BorderWidth="1px" ToolTip="Insert Document No." Visible="False"></asp:TextBox></td>
                <td style="width: 100px">
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload File" meta:resourcekey="btnUploadResource1" /></td>
            </tr>
        </table>
        <asp:Label ID="labMessage" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            ForeColor="Red" style="z-index: 102; left: 0px; top: -10px" meta:resourcekey="labMessageResource1"></asp:Label>&nbsp; &nbsp;
        <br />
        <asp:GridView ID="GridView1" runat="server"
            BorderColor="#999999" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="934px" OnRowDataBound="GridView1_RowDataBound" BorderStyle="None" Height="10px" meta:resourcekey="GridView2Resource1" style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" BackColor="White" HorizontalAlign="Center">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle Font-Names="Arial" Font-Size="Small" BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" Font-Size="Small" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="20px" Style="border-right: #000000 thin solid;
            border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
            background-color: #718bbe;" Width="951px" meta:resourcekey="Panel1Resource1">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
