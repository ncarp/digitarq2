<%@ Control Language="vb" AutoEventWireup="false" Codebehind="menuLeft.ascx.vb" Inherits="WebSearch2.uc_menuLeft" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table align="center">
	<tr>
		<td>
			<div class="sdmenu">
				<span class="title" id="top"><img src="Images/expanded.gif" class="arrow" alt="-"><%=GetLabel("WS.menuLeft.hlnkSearch")%></span>
				<div class="submenu">
					<a href="<%= strUrlBasicSearch %>" title='<%=GetLabel("WS.menuLeft.hlnkBasicSearch")%>'><%=GetLabel("WS.menuLeft.hlnkBasicSearch")%></a>
					<a href="<%= strUrlAdvancedSearch %>" title='<%=GetLabel("WS.menuLeft.hlnkAdvancedSearch")%>'><%=GetLabel("WS.menuLeft.hlnkAdvancedSearch")%></a>
				</div>
				<span class="title"><img src="Images/expanded.gif" class="arrow" alt="-"><%=GetLabel("WS.menuLeft.hlnkRequests")%></span>
				<div class="submenu">
					<a href="<%=strUrlConsultationRequest%>" title='<%=GetLabel("WS.menuLeft.hlnkConsultationRequest")%>'>
						<%=GetLabel("WS.menuLeft.hlnkConsultationRequest")%>
					</a><a href="<%=strUrlReservationRequest%>" title='<%=GetLabel("WS.menuLeft.hlnkReservationRequest")%>'>
						<%=GetLabel("WS.menuLeft.hlnkReservationRequest")%>
					</a><a href="<%=strUrlReproductionRequest%>" title='<%=GetLabel("WS.menuLeft.hlnkReproductionRequest")%>'>
						<%=GetLabel("WS.menuLeft.hlnkReproductionRequest")%>
					</a>
				</div>
			</div>
		</td>
	</tr>
</table>
