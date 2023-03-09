<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_cretion.aspx.cs" Inherits="user_cretion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:-:-:-::Document Repository  System::-:-:-:</title>
    <link rel="Shortcut icon" href="favicon.ico" type="image/x-icon"/>
<script language="javascript" type="text/javascript">     
function blockChar(e)
{
var keyVal =(window.event) ? event.keyCode : e.keyCode;
if (window.event) keyVal = window.event.keyCode;
if((keyVal > 64 && keyVal < 93))
{
alert('Alphabets are not allowed here!!!');
return false;
}
return true;
}

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="High Tower Text"
            Font-Size="Medium" ForeColor="Gray" Height="21px" meta:resourcekey="Label1Resource1"
            Style="left: 49px; position: relative; top: 23px" Text="Document Repository  System"
            Width="230px"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1" Style="border-right: #000000 thin solid;
            border-top: #000000 thin solid; z-index: 100; left: 0px; border-left: #000000 thin solid;
            border-bottom: #000000 thin solid; position: relative; top: 8px; background-color: #718bbe"
            Width="951px">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
                ForeColor="Gainsboro" Height="20px" meta:resourcekey="Label3Resource1" Style="z-index: 100;
                left: 34px; position: relative; top: 1px" Width="246px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="Gainsboro" Style="left: 360px;
                position: relative; top: -6px" Width="170px" Font-Names="Bell MT" Height="11px"></asp:Label></asp:Panel>
        &nbsp;
        <img src="images/NewLogoofbses.gif.gif" style="left: 705px; width: 128px; position: relative;
            top: -54px; z-index: 105;" height="34" /><br />
        &nbsp;<table id="TABLE1" bordercolor="#000000" frame="above" style="border-right: black thin solid;
            border-top: black thin solid; z-index: 106; left: 8px; border-left: black thin solid;
            width: 930px; border-bottom: black thin solid; position: relative; top: -49px; height: 9px;" onclick="return TABLE1_onclick()">
            <tr>
                <td colspan="5">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
        <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Groove" Height="18px"
            ImageUrl="~/images/back.png" OnClick="ImageButton1_Click" ToolTip="Back" Width="50px" />
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                <td style="width: 100px">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" Font-Size="Medium"
                        ForeColor="Red" meta:resourcekey="LinkButton1Resource1" OnClick="LinkButton1_Click"
                        Style="left: 316px; top: -54px">Logout</asp:LinkButton></td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <table frame="border" style="font-weight: bold; font-size: 10pt; left: 135px;
        width: 728px; font-family: Arial; position: absolute; top: 125px; height: 161px; background-color: #f7f6f3; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid; z-index: 102;">
                <tr>
                    <td colspan="4" style="background-color: #333399; height: 20px;">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style="color: #ffffff"><strong>User Creation</strong></span></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 26px;">
                        <span style="font-size: 10pt; font-family: Arial">
                        Emp Name</span></td>
                    <td style="width: 86px; height: 26px;">
                        <asp:TextBox ID="txtempname" runat="server"></asp:TextBox></td>
                    <td style="width: 100px; height: 26px;">
                        <span style="font-size: 10pt; font-family: Arial">
                        Emp Code</span></td>
                    <td style="width: 100px; height: 26px;">
                        <asp:TextBox ID="txtempcode" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <span style="font-size: 10pt; font-family: Arial">
                        Login ID</span></td>
                    <td style="width: 86px">
                        <asp:TextBox ID="txtloginid" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <span style="font-size: 10pt; font-family: Arial">
                        Contact No.</span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtcontactno" runat="server" MaxLength="10"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <span style="font-size: 10pt; font-family: Arial">
                        Email ID</span></td>
                    <td style="width: 86px">
                        <asp:TextBox ID="txtmailid" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <span style="font-size: 10pt; font-family: Arial">
                        Folder Name</span></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="ddl_module" runat="server" Width="151px">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem>Banking</asp:ListItem>
                            <asp:ListItem>Billing and Procurement</asp:ListItem>
                            <asp:ListItem>Central Accounts</asp:ListItem>
                            <asp:ListItem>Collections</asp:ListItem>
                            <asp:ListItem>Contracts</asp:ListItem>
                            <asp:ListItem>Pay Role</asp:ListItem>
                            <asp:ListItem>Vendor Payments</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 26px;" colspan="4">
                        User Level &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:DropDownList ID="ddl_level" runat="server" Width="152px">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem Value="Admin">Admin</asp:ListItem>
                            <asp:ListItem>User</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" Text="Save" Width="54px" /> <asp:Button ID="btn_update" runat="server" Text="Update" Width="56px" OnClick="btn_update_Click" />
                        <asp:Button ID="btn_refresh" runat="server" Text="Refresh" Width="56px" OnClick="btn_refresh_Click" />
                        <asp:Button ID="btn_block" runat="server" OnClick="btn_block_Click"
                            Text="Block User" Width="94px" />
                        <asp:Button ID="btn_pwd" runat="server" OnClick="btn_pwd_Click" Text="Reset Password" Width="115px" /></td>
                </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmailid"
                        ErrorMessage="Email ID is not Valid!!" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" Width="871px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CaptionAlign="Left" style="left: 35px; position: relative; top: 148px; z-index: 103;" BackColor="White" ShowFooter="True">
                <FooterStyle BackColor="Gray" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" Font-Names="Arial" Font-Size="Small" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" HorizontalAlign="Left" />
                <AlternatingRowStyle BackColor="Gainsboro" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="editing" CommandArgument="<%#((GridViewRow)Container).RowIndex %>">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="USER_ID" HeaderText="Login ID" />
                    <asp:BoundField DataField="USER_NAME" HeaderText="User Name" />
                    <asp:BoundField DataField="USER_LEVEL" HeaderText="User level" />
                    <asp:BoundField DataField="EMP_NO" HeaderText="Emp no." />
                    <asp:BoundField DataField="MODULE" HeaderText="Module" />
                    <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No." />
                    <asp:BoundField DataField="EMAIL_ID" HeaderText="Email ID" />
                </Columns>
            </asp:GridView>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
    
    </div>
    </form>
</body>
</html>
