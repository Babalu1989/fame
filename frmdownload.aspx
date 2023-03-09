<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmdownload.aspx.cs" Inherits="frmdoenload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:: Download File ::</title>
</head>
<body onload="moveTo(100,0); resizeTo(650,450);">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Arial"
            Font-Size="0.8em" Font-Underline="False" ForeColor="Black" Style="z-index: 100;
            left: 34px; position: relative; top: 38px" Text="File Attachment Module for Email"
            Width="257px"></asp:Label>
        <asp:Image ID="Image1" runat="server" Height="47px" ImageUrl="~/Images/new_logo.gif"
                Style="z-index: 101; left: 419px; position: absolute; top: -4px" Width="132px" />
        <asp:Image ID="Image2" runat="server" Height="34px" ImageUrl="~/Images/untitled4.bmp"
            Style="z-index: 102; left: 42px; position: absolute; top: 8px" Width="148px" />
        <asp:TextBox ID="txtpassword" runat="server" BackColor="Khaki" Font-Bold="True" Style="z-index: 103;
            left: 45px; position: absolute; top: 189px" TextMode="Password" Visible="False">12345</asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server" BackColor="Khaki" ReadOnly="True" Style="z-index: 104;
            left: 48px; position: absolute; top: 146px" Width="354px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt" Style="z-index: 106;
            left: 49px; position: absolute; top: 170px" Text="Password" Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="10pt" Style="z-index: 106;
            left: 51px; position: absolute; top: 126px" Text="File to Download"></asp:Label>
        <asp:Button ID="Button1" runat="server" BackColor="Khaki" BorderColor="Black" Font-Bold="True"
            Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Height="26px" OnClick="Button1_Click"
            Style="z-index: 105; left: 417px; position: absolute; top: 146px" Text="Download"
            Width="81px" />
        <asp:Button ID="Button3" runat="server" BackColor="Khaki" BorderColor="Black" Font-Bold="True"
            Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Height="26px" OnClick="Button3_Click"
            Style="z-index: 107; left: 417px; position: absolute; top: 182px" Text="Close"
            Width="81px" />
    
    </div>
    </form>
</body>
</html>
