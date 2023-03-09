<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <script type="text/javascript">
 function submitform()
 {
 document.form1.submit();
 }
 </script>
<head runat="server">
    <title>:: FAME ::</title>
</head>
<body onload="moveTo(100,0); resizeTo(650,450);" style="color: #000000" >
    <form  id="form1" runat="server">
    <div>
        &nbsp;
   
 <asp:FileUpload ID="FileUpload1"  runat="server" Width="488px"  style="z-index: 100; left: 46px; position: absolute; top: 150px" Height="27px" Font-Bold="True" BackColor="Khaki" BorderColor="Black" Font-Names="Arial" />
        <asp:Label ID="Label1" runat="server" Style="z-index: 101; left: 113px; position: absolute;
            top: 225px" Width="95px" ForeColor="Black" Font-Size="X-Small"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Black"
            Style="z-index: 102; left: 45px; position: absolute; top: 127px" Text="SELECT FILE TO UPLOAD :"
            Width="166px" Height="19px" Font-Size="9pt"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Arial"
            Font-Size="0.8em" Font-Underline="False" ForeColor="Black" Style="z-index: 103;
            left: 34px; position: relative; top: 38px" Text="File Attachment Module for Email" Width="257px"></asp:Label>
        <asp:Image ID="Image1" runat="server" Height="47px" ImageUrl="~/Images/new_logo.gif"
            Style="z-index: 104; left: 419px; position: absolute; top: -4px" Width="132px" />
        &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="Khaki" Font-Bold="True"
            Font-Italic="False" Font-Size="10pt" Height="26px" OnClick="Button1_Click" Style="z-index: 105;
            left: 452px; position: absolute; top: 182px" Text="Upload" Width="81px" BorderColor="Black" Font-Names="Arial" />
        <asp:Button ID="Button2" runat="server" BackColor="Khaki" Font-Bold="True"
            Font-Italic="False" Font-Size="10pt" Height="26px" OnClick="Button2_Click" Style="z-index: 106;
            left: 451px; position: absolute; top: 215px" Text="Help" Width="81px" BorderColor="Black" Font-Names="Arial" />
        <asp:Button ID="Button3" runat="server" BackColor="Khaki" Font-Bold="True"
            Font-Italic="False" Font-Size="10pt" Height="26px" OnClick="Button3_Click" Style="z-index: 107;
            left: 452px; position: absolute; top: 248px" Text="Close" Width="81px" BorderColor="Black" Font-Names="Arial" />
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial"
            ForeColor="Black" Height="19px" Style="z-index: 108; left: 45px; position: absolute;
            top: 224px" Text="File Size :" Width="65px" Font-Size="9pt"></asp:Label>
        <br />
        <asp:Image ID="Image2" runat="server" Height="34px" ImageUrl="~/Images/untitled4.bmp"
            Style="z-index: 109; left: 42px; position: absolute; top: 8px" Width="148px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <asp:DropDownList ID="ddldept" runat="server" BackColor="Khaki" Style="z-index: 114;
            left: 45px; position: absolute; top: 198px" Width="166px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="10pt" Style="z-index: 111;
            left: 224px; position: absolute; top: 180px" Text="Password" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="txtpassword" runat="server" BackColor="Khaki" Font-Bold="True" Style="z-index: 112;
            left: 222px; position: absolute; top: 198px" TextMode="Password" Visible="False">12345</asp:TextBox>
        <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="X-Small"
            ForeColor="Red" Height="3px" Style="z-index: 113; left: 35px; position: relative;
            top: 38px" Text="* You can Only Upload (Doc,Xls,Pdf,PPT,PPS,ZIP,TXT,RAR,JPG,GIF) files."
            Width="400px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; <span style="font-size: 10pt">&nbsp;<asp:LinkButton ID="lnkadmin"
            runat="server" Font-Bold="True" Font-Names="Arial" OnClick="lnkadmin_Click" Style="left: 1px">Admin</asp:LinkButton>
            &nbsp; &nbsp; &nbsp; </span><a href="mailto:RELDelhiSoftware.Support@relianceada.com?">
            <strong><span style="font-size: 10pt; font-family: Arial">Contact Us</span></strong></a>
        <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="10pt" Style="z-index: 111;
                left: 46px; position: absolute; top: 180px" Text="Department"></asp:Label>
    </div>
    </form>
</body>


</html>


