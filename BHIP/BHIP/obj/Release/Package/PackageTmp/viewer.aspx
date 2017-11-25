<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewer.aspx.cs" Inherits="BHIP.viewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>Reporting</title>
    <style type="text/css">
        body:nth-of-type(1) img[src*="Blank.gif"]{display:none;}
        .DataGridFixedHeader {
            POSITION: relative;
            BACKGROUND-COLOR: white;
            ;
            TOP: expression(this.offsetParent.scrollTop);
        }

        .style1 {
            font-family: Arial;
            font-size: x-small;
        }

        .style2 {
            font-family: Arial;
        }
        .MaxViewer {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server" style="width:100%; height:100%;">
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr valign="top">
                <td align="left">
                    <div id="pnlRep" style="color:Black;font-family:Arial;height:100%;width:100%;">

                        <table id="tblReportHolder" cellpadding="0" cellspacing="0" width="100%" border="0">
                            <tr>
                                <td>
                                <rsweb:reportviewer id="rv" runat="server" font-names="Verdana" font-size="8pt" CssClass="dropShadowPanelBody" 
                                interactivedeviceinfos="(Collection)" processingmode="Remote" waitmessagefont-names="Verdana" KeepSessionAlive="true"
                                waitmessagefont-size="14pt" Width="100%" Height="100%" AsyncRendering="False" SizeToReportContent="True" ShowPrintButton="false"  AsyncPostBackTimeOut="56000">
                                <ServerReport ReportPath="" ReportServerUrl="" />            
                                </rsweb:reportviewer>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
