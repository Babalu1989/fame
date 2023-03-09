<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:-:-:-::Document Repository  System::-:-:-:</title>
    <link rel="Shortcut icon" href="favicon.ico" type="image/x-icon"/>
<script language="Javascript">
function resolution()
{
UserWidth = window.screen.availWidth
UserHeight = window.screen.availheight
window.resizeTo(UserWidth, UserHeight)
window.moveTo(0,0)
}
</script>
</head>
<body onload="resolution();">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel2" runat="server" Height="12px" Style="border-right: #000000 thin solid;
            border-top: #000000 thin solid; left: 0px; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
            position: relative; top: 78px; background-color: #718bbe; z-index: 100;" Width="935px">
        </asp:Panel>
        &nbsp; &nbsp;
    
    </div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="High Tower Text"
            Font-Size="Medium" ForeColor="Gray" Height="21px" meta:resourcekey="Label1Resource1"
            Style="left: 52px; position: relative; top: 0px; z-index: 101;" Text="Document Repository  System"
            Width="231px"></asp:Label><br />
        <br />
        <img src="images/NewLogoofbses.gif.gif" style="left: 749px; width: 128px; position: relative;
            top: -46px; z-index: 102;" height="34" />
        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:LinkButton ID="lnkfame" runat="server" Font-Bold="True" Font-Names="Arial" OnClick="lnkfame_Click"
            Style="z-index: 109; left: 823px; position: absolute; top: 119px">:: Fame Home ::</asp:LinkButton>
        <asp:Panel ID="Panel5" runat="server" Height="12px" Style="border-right: #000000 thin solid;
            border-top: #000000 thin solid; left: 0px; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
            position: relative; top: 265px; background-color: #718bbe; z-index: 104;" Width="935px">
        </asp:Panel>
        &nbsp;
        <asp:Panel ID="Panel6" runat="server" Height="7px" Style="left: 238px; border-top-style: solid;
            border-top-color: #ff3366; position: relative; top: 0px; z-index: 105;" Width="325px">
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="7px" Style="left: 370px; border-top-style: solid;
            border-top-color: #ff3366; position: relative; top: -440px; z-index: 106;" Width="356px">
        </asp:Panel>
        <table frame="below" style="border-right: gray thick solid; border-top: gray thick solid;
            left: 375px; border-left: gray thick solid; border-bottom: gray thick solid;
            position: relative; top: -13px; width: 333px; z-index: 107;" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td style="width: 100px">
                    <strong><span style="font-family: Trebuchet MS">
                        User ID</span></strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_userid" runat="server" Width="138px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <strong><span style="font-family: Trebuchet MS">Password</span></strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="Login" Width="64px" /></td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Height="7px" Style="left: 530px; border-top-style: solid;
            border-top-color: #ff3366; position: relative; top: -5px; z-index: 108;" Width="325px">
        </asp:Panel>
       </form>
</body>
</html>
