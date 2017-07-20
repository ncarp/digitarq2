<%@ Control Language="vb" AutoEventWireup="false" Codebehind="horizontalMenu.ascx.vb" Inherits="WebSearch2.horizontalMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<ul class="basictab">
	<li id="liBasicSearch" runat="server">
		<span title='<%=Getlabel("WS.lnkBasicSearch")%>'><A href="Default.aspx?page=basicSearch&amp;searchMode=bs">
				<%=Getlabel("WS.lnkBasicSearch")%>
			</A></span>
	</li>
	<li id="liAdvancedSearch" runat="server">
		<span title='<%=Getlabel("WS.lnkAdvancedSearch")%>'><A href="Default.aspx?page=advancedSearch&amp;searchMode=as">
				<%=Getlabel("WS.lnkAdvancedSearch")%>
			</A></span>
	</li>
	<li id="liHelp" runat="server">
		<span title='<%=Getlabel("WS.lnkHelp")%>'><A href="Default.aspx?page=help&amp;searchMode=hlp">
				<%=Getlabel("WS.lnkHelp")%>
			</A></span>
	</li>
</ul>
