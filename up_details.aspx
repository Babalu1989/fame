<%@ Page Language="C#" AutoEventWireup="true" CodeFile="up_details.aspx.cs" Inherits="up_details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:-:-:-:-::Document Repository  System::-:-:-:-:</title>
    <link rel="Shortcut icon" href="favicon.ico" type="image/x-icon"/>
    <script type="text/javascript">
        function checkDate(sender, args) 
        {
            if ( sender._selectedDate > new Date()) 
            {
                alert("Please,Select Valid Date Format!!!");
                sender._selectedDate = new Date();
                
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="High Tower Text"
            Font-Size="Medium" ForeColor="Gray" Height="21px" meta:resourcekey="Label1Resource1"
            Style="left: 50px; position: relative; top: -4px" Text="Document Repository  System"
            Width="224px"></asp:Label>
        <img src="images/NewLogoofbses.gif.gif" style="left: 496px; width: 115px; position: relative;
            top: 0px; height: 34px" /><br />
        <asp:Panel ID="Panel2" runat="server" Height="20px" meta:resourcekey="Panel2Resource1"
            Style="border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
            border-bottom: #000000 thin solid; background-color: #718bbe" Width="934px">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
                ForeColor="Gainsboro" Height="20px" meta:resourcekey="Label3Resource1" Style="z-index: 100;
                left: 41px; position: relative; top: 0px" Width="246px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Bell MT" ForeColor="Gainsboro"
                Height="11px" Style="left: -78px; position: relative; top: -7px" Width="170px"></asp:Label></asp:Panel>
        <table id="TABLE1" bordercolor="#000000" frame="above" onclick="return TABLE1_onclick()"
            style="border-right: black thin solid; border-top: black thin solid; z-index: 106;
            left: 7px; border-left: black thin solid; width: 922px; border-bottom: black thin solid;
            position: relative; top: 1px; height: 33px">
            <tr>
                <td colspan="5">
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Groove" Height="18px"
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 948px; height: 209px">
                    <tr>
                        <td colspan="2">
                            <span style="font-size: 11pt">
                            <span style="color: #006699;"><strong>Date-wise&nbsp;
                                Details</strong></span>:: </span>&nbsp; &nbsp;<asp:TextBox ID="txt_date" runat="server" Width="143px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">Click Here For Calendar</asp:TextBox>
                            <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click1" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MM/yyyy"
                                 targetcontrolid="txt_date" OnClientDateSelectionChanged="checkDate"></cc1:calendarextender>
                            <asp:Label ID="Label2" runat="server" Visible="False" Width="142px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
                                HorizontalAlign="Right" Width="941px" Height="118px">
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="F_FILENAME" HeaderText="File Name" />
                                    <asp:BoundField DataField="F_SERIAL" HeaderText="Application ID" />
                                    <asp:BoundField DataField="dir_id" HeaderText="Document ID" />
                                    <asp:BoundField DataField="UPLOADED_BY" HeaderText="Uploaded By" />
                                    <asp:BoundField DataField="DATEUPLOADED" HeaderText="Uploaded On" />
                                </Columns>
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="Small" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                <AlternatingRowStyle BackColor="Gainsboro" />
                            </asp:GridView>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="20px" meta:resourcekey="Panel1Resource1"
            Style="border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
            border-bottom: #000000 thin solid; background-color: #718bbe" Width="934px">
        </asp:Panel>
    </form>
</body>
</html>
