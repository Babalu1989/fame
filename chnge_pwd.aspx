<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chnge_pwd.aspx.cs" Inherits="chnge_pwd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>:-:-:-::Document Repository  System::-:-:-:</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
     <link rel="Shortcut icon" href="favicon.ico" type="image/x-icon"/>
</head>
<body>
        <form id="form2" runat="server">
            <div>
                &nbsp;<br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="High Tower Text"
                    Font-Size="Medium" ForeColor="Gray" Height="21px" meta:resourcekey="Label1Resource1"
                    Style="left: 65px; position: relative; top: 10px" Text="Document Repository  System"
                    Width="230px"></asp:Label>
                <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1" Style="border-right: #000000 thin solid;
                    border-top: #000000 thin solid; left: 10px; border-left: #000000 thin solid;
                    border-bottom: #000000 thin solid; position: relative; top: 14px; background-color: #718bbe; z-index: 100;"
                    Width="951px" Height="21px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
                        ForeColor="Gainsboro" Height="20px" meta:resourcekey="Label3Resource1" Style="z-index: 100;
                        left: 34px; position: relative; top: 1px" Width="246px"></asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp;<asp:Label
                        ID="Label4" runat="server" ForeColor="Gainsboro" Width="170px" style="left: 329px; position: relative; top: -6px" Font-Bold="False" Font-Names="Bell MT" Height="11px"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </asp:Panel>
                &nbsp;&nbsp;
                <img src="images/NewLogoofbses.gif.gif" style="z-index: 104; left: 729px; width: 123px;
                    position: relative; top: -51px; height: 35px;" /></div>
            <strong>
                    <br />
                    <br />
                    <table id="TABLE1" bordercolor="#000000" frame="above" onclick="return TABLE1_onclick()"
                        style="border-right: black thin solid; border-top: black thin solid; z-index: 106;
                        left: 11px; border-left: black thin solid; width: 949px; border-bottom: black thin solid;
                        position: relative; top: -60px">
                        <tr>
                            <td colspan="5">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Groove" Height="18px"
                                    ImageUrl="~/images/back.png" OnClick="ImageButton1_Click" ToolTip="Back" Width="50px" />
                                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                            <td style="width: 100px">
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" Font-Size="Medium"
                                    ForeColor="Red" meta:resourcekey="LinkButton1Resource1" OnClick="LinkButton1_Click"
                                    Style="left: 316px; top: -54px">Logout</asp:LinkButton></td>
                        </tr>
                    </table>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1"  runat="server">
                                        </asp:ScriptManager>
 
                        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
             <cc1:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="txt_new"
            DisplayPosition="RightSide"
            StrengthIndicatorType="Text"
            PreferredPasswordLength="8" 
            PrefixText="Strength:"
            HelpStatusLabelID="TextBox1_HelpLabel"
            TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
            StrengthStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5"
            MinimumNumericCharacters="1"
            RequiresUpperAndLowerCaseCharacters="false" />
            <table frame="border" style="font-weight: bold; font-size: 10pt; left: 304px;
        width: 387px; font-family: Arial; position: absolute; top: 159px; height: 170px; background-color: #f7f6f3; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                <tr>
                    <td colspan="2" style="background-color: #333399">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp;&nbsp; <span style="color: #ffffff">
                            Password Change Window</span></td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 10pt">&nbsp;<span style="font-family: Arial;">Old Password</span></span></span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_old" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 10pt">&nbsp;<span style="font-family: Arial;">New Password</span></span></span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_new" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 10pt">&nbsp;<span style="font-family: Arial;">Confirm Password</span></span></span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_conf" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 124px">
                    </td>
                    <td style="width: 100px">
                        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" /></td>
                </tr>
            </table>
                </ContentTemplate>
                                       
           <Triggers>
<asp:PostBackTrigger ControlID="btn_submit"></asp:PostBackTrigger>
</Triggers>
            </asp:UpdatePanel>
                    &nbsp;<img src="images/NewLogoofbses.gif.gif" style="left: 796px; width: 128px; position: relative;
                        top: -376px; z-index: 107;" /></strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="TextBox1_HelpLabel" runat="server" Style="left: 149px; position: relative;
                top: 117px; z-index: 104;" Width="350px"></asp:Label>
            <%--<asp:Panel ID="Panel1" runat="server" Height="7px" Style="left: 452px; border-top-style: solid;
                border-top-color: #ff3366; position: relative; top: -107px" Width="384px">
            </asp:Panel>--%>
            &nbsp; &nbsp;<%--<asp:Panel ID="Panel5" runat="server" Height="22px" Style="border-right: #000000 thin solid;
                border-top: #000000 thin solid; left: -4px; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
                position: relative; top: 161px; background-color: #718bbe" Width="951px">
            </asp:Panel>--%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
          <%--  <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                Style="left: 436px; position: relative; top: -338px" Text="Password Change Window"
                Width="181px"></asp:Label>--%>
            <asp:Panel ID="Panel3" runat="server" meta:resourcekey="Panel2Resource1" Style="border-right: #000000 thin solid;
                    border-top: #000000 thin solid; border-left: #000000 thin solid;
                    border-bottom: #000000 thin solid; background-color: #718bbe; z-index: 105; left: 11px; position: relative; top: 129px;"
                    Width="951px" Height="21px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</asp:Panel>
            &nbsp; &nbsp;&nbsp;
        </form>
</body>
</html>
