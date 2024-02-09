<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:xal="http://xml.apache.org/xalan" 
	xmlns:x="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="x xml xal">
	
	<xsl:output method="xml" indent="yes"/>
	
	<!-- 
		<stylesheet>
			This is a demonstration of how Presentation Instructions can be overriden.
			It's intended to be used in couple with Attribute_API.xsl by a user of API.
			<note>This stylesheet should be used whenever a new Category XML is received from API to modify PI to fit your needs.</note>
		</stylesheet>
	-->
	<!--
		<template match="/">
			The template is a starting point in modifying Presentation Instructions or other attributes.
		</template>
	 -->
	<xsl:template match="/">
		<xsl:apply-templates mode="NewStyle" select="."/>
	</xsl:template>

	<!--
		<template mode="NewStyle" match="@*|node()">
			The template is used to copy all content of XML that doesn't have templates to override it.
		</template>
	 -->
	<xsl:template mode="NewStyle" match="@*|node()">
		<xsl:copy>
			<xsl:apply-templates mode="NewStyle" select="@*|node()"/>
		</xsl:copy>
	</xsl:template>
	
	<!--
		<template mode="NewStyle" match="Row/Widget/Attribute/Label">
			The template is an example of overriding font attributes of the attribute labels in XML in Presentation Instructions
		</template>
	 -->
	<xsl:template mode="NewStyle" match="Row/Widget/Attribute/Label">
		<xsl:copy>
			<xsl:attribute name="face">Verdana,Geneva,Arial,Helvetica</xsl:attribute> 
			<xsl:attribute name="style">font-size:11px</xsl:attribute>
			<xsl:apply-templates mode="NewStyle" select="@*|node()"/>
		</xsl:copy>
	</xsl:template>
	
	<!--
		<template mode="NewStyle" match="Row/Widget/MessageBottom">
			The template is an example of overriding font attributes for the messages around input boxes
		</template>
	 -->
	<xsl:template mode="NewStyle" match="Row/Widget/MessageBottom">
		<MessageBottom face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px" color="#666666"/>
	</xsl:template>
	<!--
		<template mode="NewStyle" match="Row/Widget/MessageTop">
			The template is an example of overriding font attributes for the messages around input boxes
		</template>
	 -->
	<xsl:template mode="NewStyle" match="Row/Widget/MessageTop">
		<MessageTop face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px" color="#666666"/>
	</xsl:template>
	<!--
		<template mode="NewStyle" match="Row/Widget/MessageLeft">
			The template is an example of overriding font attributes for the messages around input boxes
		</template>
	 -->
	<xsl:template mode="NewStyle" match="Row/Widget/MessageLeft">
		<MessageLeft face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px" color="#666666"/>
	</xsl:template>
	<!--
		<template mode="NewStyle" match="Row/Widget/MessageRight">
			The template is an example of overriding font attributes for the messages around input boxes
		</template>
	 -->
	<xsl:template mode="NewStyle" match="Row/Widget/MessageRight">
		<MessageRight face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px" color="#666666"/>
	</xsl:template>

	<!--
		<template mode="NewStyle" match="/eBay">
			This template is used as an example of adding new XML data to the metadata XML
			The functionality in this template is used to override values of variables used in presentation XSL.
		</template>
	 -->
	<xsl:template mode="NewStyle" match="/eBay">
		<!-- copy what ever eBay has -->
		<xsl:copy>
			<xsl:apply-templates mode="NewStyle" select="@*|node()"/>
			<!-- adding new data -->
			<API.XSL.Overrides>
				<Styles>
					<!-- overriding atributes of body tag -->
					<Background bgcolor="#DDDDDD" background=""/>
					<!-- overriding fonts used in Attributes_API.xsl -->
					<Fonts>
						<font id="Error" face="Arial, Helvetica, sans-serif" size="2" color="#CC0000"/> <!-- font used in error messages -->
						<font id="default" face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px"/> <!-- font used in displaying TextMessage -->
						<font id="non-js-update-section" face="Arial, Helvetica, sans-serif" size="2" color="660000"/> <!-- this font is used in section that appears when JS is disabled. -->
						<font id="item-specifics-title" face="Arial, Helvetica, sans-serif" style="font-weight: 700" size="2" color="660000"/> <!-- this font is to show ItemSpecifics header. -->
						<font id="message-style-default" face="Verdana,Geneva,Arial,Helvetica" style="font-size:11px" color="#666666"/> <!-- this font is used in case no fonts were specified for MessageTop/Bottom/Left/Right in PI -->
					</Fonts>
					<!-- overriding/adding new CSS, it also can be used to add JS sections  -->
					<!-- here we declare the font for input boxes; font and its color for list/drop boxes and etc. -->
					<Head>
						<style type="text/css">
							input {font: italic small-caps 900 11px verdana}
							select {color: green; font-family: verdana, courier, serif; font-size: 11px}
							hr {color: sienna}
							p {margin-left: 20px}
						</style>
						<script language="JavaScript">
							var hw = ""
							
							function openHelpWindow(path) {
								if (navigator.appName.indexOf("WebTV") == -1) {
									hw = window.open(path, "helpwin", "height=465,width=410,scrollbars=yes,status=no,toolbar=no,menubar=no,location=no,resizable=yes,titlebar=no");
									if ((navigator.userAgent.toLowerCase().indexOf("msie") == -1) || (parseInt(navigator.appVersion) >= 5))
										hw.focus();
									return false;
								}
								else { document.location.href = path; }
							}
						</script>
					</Head>
					<!-- image attributes described in this section will be copied to actual images -->
					<Images>
						<!-- Image used to mark required fields -->
						<Image.RequiredMark  src="http://pics.ebay.com/aw/pics/asteriskG_10x10.gif" width="10" height="10"/>
						<Image.Spacer src="http://pics.ebay.com/aw/pics/spacer.gif"/>
						<Image.ArrowMaroon src="http://pics.ebay.com/aw/pics/arrowMaroon_9x11.gif"/>
					</Images>
				</Styles>
				<Use>
					<Form name="APIForm"/> <!-- This defines a name of the form that will be used by Attributes -->
				</Use>
				<Show>
					<ItemSpecificsOnly/> <!-- Says to not generate head, body and form, but only ItemSpecifics -->
				</Show>
			</API.XSL.Overrides>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
